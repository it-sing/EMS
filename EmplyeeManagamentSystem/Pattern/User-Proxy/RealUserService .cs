using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagamentSystem.Repository;
using EmployeeManagamentSystem.Service;

namespace EmployeeManagamentSystem.Pattern.User_Proxy
{
    public class RealUserService : IUserService
    {
        private UserRepository _userRepository;

        public RealUserService()
        {
            _userRepository = new UserRepository();
        }

        public DataTable GetRoles()
        {
            return _userRepository.GetRoles();
        }

        public DataSet GetUsers(string filterByRole = null)
        {
            return _userRepository.GetUsers(filterByRole);
        }

        public void PromoteUser(int userID, string newRole)
        {
            int rowsAffected = _userRepository.PromoteUser(userID, newRole);
            if (rowsAffected <= 0)
            {
                throw new Exception("Failed to promote user.");
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                int rowsAffected = _userRepository.DeleteUser(userId);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete user.", ex);
            }
        }

        public void ApproveUser(int userID)
        {
            int rowsAffected = _userRepository.ApproveUser(userID);
            if (rowsAffected <= 0)
            {
                throw new Exception("Failed to approve user.");
            }
        }
    }
}
