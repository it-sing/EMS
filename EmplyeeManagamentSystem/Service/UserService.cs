using System;
using System.Data;
using EmployeeManagamentSystem.Repository;

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
        public bool CreateAccount(string username, string password, string email)
        {
            // Check if the username already exists
            if (_userRepository.IsUserNameExists(username))
            {
                return false;
            }

            // Hash the password (this could be done using a stronger hashing algorithm like bcrypt)
            string hashedPassword = HashPassword(password);

            // Create the user in the database
            int userId = _userRepository.CreateUser(username, hashedPassword, email, 4, DateTime.Now);

            return userId > 0;
        }
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes); // You can use a stronger hash like bcrypt in production
            }
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
