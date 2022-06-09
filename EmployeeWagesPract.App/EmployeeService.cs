using EmployeeWagesPract.Core;
using EmployeeWagesPract.Core.Exceptions;
using EmployeeWagesPract.Core.Interfaces;

namespace EmployeeWagesPract.App
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public int Add(Employee newEmployee)
        {
            if (newEmployee.WageAfterTaxes < 0)
                throw new WageOfEmployeeException(newEmployee);

            return _repository.Create(newEmployee);
        }

        public List<Employee> Get()
        {
            return _repository.Get();
        }

        public Employee Get(int id)
        {
            if (id <= 0)
                throw new EmployeeNotFoundException(id);

            return _repository.Get(id);
        }

        public void Delete(Employee employee)
        {
            _repository.Delete(employee);
        }
    }
}