using System;
using System.Collections;
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
    public partial class ListeyeAt : Form
    {
        Database db = new Database();

         
        public ListeyeAt()
        {
            InitializeComponent();
        }
        public FilmlerDB[] ShowFilms()
        {
            
            List<FilmlerDB> sinemalistesi = new List<FilmlerDB>();
            
            DataTable dtb;
            dtb = db.getDataTable("select * from Tekrar_Verileri_Temizlenmis");
            if (dtb.Rows.Count > 0)
            {
                for (int i = 0; i < dtb.Rows.Count; ++i)
                {
                    FilmlerDB SinemaDurum = new FilmlerDB();
                    SinemaDurum.Movie = dtb.Rows[i]["Movie"].ToString().ToUpper();
                    SinemaDurum.CustomerID = Convert.ToInt32(dtb.Rows[i]["CustomerID"]);
                    sinemalistesi.Insert(i, SinemaDurum);
                }
                    
            }
            return sinemalistesi.ToArray();

            

        }

        //listboxı ekrana bas
        private void button1_Click(object sender, EventArgs e)
        {
            int tekrar;
            FilmlerDB[] dizi = ShowFilms();
            String s = string.Empty;
            for (int i = 0; i <= 1000; i++)
            {

                richTextBox1.AppendText(dizi[i].Movie.ToString() + "\n");
                //listBox1.Items.Add(dizi[i].CustomerID + "\n");
             }

           //tekrarlı verinin olup olmamasını akarşılaştır
            for (int a = 0; a <=1000; a++)
            {
                tekrar = 0;

                for (int i = 0; i <= 1000; i++)
                {
                    if (a == i)
                        tekrar++;
                }
                if (tekrar >= 2)
                    listBox1.Items.Add(dizi[a].Movie.ToString() + "\n");

            }      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltKume gec = new AltKume();
            this.Hide();
            gec.ShowDialog();
        }

        private void ListeyeAt_Load(object sender, EventArgs e)
        {
           
        }

    }
}
