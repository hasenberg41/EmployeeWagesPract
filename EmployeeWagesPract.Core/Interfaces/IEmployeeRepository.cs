namespace EmployeeWagesPract.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> Get();

        Employee Get(int id);

        int Create(Employee newEmployee);
    }
}
