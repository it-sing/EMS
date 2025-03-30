using System.Data;
using DBProgrammingDemo9;

namespace EmployeeManagamentSystem.Util
{
    //create enum for permissions
    /** RoleID	RoleName	Description	Permission
1	Admin	Administrator with full access	ALL
2	Manager	Manager with managerial access	VIEW_EMPLOYEES, ADD_EMPLOYEE, EDIT_EMPLOYEE, DELETE_EMPLOYEE
3	Employee	Regular Employee	VIEW_SELF, EDIT_SELF
   **/
    public enum Permission
    {
        ALL,
        VIEW_EMPLOYEES,
        ADD_EMPLOYEE,
        EDIT_EMPLOYEE,
        DELETE_EMPLOYEE,
        VIEW_SELF,
        EDIT_SELF,
        NONE
    }
    public class Authorization
    {
        private static bool showEmployeeEditorForm = false;
        private static bool showDepartmentEditorForm = false;
        private static bool showEditProfileForm = true;
        private static bool showManagerForm = false;
        private static bool showSalaryForm = false;
        private static bool showUserForm = false;
        private static bool showAttendanceForm = false;
        private static bool showReportForm = false;
        private static bool showNotificationForm = false;


        public static void SetFormAccess(Permission permission)
        {

            switch (permission)
            {                
                case Permission.ALL:
                    showEmployeeEditorForm = true;
                    showDepartmentEditorForm = true;
                    showEditProfileForm = true;
                    showManagerForm = true;
                    showSalaryForm = true;
                    showUserForm = true;
                    showAttendanceForm = true;
                    showReportForm = true;
                    showNotificationForm = true;

                    break;

                case Permission.ADD_EMPLOYEE:
                    //show employee editor form
                    showEmployeeEditorForm = true;
                    break;
                case Permission.EDIT_EMPLOYEE:
                    //show employee editor form
                    showEmployeeEditorForm = true;
                    break;
                case Permission.DELETE_EMPLOYEE:
                    //show employee editor form
                    showEditProfileForm = true;
                    break;
                case Permission.VIEW_SELF:
                    //show employee viewer form
                    showEditProfileForm = true;
                    break;
                case Permission.EDIT_SELF:
                    showEditProfileForm = true;
                    break;
                default:

                    break;
            }

        }

        public static string[]? GetCurrentUserPermission()
        {
            int currentUserId = UIUtilities.CurrentUserID;

            //MessageBox.Show(currentUserId.ToString());


            //get role from database for current user
            string currentRole = $"SELECT Role FROM Users WHERE UserID = {currentUserId}";
            //get role id value from database
            int roleIdValue = (int)DataAccess.GetValue(currentRole);
            //MessageBox.Show(currentRole.ToString());

            //get role from database for roleid value
            string roleSql = $"SELECT Permission FROM Roles WHERE RoleID = {roleIdValue}";
            DataTable dtRoles = DataAccess.GetData(roleSql);
            //MessageBox.Show(roleSql.ToString());

            if (dtRoles.Rows.Count > 0)
            {
                DataRow drRoles = dtRoles.Rows[0];
                string? permission = drRoles["Permission"]?.ToString();

                //MessageBox.Show(permission.ToString());
                return permission?.Split(',');
            }
            return null;

        }
        public static void SetFormAccessCurrentUser()
        {
            ResetPermissions();

            string[]? permissions = GetCurrentUserPermission();

            if (permissions != null)
            {
                foreach (string permission in permissions)
                {
                    Permission currentPermission = (Permission)Enum.Parse(typeof(Permission), permission);
                    SetFormAccess(currentPermission);
                }
            }
        }

        private static void ResetPermissions()
        {
            showEmployeeEditorForm = false;
            showDepartmentEditorForm = false;
            showEditProfileForm = false;
            showManagerForm = false;
            showSalaryForm = false;
            showUserForm = false;
            showAttendanceForm = false;
            showReportForm = false;
            showNotificationForm = false;
        }

        //return all forms that should be shown
        public static bool ShowEmployeeEditorForm()
        {
            return showEmployeeEditorForm;
        }

        public static bool ShowDepartmentEditorForm()
        {
            return showDepartmentEditorForm;
        }
        public static bool ShowEditProfileForm()
        {
            return showEditProfileForm;
        }

        public static bool ShowManagerForm()
        {
            return showManagerForm;
        }

        public static bool ShowSalaryForm()
        {
            return showSalaryForm;
        }
        public static bool ShowUserForm()
        {
            return showUserForm;
        }
        public static bool ShowAttendanceForm()
        {
            return showAttendanceForm;
        }
        public static bool ShowReportForm()
        {
            return showReportForm;
        }

    }
}
