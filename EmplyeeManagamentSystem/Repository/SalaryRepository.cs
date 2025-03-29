﻿using System;
using System.Data;
using DBProgrammingDemo9;
using System.Data.SqlClient;

namespace EmployeeManagamentSystem.Repositories
{
    public class SalaryRepository
    {
        public DataTable GetEmployees()
        {
            string sql = @"SELECT EmployeeID, 
                                  CONCAT(FirstName, ' ', LastName) AS FullName
                           FROM Employees";
            return DataAccess.GetData(sql);
        }

        public DataTable GetSalaryDetails(int employeeID)
        {
            string sql = @"
                SELECT EmployeeID,
                       CONCAT(FirstName, ' ', LastName) AS FullName,
                       SalaryBeforeTax,
                       TaxAmount,
                       SalaryAfterTax
                FROM Employees
                WHERE EmployeeID = @EmployeeID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EmployeeID", employeeID)
            };
            return DataAccess.GetByParameter(sql, parameters);
        }

        public int UpdateSalary(int employeeID, decimal salaryBeforeTax, decimal taxAmount)
        {
            string sql = $@"
                UPDATE Employees
                SET
                    SalaryBeforeTax = {salaryBeforeTax},
                    TaxAmount = {taxAmount}
                WHERE EmployeeID = {employeeID}";

            return DataAccess.Send(sql);
        }

    }
}
