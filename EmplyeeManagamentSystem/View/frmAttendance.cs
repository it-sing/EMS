using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EmployeeManagamentSystem.Repositories;
using EmployeeManagamentSystem.Services;
using EmployeeManagamentSystem.Service;
using DBProgrammingDemo9;
using System.Data;

namespace EmployeeManagamentSystem
{
    public partial class frmAttendance : Form
    {
        private HttpListener httpListener;
        private string hostAddress = "172.20.10.4";
        private int port = 5000;
        private bool isFormClosing = false;

        int userID = Util.UIUtilities.CurrentUserID;
        private readonly AttendanceService _attendanceService;

        public frmAttendance()
        {
            InitializeComponent();
            _attendanceService = new AttendanceService();

            if (pictureBoxQRCode != null)
            {
                pictureBoxQRCode.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBoxQRCode.BorderStyle = BorderStyle.FixedSingle;
                pictureBoxQRCode.BackColor = Color.White;
            }

        }

        private void frmAttendance_Load(object sender, EventArgs e)
        {
            // Populate months and years
            PopulateComboBoxes();

            int employeeID = _attendanceService.GetEmployeeId(userID);
            if (employeeID == 0)
            {
                MessageBox.Show("Please update your profile first before scan attendance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            string employeeName = _attendanceService.GetEmployeeName(employeeID);
            txtName.Text = employeeName;

            string qrData = $"http://{hostAddress}:{port}/checkin/?empId={employeeID}";

            try
            {
                Bitmap qrCodeBitmap = GenerateQRCode(qrData);
                if (qrCodeBitmap != null)
                {
                    pictureBoxQRCode.Image = qrCodeBitmap;
                }
                else
                {
                    MessageBox.Show("Failed to generate QR code - bitmap is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                StartHttpServer();

                // 🔽 Set selected month and year to current month and year
                int currentMonth = DateTime.Now.Month;
                int currentYear = DateTime.Now.Year;

                cmbMonth.SelectedIndex = currentMonth; // Index 1-12
                cmbYear.SelectedItem = currentYear.ToString();

                // 🔽 Load attendance data for current month and year
                LoadAttendanceData(employeeID, currentMonth, currentYear);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateComboBoxes()
        {
            cmbMonth.Items.Clear();
            cmbMonth.Items.Add(" "); // Null option
            for (int i = 1; i <= 12; i++)
            {
                cmbMonth.Items.Add(new DateTime(2000, i, 1).ToString("MMMM"));
            }

            cmbYear.Items.Clear();
            cmbYear.Items.Add(" "); // Null option
            int currentYear = DateTime.Now.Year;
            for (int y = currentYear; y >= currentYear - 5; y--)
            {
                cmbYear.Items.Add(y.ToString());
            }

            DateTime lastMonthDate = DateTime.Now.AddMonths(0);
            int lastMonth = lastMonthDate.Month;
            int lastYear = lastMonthDate.Year;

            cmbMonth.SelectedIndex = 0; // Default to blank initially
            cmbYear.SelectedIndex = 0;

        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyAttendanceFilter();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyAttendanceFilter();
        }

        private void ApplyAttendanceFilter()
        {
            int selectedMonth = (cmbMonth.SelectedIndex > 0) ? cmbMonth.SelectedIndex : 0;
            int selectedYear = (cmbYear.SelectedIndex > 0) ? Convert.ToInt32(cmbYear.SelectedItem.ToString()) : 0;

            int employeeID = _attendanceService.GetEmployeeId(userID);

            if (selectedMonth > 0 && selectedYear > 0)
            {
                LoadAttendanceData(employeeID, selectedMonth, selectedYear);
            }
            else if (selectedMonth > 0)
            {
                LoadAttendanceData(employeeID, selectedMonth, DateTime.Now.Year);
            }
            else if (selectedYear > 0)
            {
                LoadAttendanceData(employeeID, 0, selectedYear);
            }
            else
            {
                dgvAttendance.DataSource = null; // Clear if neither is selected
            }
        }

        private void LoadAttendanceData(int empId, int month = 0, int year = 0)
        {
            var attendanceData = _attendanceService.GetAttendanceData(empId, month, year);
            if (dgvAttendance != null)
            {
                dgvAttendance.DataSource = attendanceData;
            }
        }

        private Bitmap GenerateQRCode(string data)
        {
            try
            {
                MultiFormatWriter writer = new MultiFormatWriter();
                BitMatrix bitMatrix = writer.encode(data, BarcodeFormat.QR_CODE, 200, 200, null);

                int width = bitMatrix.Width;
                int height = bitMatrix.Height;
                Bitmap bitmap = new Bitmap(width, height);

                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.White);
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            g.FillRectangle(bitMatrix[x, y] ? Brushes.Black : Brushes.White, x, y, 1, 1);
                        }
                    }
                }

                return bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("QR Code generation error: " + ex.Message, "Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void FrmAttendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            isFormClosing = true;
            StopHttpServer();
        }

        private void StopHttpServer()
        {
            if (httpListener != null && httpListener.IsListening)
            {
                try
                {
                    httpListener.Stop();
                    httpListener.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error stopping server: " + ex.Message);
                }
            }
        }

        private void StartHttpServer()
        {
            if (httpListener != null && httpListener.IsListening) return;

            try
            {
                TryStartServer("+");
            }
            catch
            {
                try
                {
                    TryStartServer(hostAddress);
                }
                catch
                {
                    try
                    {
                        TryStartServer("localhost");
                        MessageBox.Show("Warning: Server started on localhost only. This won't be accessible from phones.",
                            "Limited Access", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception finalEx)
                    {
                        MessageBox.Show($"Failed to start HTTP server: {finalEx.Message}\n\n" +
                                         "Run the application as Administrator or run: netsh http add urlacl url=http://{hostAddress}:{port}/checkin/ user=YourUserNameHere",
                                         "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void TryStartServer(string host)
        {
            httpListener = new HttpListener();
            string prefix = $"http://{host}:{port}/checkin/";
            httpListener.Prefixes.Add(prefix);
            httpListener.Start();
            httpListener.BeginGetContext(new AsyncCallback(OnRequestReceived), httpListener);
        }

        private void OnRequestReceived(IAsyncResult result)
        {
            var listener = (HttpListener)result.AsyncState;

            try
            {
                if (isFormClosing) return;

                HttpListenerContext context = listener.EndGetContext(result);
                if (!isFormClosing)
                    listener.BeginGetContext(new AsyncCallback(OnRequestReceived), listener);

                Task.Run(() => HandleRequest(context));
            }
            catch (ObjectDisposedException) { }
            catch (Exception ex)
            {
                SafeInvoke(() => MessageBox.Show("HTTP Server Error: " + ex.Message));
            }
        }

        private void SafeInvoke(Action action)
        {
            try
            {
                if (this.IsDisposed || isFormClosing) return;

                if (this.InvokeRequired)
                {
                    this.Invoke(action);
                }
                else
                {
                    action();
                }
            }
            catch { }
        }

        private void HandleRequest(HttpListenerContext context)
        {
            try
            {
                string empIdStr = context.Request.QueryString["empId"];
                string responseString = "";
                int statusCode = 200;

                if (int.TryParse(empIdStr, out int empId))
                {
                    try
                    {
                        string status = _attendanceService.CheckInOut(empId);

                        switch (status)
                        {
                            case "CHECKIN":
                                responseString = $"Employee {empId} checked in successfully!";
                                break;
                            case "CHECKOUT":
                                responseString = $"Employee {empId} checked out successfully!";
                                break;
                            case "COMPLETED":
                                responseString = $"Employee {empId} has already completed check-in/out for today.";
                                // Display message in the form
                                SafeInvoke(() =>
                                {
                                    MessageBox.Show($"Employee {empId} has already completed check-in and check-out for today.",
                                                   "Already Processed",
                                                   MessageBoxButtons.OK,
                                                   MessageBoxIcon.Information);
                                });
                                break;
                            default:
                                responseString = $"Employee {empId} attendance processed.";
                                break;
                        }

                        SafeInvoke(() =>
                        {
                            int selectedMonth = (cmbMonth.SelectedIndex > 0) ? cmbMonth.SelectedIndex : DateTime.Now.Month;
                            int selectedYear = (cmbYear.SelectedIndex > 0) ? Convert.ToInt32(cmbYear.SelectedItem?.ToString()) : DateTime.Now.Year;
                            LoadAttendanceData(empId, selectedMonth, selectedYear);
                        });
                    }
                    catch (Exception ex)
                    {
                        responseString = ex.Message;
                        statusCode = 400;

                        // Display error in the form
                        SafeInvoke(() =>
                        {
                            MessageBox.Show("Attendance Error: " + ex.Message,
                                           "Error",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Error);
                        });
                    }
                }
                else
                {
                    responseString = "Invalid or missing empId.";
                    statusCode = 400;
                }

                // Send HTTP response
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = statusCode;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.OutputStream.Close();
            }
            catch (Exception ex)
            {
                SafeInvoke(() =>
                {
                    MessageBox.Show("HandleRequest Error: " + ex.Message);
                });
                try
                {
                    if (!isFormClosing)
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/plain";
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes("Server error occurred");
                        context.Response.ContentLength64 = buffer.Length;
                        context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                        context.Response.OutputStream.Close();
                    }
                }
                catch { }
            }
        }

    }
}
