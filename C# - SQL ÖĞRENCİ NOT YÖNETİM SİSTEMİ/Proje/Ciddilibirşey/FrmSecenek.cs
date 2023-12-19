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
    public partial class FrmSecenek : Form
    {
        public FrmSecenek()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmAkademisyenGiris ekran = new FrmAkademisyenGiris();
            ekran.Show();
            this.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgrenciGiris ekran = new FrmOgrenciGiris();
            ekran.Show();
            this.Dispose();
        }
    }
}
