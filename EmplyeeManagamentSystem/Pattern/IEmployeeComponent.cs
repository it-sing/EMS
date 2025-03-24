using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagamentSystem.Service;
using System.Windows.Forms;

namespace EmployeeManagamentSystem.Pattern
{
    //. Add, Edit, Delete, and View Employee Details
    //Design Patterns Used:
    //Composite Pattern – To manage employees as part of larger departments or teams.
    //Command Pattern – To handle operations like adding, editing, and deleting employees in an undoable way.

    //Composite Pattern (Managing Employees in Departments)
    public interface IEmployeeComponent
    {
        void ShowDetails();
    }

    // Leaf (Individual Employee)
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

    // Composite (Department)
    public class Department : IEmployeeComponent
    {
        private string _name;
        private List<IEmployeeComponent> _employees = new List<IEmployeeComponent>();

        public Department(string name)
        {
            _name = name;
        }

        public void Add(IEmployeeComponent employee)
        {
            _employees.Add(employee);
        }

        public void Remove(IEmployeeComponent employee)
        {
            _employees.Remove(employee);
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Department: {_name}");
            foreach (var employee in _employees)
            {
                employee.ShowDetails();
            }
        }
    }
}
