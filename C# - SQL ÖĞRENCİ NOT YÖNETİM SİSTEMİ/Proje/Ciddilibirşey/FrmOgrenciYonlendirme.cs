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
    public partial class FrmOgrenciYonlendirme : Form
    {
        public FrmOgrenciYonlendirme()
        {
            InitializeComponent();
        }
        public int ogrenci;

        private void BtnNotlarim_MouseEnter(object sender, EventArgs e)
        {
            BtnNotlarim.BackColor = Color.DarkBlue;
        }

        private void BtnNotlarim_MouseLeave(object sender, EventArgs e)
        {
            BtnNotlarim.BackColor = Color.Blue;
        }

        private void BtnBolumler_MouseEnter(object sender, EventArgs e)
        {
            BtnBolumler.BackColor = Color.DarkBlue;
        }

        private void BtnBolumler_MouseLeave(object sender, EventArgs e)
        {
            BtnBolumler.BackColor = Color.Blue;
        }

        private void BtnAkademisyenler_MouseEnter(object sender, EventArgs e)
        {
            BtnAkademisyenler.BackColor = Color.DarkBlue;
        }

        private void BtnAkademisyenler_MouseLeave(object sender, EventArgs e)
        {
            BtnAkademisyenler.BackColor = Color.Blue;
        }

        private void BtnDersler_MouseEnter(object sender, EventArgs e)
        {
            BtnDersler.BackColor = Color.DarkBlue;
        }

        private void BtnDersler_MouseLeave(object sender, EventArgs e)
        {
            BtnDersler.BackColor = Color.Blue;
        }

        private void BtnProfil_MouseEnter(object sender, EventArgs e)
        {
            BtnProfil.BackColor = Color.DarkBlue;
        }

        private void BtnProfil_MouseLeave(object sender, EventArgs e)
        {
            BtnProfil.BackColor = Color.Blue;
        }

        private void BtnCikis_MouseEnter(object sender, EventArgs e)
        {
            BtnCikis.BackColor = Color.DarkBlue;
        }

        private void BtnCikis_MouseLeave(object sender, EventArgs e)
        {
            BtnCikis.BackColor = Color.Blue;
        }
        
        private void BtnNotlarim_Click(object sender, EventArgs e)
        {
            FrmOgrNotlarim ekran = new FrmOgrNotlarim();
            ekran.kod = ogrenci;
            ekran.Show();
            this.Hide();
        }

        private void BtnBolumler_Click(object sender, EventArgs e)
        {
            FrmOgrBolumler ekran = new FrmOgrBolumler();
            ekran.bolum = ogrenci;
            ekran.Show();
            this.Hide();
        }

        private void BtnAkademisyenler_Click(object sender, EventArgs e)
        {
            FrmAkademisyenler ekran = new FrmAkademisyenler();
            ekran.aka = ogrenci;
            ekran.Show();
            this.Hide();
        }

        private void BtnDersler_Click(object sender, EventArgs e)
        {
            FrmDersler ekran = new FrmDersler();
            ekran.ders = ogrenci;
            ekran.Show();
            this.Hide();
        }

        private void BtnProfil_Click(object sender, EventArgs e)
        {
            FrmOgrProfil ekran = new FrmOgrProfil();
            ekran.profil = ogrenci;
            ekran.Show();
            this.Hide();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
