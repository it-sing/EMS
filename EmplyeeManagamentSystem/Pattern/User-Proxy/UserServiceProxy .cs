using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagamentSystem.Service;

namespace EmployeeManagamentSystem.Pattern.User_Proxy
{
    public class UserServiceProxy : IUserService
    {
        private RealUserService _realUserService;
        private readonly Dictionary<string, DataSet> _cachedUserData;
        private readonly Dictionary<int, string> _actionLog;

        public UserServiceProxy()
        {
            _realUserService = new RealUserService();
            _cachedUserData = new Dictionary<string, DataSet>();
            _actionLog = new Dictionary<int, string>();
        }

        public DataTable GetRoles()
        {
            Console.WriteLine("Proxy: Logging GetRoles call");
            return _realUserService.GetRoles();
        }

        public DataSet GetUsers(string filterByRole = null)
        {
            string cacheKey = filterByRole ?? "all";

            // Check if data is in cache
            if (_cachedUserData.ContainsKey(cacheKey))
            {
                Console.WriteLine($"Proxy: Returning cached user data for filter: {cacheKey}");
                return _cachedUserData[cacheKey];
            }

            // Get fresh data if not in cache
            Console.WriteLine($"Proxy: Getting fresh user data for filter: {cacheKey}");
            DataSet result = _realUserService.GetUsers(filterByRole);

            // Cache the results
            _cachedUserData[cacheKey] = result;

            return result;
        }

        public void PromoteUser(int userID, string newRole)
        {
            // Log the action
            _actionLog[userID] = $"Promoted to {newRole} at {DateTime.Now}";

            // Clear cache as data will change
            _cachedUserData.Clear();

            // Authorization check example
            if (IsCurrentUserAuthorized("Admin"))
            {
                Console.WriteLine($"Proxy: Authorized promotion for UserID {userID}");
                _realUserService.PromoteUser(userID, newRole);
            }
            else
            {
                throw new UnauthorizedAccessException("You must be an administrator to promote users.");
            }
        }

        public bool DeleteUser(int userId)
        {
            // Log the action
            _actionLog[userId] = $"Deleted at {DateTime.Now}";

            // Clear cache as data will change
            _cachedUserData.Clear();

            // Authorization check example
            if (IsCurrentUserAuthorized("Admin") || IsCurrentUserAuthorized("HR"))
            {
                Console.WriteLine($"Proxy: Authorized deletion for UserID {userId}");
                return _realUserService.DeleteUser(userId);
            }
            else
            {
                throw new UnauthorizedAccessException("You must be an administrator or HR to delete users.");
            }
        }

        public void ApproveUser(int userID)
        {
            // Log the action
            _actionLog[userID] = $"Approved at {DateTime.Now}";

            // Clear cache as data will change
            _cachedUserData.Clear();

            // Authorization check example
            if (IsCurrentUserAuthorized("Admin") || IsCurrentUserAuthorized("HR"))
            {
                Console.WriteLine($"Proxy: Authorized approval for UserID {userID}");
                _realUserService.ApproveUser(userID);
            }
            else
            {
                throw new UnauthorizedAccessException("You must be an administrator or HR to approve users.");
            }
        }

        // Helper method to check user authorization
        private bool IsCurrentUserAuthorized(string requiredRole)
        {
            string currentUserRole = GetCurrentUserRole();
            return currentUserRole == requiredRole;
        }

        private string GetCurrentUserRole()
        {
            return "Admin"; 
        }

        // Additional method to view the action log
        public Dictionary<int, string> GetActionLog()
        {
            return new Dictionary<int, string>(_actionLog);
        }

    }
}
