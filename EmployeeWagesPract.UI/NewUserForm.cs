using EmployeeWagesPract.Core;
using EmployeeWagesPract.Core.Interfaces;

namespace EmployeeWagesPract.UI
{
    public partial class NewUserForm : Form
    {
        private readonly IEmployeeService _service;

        public NewUserForm(IEmployeeService service)
        {
            _service = service;
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Cursor = Cursors.Hand;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text;
            if (int.TryParse(textBox2.Text, out int wage) && wage >= 0)
            {
                var employee = new Employee
                {
                    Surname = surname,
                    WageAfterTaxes = wage
                };

                _service.Add(employee);
                Close();
            }
            else MessageBox.Show("Вы ввели некорректное значение", "Неправильный ввод");
        }
    }
}
