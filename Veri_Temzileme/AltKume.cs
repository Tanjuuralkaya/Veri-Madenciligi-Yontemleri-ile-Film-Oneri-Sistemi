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
    public partial class AltKume : Form
    {
        public AltKume()
        {
            InitializeComponent();
        }
        string baglan = "Data Source=URALKAYA\\SQLSERVERTANJU; Database = FilmlerDatabase; User Id = sa ; Password=12369874";

        List<varliklar.KisiFilmler> filmler = new List<varliklar.KisiFilmler>();
        varliklar.KisiFilmler nesne = new varliklar.KisiFilmler();
        List<String> customerId = new List<String>();
        List<String> movies = new List<String>();
        List<String> birlesim = new List<String>();
        List<String> Customerid_list = new List<String>();
        List<String> movie_list = new List<String>();

        VeriToplami db = new VeriToplami();

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();




            SqlConnection con = new SqlConnection(baglan);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = " select * from Movies2";

            SqlDataReader dr = cmd.ExecuteReader();

            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            while (dr.Read())
            {
                varliklar.KisiFilmler nesne = new varliklar.KisiFilmler();
                nesne._CustomerID = dr["CustomerID"].ToString();
                nesne._Movie = dr["Movie"].ToString().Trim();

                if (dic.ContainsKey(nesne._CustomerID))
                    dic[nesne._CustomerID].Add(nesne._Movie);
                else
                {
                    dic.Add(nesne._CustomerID, new List<string>());
                    dic[nesne._CustomerID].Add(nesne._Movie);
                }
            }

            for (int i = 0; i < dic.Count; i++)
            {
                List<string> lll = dic.ElementAt(i).Value;

                Veri v = new Veri();
                foreach (var item in lll)
                {
                    v.Add(item);
                }
                db.Add(v);
            }
            varliklar.kisi_film_listesi n = null;
            List<varliklar.kisi_film_listesi> aa = new List<varliklar.kisi_film_listesi>();

            ////////////////////////////////////////////////
            //varliklar.KisiFilmler nesne = new varliklar.KisiFilmler();

            //for (int i = 0; i < customerId.Count; i++)
            //{
            //    for (int j = 0; j < movies.Count; j++)
            //    {
            //        if (customerId[i] == customerId[j] )
            //        {
            //            //nesne._CustomerID = (customerId[i]);
            //            nesne._Movie = movies[j];

            //            //Customerid_list.Add(nesne._CustomerID);
            //            movie_list.Add(nesne._Movie);

            //            vr.Add(movie_list[j]);
            //            //vr.Add(Customerid_list[j]);

            //        }
            //    }
            //    //vr.Add(nesne._Movie);
            //    //db.Add(vr);

            // }
            //for (int i = 0; i < vr.Count; i++)
            // {

            //         db.Add(new Veri() { } );

            // }
            //////////////////////////////////////////////

            //String item1 = "A beautiful mind";
            //String item2 = "A Few Good ";
            //String item3 = "Last of the Mohicans";
            //String item4 = "Star wars";
            //String item5 = "Star Wars Episode I: The Phantom Menace";
            //String item6 = "Saving Private Ryan";
            //String item7 = "American Pie";
            //String item8 = "Aliens";



            //string item1 = "tanju";
            //string item2 = "Adnan";
            //string item3 = "Vehbi";
            //string item4 = "nevzat";
            //string item5 = "hulya";
            //string item6 = "annem";
            //string item7 = "vehbi";
            //string item8 = "hakan";

            //db.Add(new Veri() { item1, item2 });
            //db.Add(new Veri() { item1, item2, item3, item4 });
            //db.Add(new Veri() { item3, item4, item2, item5 });
            //db.Add(new Veri() { item2, item1, item7 });
            //db.Add(new Veri() { item1, item6, item8 });

            //Veri uniqueItems = db.GetUniqueItems();

            VeriToplami L = Apiori_1(db, Convert.ToDouble(textBox1.Text));

            // Console.WriteLine("<br/>" + L.Count + " itemsets in L<br/>");

            listBox1.Items.Clear();
            foreach (Veri i in L)
            {
                listBox1.Items.Add(i + "\n");
                //Console.WriteLine(i + "<br/>");
            }

            //test mining
            List<Birliktelik> TumKurallar = BirlitelikBul(db, L, Convert.ToDouble(textBox2.Text));
            //Console.WriteLine("<br/>" + allRules.Count + " rules<br/>");
            //listBox2.Width = 1300;
            listBox2.Items.Clear();
            foreach (Birliktelik Kural in TumKurallar)
            {
                listBox2.Items.Add(Kural + "\n");
            }

            con.Close();
            return;

        }

        //apiori algoritması.............................

        public static VeriToplami Apiori_1(VeriToplami db, double mindestek)
        {
            Veri I = db.DistincYap();
            VeriToplami L = new VeriToplami();
            VeriToplami Li = new VeriToplami();
            VeriToplami Ci = new VeriToplami();

            foreach (string item in I)
            {
                Ci.Add(new Veri() { item });
            }
            //ikinci terasyon kümeleme
            int k = 2;
            while (Ci.Count != 0)
            {
                Li.Clear();
                foreach (Veri veriler in Ci)
                {
                    veriler.Destek = db.DestekBul(veriler);

                    if (veriler.Destek >= mindestek)
                    {
                        Li.Add(veriler);
                        L.Add(veriler);
                    }
                }

                Ci.Clear();
                Ci.AddRange(Bit.AltKumeBul(Li.DistincYap(), k));

                k = k + 1;
            }

            return L;

        }

        public static List<Birliktelik> BirlitelikBul(VeriToplami db, VeriToplami L, double GuvenEsik)
        {
            List<Birliktelik> tumKurallarListesi = new List<Birliktelik>();

            foreach (Veri veriler in L)
            {
                VeriToplami liste = Bit.AltKumeBul(veriler, 0);
                foreach (Veri altkume in liste)
                {
                    double Guven = (db.DestekBul(veriler) / db.DestekBul(altkume)) * 100.0;

                    if (Guven >= GuvenEsik)
                    {
                        Birliktelik kural = new Birliktelik();
                        kural.X.AddRange(altkume);
                        kural.Y.AddRange(veriler.Remove(altkume));
                        kural.Destek = db.DestekBul(veriler);
                        kural.Guven = Guven;
                        if (kural.X.Count > 0 && kural.Y.Count > 0)
                        {
                            tumKurallarListesi.Add(kural);
                        }
                    }
                }
            }
            return (tumKurallarListesi);
        }
    }
}
