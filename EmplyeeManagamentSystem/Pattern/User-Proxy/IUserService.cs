using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Service
{
    public interface IUserService
    {
        DataTable GetRoles();
        DataSet GetUsers(string filterByRole = null);
        void PromoteUser(int userID, string newRole);
        bool DeleteUser(int userId);
        void ApproveUser(int userID);
    }
}
