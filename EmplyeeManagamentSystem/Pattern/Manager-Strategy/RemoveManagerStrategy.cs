using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Pattern.Manager_Strategy
{
    public class RemoveManagerStrategy : IManagerAssignmentStrategy
    {
        public int AssignManager(DepartmentService departmentService, int departmentID, int? managerID)
        {
            return departmentService.AssignManager(departmentID, null);
        }
    }
}
