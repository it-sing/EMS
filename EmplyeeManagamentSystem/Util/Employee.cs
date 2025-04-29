using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Util
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string? FirstName { get; set; } // Nullable
        public string? LastName { get; set; } // Nullable
        public string? Email { get; set; } // Nullable
        public DateTime? DateOfBirth { get; set; } // Already nullable
        public int DepartmentID { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int? UserID { get; set; } // Already nullable
        public decimal SalaryBeforeTax { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal SalaryAfterTax { get; set; }
        public bool IsDeleted { get; set; }
        public string? DepartmentName { get; set; } // Nullable
    }
}
