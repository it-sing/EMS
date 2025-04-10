using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagamentSystem.View;

namespace EmployeeManagamentSystem.Pattern.Login
{
    // Form Factory (Factory Pattern)
    public class LoginFormFactory
    {
        public static Form CreateLoginForm()
        {
            return new frmLogin();
        }

        public static Form CreateRegisterForm()
        {
            return new frmRegister();
        }

        public static Form CreateEmployeeSystemManagerForm()
        {
            return new frmEmployeeSystemManager();
        }
        public static Form CreateForgotPasswordForm()
        {
            return new frmForgotPassword();
        }
    }
}
