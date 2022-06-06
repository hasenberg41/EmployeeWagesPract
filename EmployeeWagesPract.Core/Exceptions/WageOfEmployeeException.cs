namespace EmployeeWagesPract.Core.Exceptions
{
    public class WageOfEmployeeException : Exception
    {
        public WageOfEmployeeException(Employee employee) : base($"Wage of {nameof(employee)} can't be negative.")
        {

        }
    }
}
