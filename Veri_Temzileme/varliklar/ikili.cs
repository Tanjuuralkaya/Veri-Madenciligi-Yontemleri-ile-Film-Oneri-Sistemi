using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmOneriSistemi.varliklar
{
    public class ikili
    {
        string film1;
        string film2;

        public ikili()
        {
            film1 = "";
            film2 = "";
        }
        public string _film1
        {
            get
            {
                return film1;
            }
            set 
            {
                film1 = value;                
            }

        }
        public string _film2
        {
            get 
            {
                return film2;
            }
            set
            {
                film2 = value;
            }
        
        
        }


    }
}
