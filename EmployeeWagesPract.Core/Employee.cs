namespace EmployeeWagesPract.Core
{
    public class Employee
    {
        public Employee()
        {
            WageBeforeTaxes = (int)(WageAfterTaxes * 0.87);
        }
        public string Surname { get; set; } = null!;
        public int WageBeforeTaxes { get; private set; }
        public int WageAfterTaxes { get; set; }
    }
}