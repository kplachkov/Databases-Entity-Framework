
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
                string query = "SELECT COUNT(*) FROM Employees";
                SqlCommand cmd = new SqlCommand(query, connection);
                var employeesCount = (int) cmd.ExecuteScalar();
                Console.WriteLine("Number of employees: {0}", employeesCount);

                query = @"SELECT FirstName,
LastName,
Salary FROM Employees";
                cmd = new SqlCommand(query, connection);
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
                        Console.Write($"{reader.GetName(i), -20}");
                    }
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader[i], -20}");
                        }
                        Console.WriteLine();
                    }

                }

                // Insert
                Console.Write("Enter town name to add: ");
                string townName = Console.ReadLine();
                query = $"INSERT INTO Towns VALUES('{townName}')";
                cmd = new SqlCommand(query, connection);
                int affectedRows = cmd.ExecuteNonQuery();
                Console.WriteLine($"Affected rows: {affectedRows}");

                // Delete
                Console.Write("Enter town name to delete: ");
                townName = Console.ReadLine();
                query = $"DELETE FROM Towns WHERE Name = '{townName}'";
                cmd = new SqlCommand(query, connection);
                affectedRows = cmd.ExecuteNonQuery();
                Console.WriteLine($"Affected rows: {affectedRows}");
            }
        }
    }
}
