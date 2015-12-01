using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veri_Temzileme
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        private void btnCahart_Click(object sender, EventArgs e)
        {
            this.chart1.Visible = true;
        }
    }
}
