using System;
using System.Data;
using System.Diagnostics;
using DBProgrammingDemo9;
using EmployeeManagamentSystem.Pattern;
using EmployeeManagamentSystem.Pattern.Profile__Factory;
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

        // 1. Factory Method for Creating User Actions update profile
        public int ExecuteUserAction(string actionType, string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate, int userId)
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
