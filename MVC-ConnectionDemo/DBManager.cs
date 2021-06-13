using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient; 


namespace MVC_ConnectionDemo
{
    public class DBManager
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8UBAOPE\\NABEELEXPRESS;Initial Catalog=TestingDb;Integrated Security=True");

        public bool InsertUpdateDelete(string command)
        {
            SqlCommand cmd = new SqlCommand(command, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int j = cmd.ExecuteNonQuery();
            if (j > 0)
                return true;
            else
                return false;

        }
        public DataTable ReadBulkData(string command)
        {
            SqlDataAdapter sa = new SqlDataAdapter(command, con);
            DataTable datatbl = new DataTable();
            sa.Fill(datatbl);
            return datatbl;


        }

    }
}