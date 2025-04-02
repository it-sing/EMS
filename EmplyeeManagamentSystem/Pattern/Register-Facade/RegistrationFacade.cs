using EmployeeManagamentSystem.Service;
using EmployeeManagamentSystem.Repository;

namespace EmployeeManagamentSystem
{
    public class RegistrationFacade
    {
        private readonly RegisterService _registerService;
        private readonly UserRepository _userRepository;

        public RegistrationFacade(RegisterService registerService, UserRepository userRepository)
        {
            _registerService = registerService;
            _userRepository = userRepository;
        }

        public bool ValidateAndRegisterUser(string username, string password, string email)
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

            return _registerService.RegisterUser(username, password, email);
        }
    }
}
