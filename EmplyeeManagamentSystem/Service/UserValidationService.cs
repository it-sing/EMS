using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagamentSystem.Repository;

namespace EmployeeManagamentSystem.Service
{
    public class UserValidationService
    {
        private UserRepository _userRepository;

        public UserValidationService()
        {
            _userRepository = new UserRepository();
        }

        public bool Validate(string username, string password, string email)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_userRepository.IsUserNameExists(username))
            {
                MessageBox.Show("Username already exists.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_userRepository.IsUserEmailExists(email))
            {
                MessageBox.Show("Email already exists.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }

}
