using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace Veri_Temzileme
{
    public partial class Form1 : Form
    {
        Metodlar mtd = new Metodlar();
        string bagla = "Data Source=URALKAYA\\SQLSERVERTANJU; Database = FilmlerDatabase; User Id = sa ; Password=12369874";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            DataTable dt = new DataTable();
            dt = mtd.GetDataTable("select * from Movies");
            dataGridView1.DataSource = dt;            
            SqlConnection con = new SqlConnection(bagla);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Count(*) as ToplamAdet from Movies";
            con.Open();
            int sayisi = Convert.ToInt32(cmd.ExecuteScalar());
            textBox1.Text = sayisi.ToString();
            con.Close();
            con.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            DataTable dt = new DataTable();
            dt = mtd.GetDataTable("SELECT CustomerID,Movie, COUNT(*) TotalCount FROM Movies " +
            "GROUP BY CustomerID,Movie HAVING COUNT(*) > 1 ORDER BY COUNT(*) DESC");
            dataGridView2.DataSource = dt; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();
            frm.ShowDialog();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
            DataTable dtfilmsayisi = new DataTable();
            dtfilmsayisi = mtd.GetDataTable("SELECT Movie, count(*) AS Film_Sayıları " + 
            " FROM Movies GROUP BY Movie ORDER BY Film_Sayıları desc ");
            dataGridView3.DataSource = dtfilmsayisi;
        }
    }
}
