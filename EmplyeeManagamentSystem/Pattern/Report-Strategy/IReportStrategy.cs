using EmployeeManagamentSystem.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Pattern.Report_Strategy
{
    public interface IReportStrategy
    {
        (string TextReport, string FilePath) GenerateReport(List<Employee> employees);
    }
}
