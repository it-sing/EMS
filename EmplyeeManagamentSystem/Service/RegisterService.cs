using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagamentSystem.Repository;
using EmployeeManagamentSystem.Util;

namespace EmployeeManagamentSystem.Service
{
    public class RegisterService
    {
        private UserRepository _userRepository;
        private const int DEFAULT_ROLE_ID = 5;

        public RegisterService()
        {
            _userRepository = new UserRepository();
        }

        public bool RegisterUser(string username, string password, string email)
        {
            DateTime createdAt = DateTime.Now;

            int rowsAffected = _userRepository.CreateUser(username, password, email, DEFAULT_ROLE_ID, createdAt);

            if (rowsAffected == 1)
            {
                int userId = _userRepository.GetUserId(username);
                UIUtilities.CurrentUserID = userId;
                return true;
            }
            MessageBox.Show("User creation failed");
            return false;
        }

    }
}
