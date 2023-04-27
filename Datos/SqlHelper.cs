using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    static class SqlHelper
    {
        public static string Connection { get; } = "Data Source=DESKTOP-0CM6UEO\\MSSQLSERVER22;Initial Catalog=DB_MANTENIMIENTO;Integrated Security=True;";
       
        public static Int32 ExecuteNonQuery(String commandText,
             List<SqlParameter> parameters)
        {
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters.ToArray());

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static SqlDataReader ExecuteReader(String commandText,
             params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(Connection);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if(parameters == null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
            
                conn.Open();
                
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }

        public static Object ExecuteScalar(String commandText,
             List<SqlParameter> parameters)
        {
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters.ToArray());

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
