using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veri_Temzileme.varliklar
{
    public class KisiFilmler
    {
        string CustomerID;
        string Movie;
        public KisiFilmler()
        {
            this.CustomerID = "";
            this.Movie = "";
        }
        public string _CustomerID
        {
            get
            {
                return CustomerID;
            }
            set 
            {
                CustomerID = value;
            }
        }
        public string _Movie
        {
            get 
            {
                return Movie;
            }
            set 
            {
                Movie = value;            
            }
        
        }
    }
}
