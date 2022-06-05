namespace EmployeeWagesPract.Data.Tests
{
    public class EmployeeRepositoryTests : IDisposable
    {
        private readonly EmployeeContext _repository;
        private readonly List<Employee> employeesOnDefault = new()
        {
            new Employee()
            {
                Surname = "Виктор",
                WageAfterTaxes = 91000
            },
            new Employee()
            {
                Surname = "Анатолий",
                WageAfterTaxes = 23000
            },
            new Employee()
            {
                Surname = "Дмитрий",
                WageAfterTaxes = 72000
            }
        };

        public EmployeeRepositoryTests()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlite("Data Source=EmployeeTests.db");

            _repository = new EmployeeContext(builder.Options);

            var employees = employeesOnDefault.Select(e => new Entities.Employee()
            {
                Surname = e.Surname,
                WageAfterTaxes = e.WageAfterTaxes,
                WageBeforeTaxes = e.WageBeforeTaxes
            }).ToArray();
            _repository.Employees.AddRange(employees);
            _repository.SaveChanges();
        }

        [Fact]
        public void GetAllEmployees()
        {
            var employees = _repository.Get();

            Assert.Equal(employeesOnDefault.Count, employees.Count);
            for (int i = 0; i < employees.Count; i++)
            {
                Assert.Equal(employeesOnDefault[i].Surname, employees[i].Surname);
                Assert.Equal(employeesOnDefault[i].WageBeforeTaxes, employees[i].WageBeforeTaxes);
                Assert.Equal(employeesOnDefault[i].WageAfterTaxes, employees[i].WageAfterTaxes);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetEmployeeById_ShouldReturnCurrect(int id)
        {
            var expectedEmployee = employeesOnDefault[id - 1];

            var employee = _repository.Get(id);

            Assert.NotNull(employee);
            Assert.Equal(expectedEmployee.Surname, employee.Surname);
            Assert.Equal(expectedEmployee.WageBeforeTaxes, employee.WageBeforeTaxes);
            Assert.Equal(expectedEmployee.WageAfterTaxes, employee.WageAfterTaxes);
        }

        [Fact]
        public void GetEmployeeById_ShouldThrowNotFoundException()
        {
            Assert.Throws<EmployeeNotFoundException>(() => _repository.Get(400));
        }

        public void Dispose()
        {
            _repository.Database.EnsureDeleted();
        }
    }
}