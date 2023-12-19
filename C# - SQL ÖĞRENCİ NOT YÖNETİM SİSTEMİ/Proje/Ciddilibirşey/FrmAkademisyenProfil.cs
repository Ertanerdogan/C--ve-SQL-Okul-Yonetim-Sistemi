using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciddilibirşey
{
    public partial class FrmAkademisyenProfil : Form
    {

        public int kisi;
        public FrmAkademisyenProfil()
        {
            InitializeComponent();
        }
        DbOkulEntities db = new DbOkulEntities();
        
        private void profil()
        {
            var x = db.TblAkademisyen.Find(kisi);
            TxtID.Text = x.AkademisyenID.ToString();
            TxtAd.Text = x.AkademisyenAd.ToString();
            TxtSoyad.Text = x.AkademisyenSoyad.ToString();
            TxtDers.Text = x.TblDersler.DersAd.ToString();
            TxtKullanici.Text = x.AkademisyenKullanici.ToString();
            TxtSifre.Text = x.AkademisyenSifre.ToString();
        }
        private void FrmAkademisyenProfil_Load(object sender, EventArgs e)
        {
            profil();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmAkademisyenYonlendirme ekran = new FrmAkademisyenYonlendirme();
            ekran.giris = kisi;
            ekran.Show();
            this.Dispose();
        }

        private void BtnDegistir_MouseEnter(object sender, EventArgs e)
        {
            BtnDegistir.BackColor = Color.Magenta;
        }

        private void BtnDegistir_MouseLeave(object sender, EventArgs e)
        {
            BtnDegistir.BackColor = Color.MediumVioletRed;
        }

        private void BtnDegistir_Click(object sender, EventArgs e)
        {
            if(TxtYeni.Text != "")
            {
                DialogResult a = MessageBox.Show("Şifrenizi değiştirmek istediğinize emin misiniz ?", "Soru",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                    var x = db.TblAkademisyen.Find(kisi);
                    x.AkademisyenSifre = TxtYeni.Text;
                    db.SaveChanges();
                    MessageBox.Show("Şifreniz başarıyla değiştirildi", "Bilgi");
                    profil();
                }
                else
                {
                    MessageBox.Show("Şifreniz değiştirilmedi", "Bilgi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen yeni şifrenizi giriniz", "Uyarı");
            }
        }
    }
}
