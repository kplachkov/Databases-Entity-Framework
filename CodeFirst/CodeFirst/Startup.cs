
namespace CodeFirst
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
            var context = new FirmContext();
            context.Employees.Select(e => new
            {
                e.FirstName,
                e.LastName
            }).ToList().ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName}"));
        }
    }
}
