namespace EmployeeWagesPract.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; } = null!;
        public int WageBeforeTaxes { get; set; }
        public int WageAfterTaxes { get; set; }
    }
}