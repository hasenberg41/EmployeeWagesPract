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
        public void GetAll_ShouldReturnedAllEmployees()
        {
            var exceptedEmployees = _fixture.CreateMany<Employee>(20).ToList();
            _repository.Setup(o => o.Get()).Returns(exceptedEmployees);

            var employees = _service.Get();

            Assert.Equal(exceptedEmployees.Count, employees.Count);
            for (int i = 0; i < exceptedEmployees.Count; i++)
            {
                Assert.Equal(exceptedEmployees[i].Surname, employees[i].Surname);
                Assert.Equal(exceptedEmployees[i].WageAfterTaxes, employees[i].WageAfterTaxes);
                Assert.Equal(exceptedEmployees[i].WageBeforeTaxes, employees[i].WageBeforeTaxes);
            }
            _repository.Verify(r => r.Get(), Times.Once);
        }

        [Fact]
        public void GetById_ShouldReturnCurrectEmployee()
        {
            var exceptedEmployee = _fixture.Create<Employee>();
            var exceptedId = _fixture.Create<int>();
            _repository.Setup(o => o.Get(exceptedId)).Returns(exceptedEmployee);

            var returnedEmployee = _service.Get(exceptedId);

            Assert.Equal(exceptedEmployee.Surname, returnedEmployee.Surname);
            Assert.Equal(exceptedEmployee.WageAfterTaxes, returnedEmployee.WageAfterTaxes);
            Assert.Equal(exceptedEmployee.WageBeforeTaxes, returnedEmployee.WageBeforeTaxes);
            _repository.Verify(r => r.Get(exceptedId), Times.Once);
        }

        [Fact]
        public void GetById_ShouldThrowEmployeeNotFoundException()
        {
            Assert.Throws<EmployeeNotFoundException>(() => _service.Get(-1));
            _repository.Verify(r => r.Get(-1), Times.Never);
        }
    }
}