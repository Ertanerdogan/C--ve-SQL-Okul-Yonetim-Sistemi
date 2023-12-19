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
    public partial class FrmOgrProfil : Form
    {
        public FrmOgrProfil()
        {
            InitializeComponent();
        }
        DbOkulEntities db = new DbOkulEntities();
        public int profil;

        private void fonk()
        {
            var x = db.TblOgrenciler.Find(profil);
            TxtID.Text = x.OgrID.ToString();
            TxtAd.Text = x.OgrAd.ToString();
            TxtSoyad.Text = x.OgrSoyad.ToString();
            TxtNumara.Text = x.OgrNumara.ToString();
            TxtSifre.Text = x.OgrSifre.ToString();
            TxtBolum.Text = x.TblBolumler.BolumAd.ToString();    
        }
        private void BtnDegistir_MouseEnter(object sender, EventArgs e)
        {
            BtnDegistir.BackColor = Color.Magenta;
        }

        private void BtnDegistir_MouseLeave(object sender, EventArgs e)
        {
            BtnDegistir.BackColor = Color.MediumVioletRed;
        }

        private void FrmOgrProfil_Load(object sender, EventArgs e)
        {
            fonk();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgrenciYonlendirme ekran = new FrmOgrenciYonlendirme();
            ekran.ogrenci = profil;
            ekran.Show();
            this.Dispose();
        }

        private void BtnDegistir_Click(object sender, EventArgs e)
        {
            if (TxtYeni.Text != "")
            {
                DialogResult b = MessageBox.Show("Şifrenizi değiştirmek istediğinize emin misiniz ?","Soru"
                    ,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (b == DialogResult.Yes)
                {
                    var a = db.TblOgrenciler.Find(profil);
                    a.OgrSifre = TxtYeni.Text;
                    db.SaveChanges();
                    MessageBox.Show("Şifreniz başarıyla değiştirildi", "Bilgi");
                    fonk();
                }
                else
                {
                    MessageBox.Show("Şifreniz değiştirilmedi","Bilgi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen yeni şifrenizi girin", "Uyarı");
            }
        }
    }
}
