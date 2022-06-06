namespace EmployeeWagesPract.Core.Interfaces
{
    public interface IEmployeeService
    {
        int Add(Employee newEmployee);

        List<Employee> Get();

        Employee Get(int id);
    }
}
