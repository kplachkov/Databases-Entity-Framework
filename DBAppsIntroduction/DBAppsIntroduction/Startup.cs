
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;

namespace DBAppsIntroduction
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
            SqlConnection connection = new SqlConnection(@"
Server=.;
Database=DatabaseExample;
Integrated Security=true");
            connection.Open();
            using (connection)
            {

                NumberOfEmployees(connection);

                EmployeesFirstNameLastNameSalary(connection);

                InsertTown(connection);

                DeleteTown(connection);

                SearchProjectIdByName(connection);

            }

        }

        static void NumberOfEmployees(SqlConnection connection)
        {
            
            string query = "SELECT COUNT(*) FROM Employees";
            SqlCommand cmd = new SqlCommand(query, connection);
            var employeesCount = (int) cmd.ExecuteScalar();
            Console.WriteLine("Number of employees: {0}", employeesCount);
            
        }

        static void EmployeesFirstNameLastNameSalary(SqlConnection connection)
        {
            // Read
            string query = @"SELECT FirstName,
LastName,
Salary FROM Employees";

            SqlCommand cmd = new SqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            using (reader)
            {
//                    reader.Read();  // Fetch a row from the SQL table.
//                    Console.WriteLine(reader[0]);  // The first entry of the row.
//                    Console.WriteLine("Names:");
//                    while (reader.Read())
//                    {
//                        Console.WriteLine($"- {reader[1]} {reader[2]}");
//                    }
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader.GetName(i),-20}");
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i],-20}");
                    }
                    Console.WriteLine();
                }

            }
        }

        static void InsertTown(SqlConnection connection)
        {
            // Insert
            Console.Write("Enter town name to add: ");
            string townName = Console.ReadLine();
            
            string query = $"INSERT INTO Towns VALUES(@TownName)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TownName", townName);  // Adds the variable to the query.
            int affectedRows = cmd.ExecuteNonQuery();
            Console.WriteLine($"Affected rows: {affectedRows}");
            
        }

        static void DeleteTown(SqlConnection connection)
        {
            // Delete
            Console.Write("Enter town name to delete: ");
            string townName = Console.ReadLine();

            string query = $"DELETE FROM Towns WHERE Name = @TownName";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TownName", townName);  // Adds the variable to the query.
            int affectedRows = cmd.ExecuteNonQuery();
            Console.WriteLine($"Affected rows: {affectedRows}");
        }

        static void SearchProjectIdByName(SqlConnection connection)
        {
            Console.Write("Enter project name: ");
            var pattern = Console.ReadLine();
            string query = @"
SELECT TOP 1 ProjectId
FROM Projects
WHERE Name LIKE @ProjectName";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProjectName", "%" + pattern + "%");
            int foundProjectId = (int) (cmd.ExecuteScalar() ?? -1);
            if (foundProjectId == -1)
            {
                Console.WriteLine("Project not found");
                return;
            }
            Console.WriteLine($"Found project with ID: {foundProjectId}");
        }
    }
}
