using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MobileDAL
{
    public class MobileDetailDAL
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        // Read the connection string from Web.config

        public static SqlConnection ConnectSQLShop()
        {
            // Save connection string details as string
            string connection = ConfigurationManager.ConnectionStrings["ConnectSQLShop"].ConnectionString;

            // Establish database connection
            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            else con.Open();

            return con;
        }

        // Perform DML operations (Create, Update, Delete)

        public bool DMLOperation(string query)
        {
            cmd = new SqlCommand(query, ConnectSQLShop());
            int x = cmd.ExecuteNonQuery();
            if (x == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Create a DataTable to store results

        public DataTable SelectAll(string query)
        {
            try
            {
                da = new SqlDataAdapter(query, ConnectSQLShop());
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                DataTable dt = new DataTable();
                return dt;
            }
        }
    }
}
