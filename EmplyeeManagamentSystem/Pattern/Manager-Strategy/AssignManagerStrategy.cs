using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Pattern.Manager_Strategy
{
    public class AssignManagerStrategy : IManagerAssignmentStrategy
    {
        public bool AssignManager(DepartmentService departmentService, int departmentID, int? managerID)
        {
            if (managerID == null)
            {
                MessageBox.Show("Please select a manager.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return departmentService.AssignManager(departmentID, managerID);
        }
    }

    public class RemoveManagerStrategy : IManagerAssignmentStrategy
    {
        public bool AssignManager(DepartmentService departmentService, int departmentID, int? managerID)
        {
            return departmentService.AssignManager(departmentID, null);
        }
    }

}
