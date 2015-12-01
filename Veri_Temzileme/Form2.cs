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

    public partial class Form2 : Form
    {
        Metodlar mtd = new Metodlar();

        string bagla = "Data Source=URALKAYA\\SQLSERVERTANJU; Database = FilmlerDatabase; User Id = sa ; Password=12369874";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ado = new Form1();
            this.Hide();
            ado.ShowDialog();
        }

        private void sil(object sender, EventArgs e)
        {
            mtd.cmd("Delete from Tekrar_Verileri_Temizlenmis");

        }

        private void Veri_Temizle(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            mtd.cmd("INSERT INTO Tekrar_Verileri_Temizlenmis(CustomerID,Movie) SELECT DISTINCT * " +
            "FROM Movies where CustomerID IN (SELECT CustomerID FROM Movies" +
                " GROUP BY CustomerID,Movie HAVING COUNT(*) > 0 )");
            SqlConnection con = new SqlConnection(bagla);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Count(*) as ToplamAdet from Tekrar_Verileri_Temizlenmis";
            con.Open();
            int sayisi = Convert.ToInt32(cmd.ExecuteScalar());
            textBox1.Text = sayisi.ToString();
            con.Close();
            con.Dispose();
            DataTable dt = new DataTable();
            dt = mtd.GetDataTable("SELECT CustomerID,Movie, COUNT(*) TotalCount" +
                " FROM Tekrar_Verileri_Temizlenmis GROUP BY CustomerID,Movie HAVING COUNT(*) > 0" +
                " ORDER BY COUNT(*) DESC");
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListeyeAt gec = new ListeyeAt();
            this.Hide();
            gec.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
