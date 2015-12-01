using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmOneriSistemi.varliklar
{
    public class izlenen_film_sayisi
    {
        string ad;
        int sayi;

        public  izlenen_film_sayisi()
        {
            ad = "";
            sayi = 0;
        }

        public string _ad
        {
            get
            {
                return ad;
            }
            set
            {
                ad = value;
            }
        }
       public  int _sayi
        {
            get
            {
                return sayi;
            }
            set
            {
                sayi = value;
            }
        }
    }
}
