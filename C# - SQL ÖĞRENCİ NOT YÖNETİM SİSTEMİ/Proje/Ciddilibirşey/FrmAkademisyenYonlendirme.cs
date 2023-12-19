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
    public partial class FrmAkademisyenYonlendirme : Form
    {
        public FrmAkademisyenYonlendirme()
        {
            InitializeComponent();
        }

        private void BtnOgrYonetim_MouseEnter(object sender, EventArgs e)
        {
            BtnOgrYonetim.BackColor = Color.DarkBlue;
        }

        private void BtnOgrYonetim_MouseLeave(object sender, EventArgs e)
        {
            BtnOgrYonetim.BackColor = Color.Blue;
        }

        private void BtnBlmYonetim_MouseEnter(object sender, EventArgs e)
        {
            BtnBlmYonetim.BackColor = Color.DarkBlue;
        }

        private void BtnBlmYonetim_MouseLeave(object sender, EventArgs e)
        {
            BtnBlmYonetim.BackColor = Color.Blue;
        }

        private void BtnOgrYonetim_Click(object sender, EventArgs e)
        {
            FrmOgrYonetim ekran = new FrmOgrYonetim();
            ekran.yonetim = giris;
            ekran.Show();
            this.Hide();
        }
        public int giris;
        private void BtnBlmYonetim_Click(object sender, EventArgs e)
        {
            FrmBolumYonetim ekran = new FrmBolumYonetim();
            ekran.bolum = giris;
            ekran.Show();
            this.Hide();
        }

        private void BtnDersYonetim_MouseEnter(object sender, EventArgs e)
        {
            BtnDersYonetim.BackColor = Color.DarkBlue;
        }

        private void BtnDersYonetim_MouseLeave(object sender, EventArgs e)
        {
            BtnDersYonetim.BackColor = Color.Blue;
        }

        private void BtnDersYonetim_Click(object sender, EventArgs e)
        {
            FrmDersYonetim ekran = new FrmDersYonetim();
            ekran.ders = giris;
            ekran.Show();
            this.Hide();
        }

        private void BtnNotYonetim_MouseEnter(object sender, EventArgs e)
        {
            BtnNotYonetim.BackColor = Color.DarkBlue;
        }

        private void BtnNotYonetim_MouseLeave(object sender, EventArgs e)
        {
            BtnNotYonetim.BackColor = Color.Blue;
        }

        private void BtnNotYonetim_Click(object sender, EventArgs e)
        {
            FrmNotYonetim ekran = new FrmNotYonetim();
            ekran.not = giris;
            ekran.Show();
            this.Hide();
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

        private void BtnProfil_Click(object sender, EventArgs e)
        {
            FrmAkademisyenProfil ekran = new FrmAkademisyenProfil();
            ekran.kisi = giris;
            ekran.Show();
            this.Hide();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
