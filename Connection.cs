using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Connection
    {
        public SqlConnection con = new SqlConnection(ConnectionString());
       
        SqlDataAdapter da;
        SqlCommand cmd;
        static string ConnectionString()
        {
            return @"Data Source=AMIT\SQLEXPRESS;Initial Catalog=Amit;Integrated Security=true;";
        }

        public void Executequerise(string query)
        {
            OpenConection();
            SqlCommand cmd = new SqlCommand(query, con);
            
           int n= cmd.ExecuteNonQuery();

            
        }
        public DataTable DataReader(string Query_)
        {
            SqlDataAdapter da = new SqlDataAdapter(Query_, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void OpenConection()
        {
            con = new SqlConnection(ConnectionString());
            con.Open();
        }
        public void CloseConnection()
        {
            con.Close();
        }
    }
}