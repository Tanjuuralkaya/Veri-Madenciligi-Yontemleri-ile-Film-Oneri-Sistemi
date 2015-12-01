using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veri_Temzileme
{
     public class VeriToplami: List<Veri>
    {
         public Veri DistincYap()
         {
             Veri teklihal = new Veri();

             foreach (Veri veriler in this)
             {
                 teklihal.AddRange(from item in veriler
                                   where !teklihal.Contains(item)
                                 select item);
             }

             return (teklihal);
         }


         public double DestekBul(string teknesneolanlar)
         {
             int benzersayi = (from itemset in this
                               where itemset.Contains(teknesneolanlar)
                               select itemset).Count();

             double Destek = ((double)benzersayi / (double)this.Count) * 100.0;
        
             return (Destek);
         }

         public double DestekBul(Veri verikumesi)
         {
             int benzersayi = (from i in this
                               where i.Contains(verikumesi)
                               select i).Count();

             double Destek = ((double)benzersayi / (double)this.Count) * 100.0;
             return (Destek);
         }

         public override string ToString()
         {
    
             return (string.Join("\r\n", (from itemset in this select itemset.ToString()).ToArray()));
         }
    }
}
