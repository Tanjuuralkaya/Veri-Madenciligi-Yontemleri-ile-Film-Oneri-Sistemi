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
    public class Veri : List<String>
    {
        public double Destek { get; set; }

        public bool Contains(Veri veriler)
        {
            return (this.Intersect(veriler).Count() == veriler.Count);
        }

        public Veri Remove(Veri veriler)
        {
            Veri removed = new Veri();

            removed.AddRange(from item in this
                             where !veriler.Contains(item)
                             select item);
            return (removed);
        }

        public override string ToString()
        {
            return ("{" + string.Join(", ", this.ToArray()) + "}" + (this.Destek > 0 ? " (Destek: " + Math.Round(this.Destek, 2) + "%)" : string.Empty));
        }
    }
}
