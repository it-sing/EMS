using System;
using System.Data;
using System.Diagnostics;
using EmployeeManagamentSystem.Repository;
using EmployeeManagamentSystem.Util;

namespace EmployeeManagamentSystem
{
    public class UserService
    {
        private UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public UserService(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public DataTable GetUserDetails(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public bool SaveUserChanges(int userId, string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate)
        {
            int result = _userRepository.SaveEmployeeChanges(userId, firstName, lastName, email, dateOfBirth, employmentDate);
            return result > 0;
        }

        public bool CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate, int userId)
        {
            int result = _userRepository.CreateEmployee(firstName, lastName, email, dateOfBirth, employmentDate, userId);
            return result > 0;
        }
        public bool RegisterUser(string username, string password, string email)
        {
            if (_userRepository.IsUserNameExists(username))
            {
                return false; // Username already exists
            }

            DateTime createdAt = DateTime.Now;
            int roleID = 4; // Default role for new users
            int userId = _userRepository.CreateUser(username, password, email, roleID, createdAt);

            if (userId > 0)
            {
                UIUtilities.CurrentUserID = userId;
                return true;
            }

            return false;
        }

        public DataSet GetUsers(string filterByRole = null)
        {
            return _userRepository.GetUsers(filterByRole);
        }

        public void PromoteUser(int userID, string newRole)
        {
            int rowsAffected = _userRepository.PromoteUser(userID, newRole);
            if (rowsAffected > 0)
            {
                // Notify UI to refresh or show success message
            }
            else
            {
                throw new Exception("Failed to promote user.");
            }
        }

        public void DeleteUser(int userID)
        {
            int rowsAffected = _userRepository.DeleteUser(userID);
            if (rowsAffected > 0)
            {
                // Notify UI to refresh or show success message
            }
            else
            {
                throw new Exception("Failed to delete user.");
            }
        }

        public void ApproveUser(int userID)
        {
            int rowsAffected = _userRepository.ApproveUser(userID);
            if (rowsAffected > 0)
            {
                // Notify UI to refresh or show success message
            }
            else
            {
                throw new Exception("Failed to approve user.");
            }
        }
    }
}
