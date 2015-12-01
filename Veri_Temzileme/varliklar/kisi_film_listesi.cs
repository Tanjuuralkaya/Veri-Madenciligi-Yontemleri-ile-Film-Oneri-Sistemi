using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veri_Temzileme.varliklar
{
    class kisi_film_listesi
    {
        string CumtomerID;
        List<string> movies;

        public kisi_film_listesi()
        {
            this.CumtomerID = "";
            this.movies = null;
        }

        public string _CumtomerID
        {
            get 
            {
                return CumtomerID;
            }
            set
            {
                CumtomerID = value;
            }
        }

        public List<string> _movies
        {
            get
            {
                return movies;
            }
            set
            {
                movies = value;
            }
        }
    }
}
