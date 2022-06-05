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
    }
}