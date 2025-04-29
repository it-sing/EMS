using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagamentSystem.Util;

namespace EmployeeManagamentSystem.Service
{
    public class SessionService
    {
        public void SetCurrentUser(int userId)
        {
            UIUtilities.CurrentUserID = userId;
        }
    }
}
