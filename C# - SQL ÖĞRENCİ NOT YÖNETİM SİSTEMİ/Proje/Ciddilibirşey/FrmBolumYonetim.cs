using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciddilibirşey
{
    public partial class FrmBolumYonetim : Form
    {
        public int bolum;
        DbOkulEntities entity = new DbOkulEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=ERTAN\SQLEXPRESS;Initial Catalog=DbOkul;Integrated Security=True");
        public FrmBolumYonetim()
        {
            InitializeComponent();
        }

        private void listele()
        {
            var degerler = from x in entity.TblBolumler
                           select new
                           {
                               x.BolumID,
                               x.BolumAd
                           };
            dataGridView1.DataSource = degerler.ToList();
        }

        private void bolumekle()
        {
            TblBolumler x = new TblBolumler();
            x.BolumAd = TxtAd.Text;
            entity.TblBolumler.Add(x);
            entity.SaveChanges();
            MessageBox.Show("Bölüm başarıyla eklendi", "Bilgi");
        }

        private void bolumguncelle()
        {
            int id = int.Parse(TxtID.Text);
            var x = entity.TblBolumler.Find(id);
            x.BolumAd = TxtAd.Text;
            entity.SaveChanges();
            MessageBox.Show("Başarıyla güncellendi", "Bilgi");
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void FrmBolumYonetim_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Eklemek istediğinize emin misiniz ?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(a == DialogResult.Yes)
            {
                bolumekle();
                listele();
            }
            else if (a == DialogResult.No)
            {
                MessageBox.Show("Bölüm eklenmedi", "Bilgi");
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Güncellemek istediğinize emin misiniz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                bolumguncelle();
                listele();
            }
            else if (a == DialogResult.No)
            {
                MessageBox.Show("Bölüm güncellenmedi", "Bilgi");
            }
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
            ekran.giris = bolum;
            ekran.Show();
            this.Dispose();
        }
    }
}
