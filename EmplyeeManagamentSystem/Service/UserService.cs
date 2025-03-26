using System;
using System.Data;
using System.Diagnostics;
using DBProgrammingDemo9;
using EmployeeManagamentSystem.Repository;
using EmployeeManagamentSystem.Util;

namespace EmployeeManagamentSystem
{
    public class UserService
    {
        private UserRepository _userRepository;
        private const int DEFAULT_ROLE_ID = 4;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public UserService(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
       
        public DataTable GetRoles()
        {
            return _userRepository.GetRoles();
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
                MessageBox.Show("Username already exists.");
                return false;
            }
            if (_userRepository.IsUserEmailExists(email))
            {
                MessageBox.Show("Email already exists.");
                return false;
            }

            int roleID = 4;
            DateTime createdAt = DateTime.Now;

            int rowsAffected = _userRepository.CreateUser(username, password, email, roleID, createdAt);

            if (rowsAffected == 1)
            {
                int userId = _userRepository.GetUserId(username);
                UIUtilities.CurrentUserID = userId;
                return true;
            }
            MessageBox.Show("User creation failed");
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
