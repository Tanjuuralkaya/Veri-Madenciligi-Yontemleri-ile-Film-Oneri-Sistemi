using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Veri_Temzileme
{
        class Database
        {
            static string DbName = string.Empty;
            public string DatabaseName
            {
                get { return DbName; }
                set { DbName = value; }
            }
            SqlConnection con;
            public Database()
            {
                Connect();
            }
            public SqlConnection Connect()
            {

                con = new SqlConnection("Data Source=URALKAYA\\SQLSERVERTANJU; Database = FilmlerDatabase; User Id = sa ; Password=12369874");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                return con;
            }
            public DataTable getDataTable(string sql)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                DataTable dtb = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(sql, con);
                adp.Fill(dtb);
                return dtb;

            }
            public SqlCommand cmd(string sql)
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                return cmd;
            }
        }
    
}
