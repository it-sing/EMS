using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagamentSystem.Service;

namespace EmployeeManagamentSystem.Pattern.Register_Facade
{
    public class RegistrationFacade
    {
        private UserValidationService _validationService;
        private UserRegistrationService _userRegistrationService;
        private SessionService _sessionService;

        public RegistrationFacade()
        {
            _validationService = new UserValidationService();
            _userRegistrationService = new UserRegistrationService();
            _sessionService = new SessionService();
        }

        public bool ValidateUser(string username, string password, string email)
        {
            return _validationService.Validate(username, password, email);
        }

        public void CreateUser(string username, string password, string email)
        {
            int rowsAffected = _userRegistrationService.CreateUser(username, password, email);
            if (rowsAffected == 1)
            {
                int userId = _userRegistrationService.GetUserId(username);
                _sessionService.SetCurrentUser(userId);
            }
            else
            {
                MessageBox.Show("User creation failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
