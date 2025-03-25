using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagamentSystem.Repository;

namespace EmployeeManagamentSystem.Service
{
    public class LoginService
    {
        private UserRepository _userRepository;

        public LoginService()
        {
            _userRepository = new UserRepository();
        }

        public bool ValidateUserCredentials(string username, string password, out int userID, out string role)
        {
            DataTable dt = _userRepository.GetUserByUsernameAndPassword(username, password);
            if (dt.Rows.Count == 1)
            {
                userID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                role = _userRepository.GetUserRole(userID);
                return true;
            }
            else
            {
                userID = 0;
                role = string.Empty;
                return false;
            }
        }
    }
}
