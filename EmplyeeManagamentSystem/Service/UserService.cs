using System;
using System.Data;
using System.Diagnostics;
using DBProgrammingDemo9;
using EmployeeManagamentSystem.Pattern;
using EmployeeManagamentSystem.Repository;
using EmployeeManagamentSystem.Util;
using EmployeeManagementSystem.Pattern;

namespace EmployeeManagamentSystem
{
    public class UserService
    {
        private UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }


        // for user management
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
            if (rowsAffected > 0)
            {
                // Notify UI to refresh or show success message
            }
            else
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
                // Handle and log exception
                throw new Exception("Failed to delete user.", ex);
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

        // 1. Factory Method for Creating User Actions update profile
        public bool ExecuteUserAction(string actionType, string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate, int userId)
        {
            var userAction = UserActionFactory.GetUserAction(actionType);
            return userAction.Execute(_userRepository, firstName, lastName, email, dateOfBirth, employmentDate, userId);
        }
        public DataTable GetUserDetails(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

    }
}
