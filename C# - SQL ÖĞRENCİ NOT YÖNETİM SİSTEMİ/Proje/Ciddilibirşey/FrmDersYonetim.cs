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
    public partial class FrmDersYonetim : Form
    {
        public int ders;

        public FrmDersYonetim()
        {
            InitializeComponent();
        }

        private void BtnListele_MouseEnter(object sender, EventArgs e)
        {
            BtnListele.BackColor = Color.Magenta;
        }

        private void BtnListele_MouseLeave(object sender, EventArgs e)
        {
            BtnListele.BackColor = Color.MediumVioletRed;
        }

        private void BtnEkle_MouseEnter(object sender, EventArgs e)
        {
            BtnEkle.BackColor = Color.Magenta;
        }

        private void BtnEkle_MouseLeave(object sender, EventArgs e)
        {
            BtnEkle.BackColor = Color.MediumVioletRed;
        }

        private void BtnGuncelle_MouseEnter(object sender, EventArgs e)
        {
            BtnGuncelle.BackColor = Color.Magenta;
        }

        private void BtnGuncelle_MouseLeave(object sender, EventArgs e)
        {
            BtnGuncelle.BackColor = Color.MediumVioletRed;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmAkademisyenYonlendirme ekran = new FrmAkademisyenYonlendirme();
            ekran.giris = ders;
            ekran.Show();
            this.Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=  0)
            {
                TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }
        DbOkulEntities db = new DbOkulEntities();

        private void listele()
        {
            var degerler = from x in db.TblDersler
                           select new
                           {
                               x.DersID,
                               x.DersAd
                           };
            dataGridView1.DataSource = degerler.ToList();
        }
        private void FrmDersYonetim_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Dersi eklemek istediğinize emin misiniz ?", "Soru"
                ,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dialog == DialogResult.Yes)
            {
                TblDersler a = new TblDersler();
                a.DersAd = TxtAd.Text;
                db.TblDersler.Add(a);
                db.SaveChanges();
                MessageBox.Show("Ders başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ders eklenmedi","Bilgi");
            }
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Güncellemek istediğinize emin misiniz","Soru"
                ,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int id = int.Parse(TxtID.Text);
                var x = db.TblDersler.Find(id);
                x.DersAd = TxtAd.Text;
                db.SaveChanges();
                MessageBox.Show("Ders başarıyla güncellendi", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ders güncellenmedi", "Bilgi");
            }
            listele();
        }
    }
}
