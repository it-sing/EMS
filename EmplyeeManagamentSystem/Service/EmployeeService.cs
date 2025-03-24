using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagamentSystem.Service
{
    // Component
    public interface IEmployeeComponent
    {
        void ShowDetails();
    }

    public class Employee : IEmployeeComponent
    {
        private string _name;
        private string _position;

        public Employee(string name, string position)
        {
            _name = name;
            _position = position;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Employee: {_name}, Position: {_position}");
        }
    }
}
