using EmployeeWagesPract.App;
using EmployeeWagesPract.Data;
using Microsoft.EntityFrameworkCore;
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
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlite(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);

            var repository = new EmployeeContext(builder.Options);

            var service = new EmployeeService(repository);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(service));
        }
    }
}