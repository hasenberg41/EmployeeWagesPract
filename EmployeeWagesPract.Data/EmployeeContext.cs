using EmployeeWagesPract.Core.Exceptions;
using EmployeeWagesPract.Core.Interfaces;
using EmployeeWagesPract.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWagesPract.Data
{
    public class EmployeeContext : DbContext, IEmployeeRepository
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
            modelBuilder.Entity<Employee>().Property(e => e.Surname).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.WageBeforeTaxes).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.WageAfterTaxes).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public int Create(Core.Employee newEmployee)
        {
            throw new NotImplementedException();
        }

        public List<Core.Employee> Get()
        {
            return Employees.AsNoTracking().Select(u => new Core.Employee()
            {
                Surname = u.Surname,
                WageAfterTaxes = u.WageAfterTaxes
            }).ToList();
        }

        public Core.Employee Get(int id)
        {
            var employee = Employees.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if (employee is null)
                throw new EmployeeNotFoundException(id);

            return new Core.Employee()
            {
                Surname = employee.Surname,
                WageAfterTaxes = employee.WageAfterTaxes
            };
        }
    }
}
