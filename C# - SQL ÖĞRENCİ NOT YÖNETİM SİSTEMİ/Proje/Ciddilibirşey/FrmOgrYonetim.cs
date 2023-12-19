using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciddilibirşey
{
    public partial class FrmOgrYonetim : Form
    {
        public int yonetim;
        public FrmOgrYonetim()
        {
            InitializeComponent();
        }

        private void listele()
        {
            var degerler = from x in entity.TblOgrenciler
                           select new
                           {
                               x.OgrID,
                               x.OgrAd,
                               x.OgrSoyad,
                               x.OgrNumara,
                               x.OgrSifre,
                               x.OgrBolum,
                               x.TblBolumler.BolumAd,
                               x.OgrDurum
                           };
            dataGridView1.DataSource = degerler.Where(x => x.OgrDurum == true).ToList();
            dataGridView1.Columns["OgrBolum"].Visible = false;
            dataGridView1.Columns["OgrDurum"].Visible = false;
        }


        private void IDlistele()
        {
            var degerler = from x in entity.TblOgrenciler
                           select new
                           {
                               x.OgrID,
                               x.OgrAd,
                               x.OgrSoyad,
                               x.OgrNumara,
                               x.OgrSifre,
                               x.OgrBolum,
                               x.TblBolumler.BolumAd,
                               x.OgrDurum
                           };
            dataGridView1.DataSource = degerler.Where(x=>x.OgrDurum == true && x.OgrID.ToString() == TxtAra.Text).ToList();
            dataGridView1.Columns["OgrBolum"].Visible = false;
            dataGridView1.Columns["OgrDurum"].Visible = false;
        }

        private void Bolumlistele()
        {
            var degerler = from x in entity.TblOgrenciler
                           select new
                           {
                               x.OgrID,
                               x.OgrAd,
                               x.OgrSoyad,
                               x.OgrNumara,
                               x.OgrSifre,
                               x.OgrBolum,
                               x.TblBolumler.BolumAd,
                               x.OgrDurum
                           };
            dataGridView1.DataSource = degerler.Where(x => x.OgrDurum == true && x.BolumAd == TxtAra.Text).ToList();
            dataGridView1.Columns["OgrBolum"].Visible = false;
            dataGridView1.Columns["OgrDurum"].Visible = false;
        }

        private void ogrenciekle()
        {
            TblOgrenciler ogr = new TblOgrenciler();
            ogr.OgrAd = TxtAd.Text;
            ogr.OgrSoyad = TxtSoyad.Text;
            ogr.OgrNumara = int.Parse(TxtNumara.Text);
            ogr.OgrSifre = TxtSifre.Text;
            ogr.OgrBolum = int.Parse(comboBox1.SelectedValue.ToString());
            ogr.OgrDurum = true;
            entity.TblOgrenciler.Add(ogr);
            entity.SaveChanges();
            MessageBox.Show("Öğrenci başarıyla eklendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }


        private void ogrencisil()
        {
            int id = int.Parse(TxtID.Text);
            var x = entity.TblOgrenciler.Find(id);
            x.OgrDurum = false;
            entity.SaveChanges();
            MessageBox.Show("Öğrenci başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void ogrenciguncelle()
        {
            int id = int.Parse(TxtID.Text);
            var x = entity.TblOgrenciler.Find(id);
            x.OgrAd = TxtAd.Text;
            x.OgrSoyad = TxtSoyad.Text;
            x.OgrNumara = int.Parse(TxtNumara.Text);
            x.OgrSifre = TxtSifre.Text;
            x.OgrBolum = int.Parse(comboBox1.SelectedValue.ToString());
            entity.SaveChanges();
            MessageBox.Show("Öğrenci başarıyla güncellendi");
            listele();
        }

        private void bolumler()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TblBolumler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "BolumID";
            comboBox1.DisplayMember = "BolumAd";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        DbOkulEntities entity = new DbOkulEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=ERTAN\SQLEXPRESS;Initial Catalog=DbOkul;Integrated Security=True");
        private void FrmOgrYonetim_Load(object sender, EventArgs e)
        {
            listele();
            bolumler();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtNumara.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtSifre.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private int kontrol()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TblOgrenciler WHERE OgrNumara = @p1",baglanti);
            komut.Parameters.AddWithValue("@p1",int.Parse(TxtNumara.Text));
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                baglanti.Close();
                return 1;
            }
            else
            {
                baglanti.Close();
                return 0;
            }
            
        }


        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            if (RdbID.Checked == true)
            {
                IDlistele();
            }
            else if(RdbBolum.Checked == true)
            {
                Bolumlistele();
            }
            else
            {
                MessageBox.Show("Lütfen bir kriter seçiniz","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            int sayac = kontrol();
            if(sayac == 0)
            {
                DialogResult a = MessageBox.Show("Eklemek istediğinize emin misiniz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                    ogrenciekle();
                }
                else if (a == DialogResult.No)
                {
                    MessageBox.Show("Öğrenci eklenmedi", "Bilgi");
                }
            }
            else
            {
                MessageBox.Show("Bu numara sisteme zaten kayıtlı", "Uyarı");
            }
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Silmek istediğinize emin misiniz ?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(a == DialogResult.Yes)
            {
                ogrencisil();
            }
            else if(a == DialogResult.No)
            {
                MessageBox.Show("Öğrenci silinmedi", "Bilgi");
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Güncellemek istediğinize emin misiniz ?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                ogrenciguncelle();
            }
            else if (a == DialogResult.No)
            {
                MessageBox.Show("Öğrenci güncellenmedi", "Bilgi");
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

        private void BtnSil_MouseEnter(object sender, EventArgs e)
        {
            BtnSil.BackColor = Color.Magenta;
        }

        private void BtnSil_MouseLeave(object sender, EventArgs e)
        {
            BtnSil.BackColor = Color.MediumVioletRed;
        }

        private void BtnGuncelle_MouseEnter(object sender, EventArgs e)
        {
            BtnGuncelle.BackColor = Color.Magenta;
        }

        private void BtnGuncelle_MouseLeave(object sender, EventArgs e)
        {
            BtnGuncelle.BackColor = Color.MediumVioletRed;
        }

        private void BtnAra_MouseEnter(object sender, EventArgs e)
        {
            BtnAra.BackColor = Color.Magenta;
        }

        private void BtnAra_MouseLeave(object sender, EventArgs e)
        {
            BtnAra.BackColor = Color.MediumVioletRed;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmAkademisyenYonlendirme ekran = new FrmAkademisyenYonlendirme();
            ekran.giris = yonetim;
            ekran.Show();
            this.Dispose();
        }
    }
}
