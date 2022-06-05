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
    }
}