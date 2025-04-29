using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagamentSystem.Repository;

namespace EmployeeManagamentSystem.Service
{
    public class UserRegistrationService
    {
        private UserRepository _userRepository;
        private const int DEFAULT_ROLE_ID = 5;

        public UserRegistrationService()
        {
            _userRepository = new UserRepository();
        }

        public int CreateUser(string username, string password, string email)
        {
            DateTime createdAt = DateTime.Now;
            return _userRepository.Create(username, password, email, DEFAULT_ROLE_ID, createdAt);
        }

        public int GetUserId(string username)
        {
            return _userRepository.GetUserId(username);
        }
    }
}
