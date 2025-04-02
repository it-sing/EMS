using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Pattern.Salary
{
    public class FlatTaxStrategy : ITaxCalculationStrategy
    {
        public decimal CalculateTax(decimal salaryBeforeTax)
        {
            const decimal FLAT_TAX_RATE = 0.1m;
            return salaryBeforeTax * FLAT_TAX_RATE;
        }
    }

}
