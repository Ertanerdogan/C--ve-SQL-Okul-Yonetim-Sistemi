using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciddilibirşey
{
    public partial class FrmAnimasyon : Form
    {
        public FrmAnimasyon()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FrmSecenek ekran = new FrmSecenek();
            ekran.Show();
            timer1.Stop();
            this.Hide();
        }
    }
}
