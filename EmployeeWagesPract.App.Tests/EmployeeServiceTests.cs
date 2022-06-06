using EmployeeWagesPract.Core.Interfaces;

namespace EmployeeWagesPract.App.Tests
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _repository;
        private readonly EmployeeService _service;
        private readonly Fixture _fixture;

        public EmployeeServiceTests()
        {
            _repository = new Mock<IEmployeeRepository>();
            _service = new EmployeeService(_repository.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public void GetAll()
        {
            var exceptedEmployees = _fixture.CreateMany<Employee>(20).ToList();
            _repository.Setup(o => o.Get()).Returns(exceptedEmployees);

            var employees = _service.Get();
        }
    }
}