
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
            using (connection)
            {
                
            }
        }
    }
}
