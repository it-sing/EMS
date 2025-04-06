using EmployeeManagamentSystem.Pattern.Salary; // Ensure this is added
using EmployeeManagamentSystem.Services;
using EmployeeManagamentSystem.Repositories;
using System.Data;using EmployeeManagamentSystem.Util;

namespace EmployeeManagamentSystem
{
    public partial class frmSalaries : Form
    {
        private int currentEmployeeID;
        private readonly SalaryService _salaryService;

        public frmSalaries()
        {
            InitializeComponent();
            _salaryService = new SalaryService(new SalaryRepository());
        }

        private void frmSalaries_Load(object sender, EventArgs e)
        {
            try
            {
                LoadEmployees();
                LoadSalaries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEmployees()
        {
            try
            {
                DataTable dtEmployees = _salaryService.GetEmployees();
                UIUtilities.BindComboBox(cboEmployees, dtEmployees, "FullName", "EmployeeID");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSalaries()
        {
            try
            {
                if (cboEmployees.SelectedIndex == -1 || cboEmployees.SelectedValue == DBNull.Value)
                {
                    return;
                }

                currentEmployeeID = Convert.ToInt32(cboEmployees.SelectedValue);
                DataTable dtEmployees = _salaryService.GetSalaryDetails(currentEmployeeID);

                if (dtEmployees.Rows.Count == 1)
                {
                    DataRow selectedEmployee = dtEmployees.Rows[0];
                    decimal salaryBeforeTax = selectedEmployee["SalaryBeforeTax"] != DBNull.Value ? Convert.ToDecimal(selectedEmployee["SalaryBeforeTax"]) : 0;
                    decimal taxAmount = selectedEmployee["TaxAmount"] != DBNull.Value ? Convert.ToDecimal(selectedEmployee["TaxAmount"]) : 0;
                    decimal salaryAfterTax = selectedEmployee["SalaryAfterTax"] != DBNull.Value ? Convert.ToDecimal(selectedEmployee["SalaryAfterTax"]) : 0;

                    txtSalaryAfterTax.Text = salaryAfterTax.ToString("C");
                    txtSalaryBeforeTax.Text = salaryBeforeTax.ToString("C");
                    txtTaxAmount.Text = taxAmount.ToString("C");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboEmployees.SelectedIndex == -1 || cboEmployees.SelectedValue == DBNull.Value)
                {
                    return;
                }
                currentEmployeeID = Convert.ToInt32(cboEmployees.SelectedValue);
                LoadSalaries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                try
                {
                    if (!decimal.TryParse(txtSalaryBeforeTax.Text, out decimal salaryBeforeTax))
                    {
                        MessageBox.Show("Invalid salary input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Instantiate the tax strategy here
                    ITaxCalculationStrategy taxStrategy = new FlatTaxStrategy(); // Use Flat Tax Strategy

                    int salaryUpdated = _salaryService.UpdateSalary(currentEmployeeID, salaryBeforeTax, taxStrategy);

                    if (salaryUpdated > 0)
                    {
                        //MessageBox.Show("Salary updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSalaries();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update salary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
