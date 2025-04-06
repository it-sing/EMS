using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagamentSystem.Repository;

namespace EmployeeManagamentSystem.Pattern.Profile__Factory
{
    // 2. Factory Method for Creating User Actions
    public abstract class UserAction
    {
        public abstract int Execute(UserRepository userRepository, string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate, int userId);
    }

    public class CreateUserAction : UserAction
    {
        public override int Execute(UserRepository userRepository, string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate, int userId)
        {
            return userRepository.CreateEmployee(firstName, lastName, email, dateOfBirth, employmentDate, userId);
        }
    }

    public class UpdateUserAction : UserAction
    {
        public override int  Execute(UserRepository userRepository, string firstName, string lastName, string email, DateTime dateOfBirth, DateTime employmentDate, int userId)
        {
            return userRepository.SaveEmployeeChanges(userId, firstName, lastName, email, dateOfBirth, employmentDate);
        }

    }

    public class UserActionFactory
    {
        public static UserAction GetUserAction(string actionType)
        {
            switch (actionType.ToLower())
            {
                case "create":
                    return new CreateUserAction();
                case "update":
                    return new UpdateUserAction();
                default:
                    throw new InvalidOperationException("Invalid action type.");
            }
        }
    }

}
