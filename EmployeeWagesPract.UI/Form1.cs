using EmployeeWagesPract.Core;
using EmployeeWagesPract.Core.Interfaces;

namespace EmployeeWagesPract.UI
{
    public partial class Form1 : Form
    {
        private readonly IEmployeeService _service;

        public Form1(IEmployeeService service)
        {
            _service = service;
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            label5.Cursor = Cursors.Hand;
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Cursor = Cursors.Hand;
        }

        protected void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            NewUserForm newUserForm = new(_service);
            newUserForm.Show();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Visible = true;
            guna2GradientButton2.Text = "Обновить";
            guna2DataGridView1.Rows.Clear();

            var employees = _service.Get();
            foreach (var employee in employees)
            {
                guna2DataGridView1.Rows.Add(employee.Surname, employee.WageAfterTaxes, employee.WageBeforeTaxes);
            }
        }

        private void guna2DataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            var deletedEmployee = new Employee
            {
                Surname = (string)e.Row.Cells[0].Value,
                WageAfterTaxes = (int)e.Row.Cells[1].Value
            };

            _service.Delete(deletedEmployee);
        }
    }
}