
using System.Data.Entity;

namespace IntroductionToEntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main(string[] args)
        {
            var context = new FirmEntities();

            // Select rows from a table.
            var employee = context.Employees.Find(1);  // The first employee in the DB.
            Console.WriteLine($"First employee: {employee.FirstName} {employee.LastName}");

            var employeesWithSalaryAbove50k = context.Employees.Where(e => e.Salary > 50000).ToList();
            Console.WriteLine($"Employees with salary above 50k:\n{string.Join("\n", employeesWithSalaryAbove50k.Select(e => $"{e.FirstName} {e.LastName} - {e.Salary}"))}");

            // Add row to a table.
            var town = new Town();
            town.Name = "Pleven";
            context.Towns.Add(town);
            context.SaveChanges();

            var address = new Address();
            address.AddressText = "Hristo Botev 15";
            address.Town = new Town() { Name = "Velingrad" };
            context.Addresses.Add(address);
            context.SaveChanges();

            // Change an entry in the table.
            employee = context.Employees.First();
            employee.FirstName = "Alex";
            context.SaveChanges();
            Console.WriteLine($"{context.Employees.First().FirstName} {context.Employees.First().LastName}");

            // Remove rows from a table.
            var rowsToRemove = 1;
            var maxAddressId = context.Addresses.Count();
            var addressesToDelete = context.Addresses.Where(a => a.AddressID > maxAddressId - rowsToRemove).ToList();
            foreach (var addressToDelete in addressesToDelete)
            {
                context.Addresses.Remove(addressToDelete);
            }
            context.SaveChanges();

        }

    }
}

