using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Pattern.Salary
{
    // ProgressiveTaxCalculationStrategy.cs
    public class ProgressiveTaxStrategy : ITaxCalculationStrategy
    {
        public decimal CalculateTax(decimal salaryBeforeTax)
        {
            decimal taxAmount = 0;

            if (salaryBeforeTax <= 1000)
            {
                taxAmount = salaryBeforeTax * 0.2m; 
            }
            else if (salaryBeforeTax <= 2000)
            {
                taxAmount = salaryBeforeTax * 0.3m;
            }
            else
            {
                taxAmount = salaryBeforeTax * 0.4m;
            }

            return taxAmount;
        }
    }

}
