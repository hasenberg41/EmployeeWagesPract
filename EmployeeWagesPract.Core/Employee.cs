namespace EmployeeWagesPract.Core
{
    public class Employee
    {
        public string Surname { get; set; } = null!;

        public int WageAfterTaxes { get; set; }

        public int WageBeforeTaxes => (int)(WageAfterTaxes * 0.87);
    }
}