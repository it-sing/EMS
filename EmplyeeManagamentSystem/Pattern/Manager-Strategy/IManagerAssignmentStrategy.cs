using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Pattern.Manager_Strategy
{
    public interface IManagerAssignmentStrategy
    {
        int AssignManager(DepartmentService departmentService, int departmentID, int? managerID);
    }
}
