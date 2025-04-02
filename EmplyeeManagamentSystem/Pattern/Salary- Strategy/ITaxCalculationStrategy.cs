using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Pattern.Salary
{
    // ITaxCalculationStrategy.cs
    public interface ITaxCalculationStrategy
    {
        decimal CalculateTax(decimal salaryBeforeTax);
    }

}
