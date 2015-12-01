using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veri_Temzileme
{
   public class Birliktelik
    {
       public Veri X { get; set; }
       public Veri Y { get; set; }
       public double Destek { get; set; }
       public double Guven { get; set; }

       public Birliktelik()
       {
           X = new Veri();
           Y = new Veri();
           Destek = 0.0;
           Guven = 0.0;
       }

       public override string ToString()
       {
           return (X + " => " + Y + " (Destek: " + Math.Round(Destek, 2) + "%, Güven: " + Math.Round(Guven, 2) + "%)");
       }
    }

}
