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
    public class FilmlerDB
    {
        public int CustomerID
        {
            get;
            set;
        }
        public string Movie
        {
            get;
            set;

        }
        public int Sayi
        {
            get;
            set;

        }
        public FilmlerDB(int CustomerID, string Movie, int Sayi)
        {
            this.CustomerID = CustomerID;
            this.Movie = Movie;
            this.Sayi = Sayi;
        }

        public FilmlerDB()
        {
            // TODO: Complete member initialization
        }
    }

    

}
