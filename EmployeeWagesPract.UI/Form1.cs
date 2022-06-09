using EmployeeWagesPract.Core;
using EmployeeWagesPract.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace EmployeeWagesPract.UI
{
    public partial class Form1 : Form
    {
        private readonly IEmployeeService _service;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Form1(IEmployeeService service)
        {
            _service = service;
            InitializeComponent();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            _service.Add(new Employee()
            {
                Surname = "wdwd",
                WageAfterTaxes = 45050
            });
            _service.Add(new Employee()
            {
                Surname = "wdsadaswd",
                WageAfterTaxes = 1231312
            });

            var employees = _service.Get();
            foreach (var emp in employees)
            {
                textBox1.Text += $"{emp.Surname} {emp.WageBeforeTaxes} {emp.WageAfterTaxes}{Environment.NewLine}";
            }
        }
    }
}