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

        private void Exit_Click(object sender, EventArgs e) => Close();

        private void Minimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void MouseMove_Handle(object sender, MouseEventArgs e) => exitButton.Cursor = Cursors.Hand;

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

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для удаления выделите строку и нажмите на кнопку \"Delete\"", "Подсказка");
        }
    }
}