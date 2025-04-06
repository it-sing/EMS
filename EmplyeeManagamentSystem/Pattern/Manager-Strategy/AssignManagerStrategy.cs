using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Pattern.Manager_Strategy
{
    public class AssignManagerStrategy : IManagerAssignmentStrategy
    {
        public int AssignManager(DepartmentService departmentService, int departmentID, int? managerID)
        {
            if (managerID == null)
            {
                MessageBox.Show("Please select a manager.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return departmentService.AssignManager(departmentID, managerID);
        }
    }


}
