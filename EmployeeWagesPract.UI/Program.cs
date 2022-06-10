using EmployeeWagesPract.App;
using EmployeeWagesPract.Core.Interfaces;
using EmployeeWagesPract.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace EmployeeWagesPract.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var services = new ServiceCollection();

            ConfigureServices(services);

            using ServiceProvider serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            var form1 = serviceProvider.GetRequiredService<Form1>();
            Application.Run(form1);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<IEmployeeRepository, EmployeeContext>(options =>
                options.UseSqlite(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString))
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddScoped<Form1>()
                .AddScoped<NewUserForm>();
        }
    }
}