using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;

namespace EmployeeManagamentSystem.Pattern
{
    //Command Pattern(Managing Add, Edit, Delete Operations)
    //The Command Pattern encapsulates operations like Add, Edit, and Delete into separate commands, making it easy to undo/redo actions.

    // Command Interface

    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Receiver (Employee Database)
    public class EmployeeDatabase
    {
        private List<string> _employees = new List<string>();

        public void AddEmployee(string name)
        {
            _employees.Add(name);
            Console.WriteLine($"Employee {name} added.");
        }

        public void RemoveEmployee(string name)
        {
            _employees.Remove(name);
            Console.WriteLine($"Employee {name} removed.");
        }

        public void ShowEmployees()
        {
            Console.WriteLine("Current Employees:");
            _employees.ForEach(Console.WriteLine);
        }
    }

    // Concrete Commands
    public class AddEmployeeCommand : ICommand
    {
        private EmployeeDatabase _database;
        private string _employeeName;

        public AddEmployeeCommand(EmployeeDatabase database, string employeeName)
        {
            _database = database;
            _employeeName = employeeName;
        }

        public void Execute()
        {
            _database.AddEmployee(_employeeName);
        }

        public void Undo()
        {
            _database.RemoveEmployee(_employeeName);
        }
    }

    // Invoker
    public class EmployeeManager
    {
        private Stack<ICommand> _commandHistory = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);
        }

        public void UndoLastCommand()
        {
            if (_commandHistory.Count > 0)
            {
                ICommand command = _commandHistory.Pop();
                command.Undo();
            }
        }
    }
}
