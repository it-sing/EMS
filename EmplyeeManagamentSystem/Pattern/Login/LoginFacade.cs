using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagamentSystem.Service;
using EmployeeManagamentSystem.Util;

namespace EmployeeManagamentSystem.Pattern.Login
{
    // Login Facade (Facade Pattern)s
    public class LoginFacade
    {
        private readonly LoginService _loginService;

        public LoginFacade(LoginService loginService)
        {
            _loginService = loginService;
        }

        public bool ProcessLogin(string username, string password, out int userId, out string role, out string message)
        {
            try
            {
                if (_loginService.ValidateUserCredentials(username, password, out userId, out role))
                {
                    if (role == "5")
                    {
                        message = "Please wait for admin approval.";
                        return false;
                    }
                    UIUtilities.CurrentUserID = userId;
                    UIUtilities.CurrentUserName = username;
                    UIUtilities.CurrentUserRole = role;
                    message = "Login successful";
                    return true;
                }
                message = "Invalid username or password.";
                userId = 0;
                role = string.Empty;
                return false;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                userId = 0;
                role = string.Empty;
                return false;
            }
        }
    }
}
