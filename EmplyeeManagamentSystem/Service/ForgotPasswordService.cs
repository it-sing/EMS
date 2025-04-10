using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagamentSystem.Repository;

namespace EmployeeManagamentSystem.Service
{
    
    public class ForgotPasswordService
    {

        private readonly UserRepository userRepository;

        public ForgotPasswordService()
        {
            userRepository = new UserRepository();
        }
        public int ResetPassword(string email, string newPassword)
        {
            return userRepository.ResetPassword(email, newPassword);
        }

    }
}
