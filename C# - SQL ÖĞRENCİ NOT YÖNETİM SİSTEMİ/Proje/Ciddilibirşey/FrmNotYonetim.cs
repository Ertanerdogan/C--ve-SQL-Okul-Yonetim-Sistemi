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
    public partial class FrmNotYonetim : Form
    {
        public int not;
        public FrmNotYonetim()
        {
            InitializeComponent();
        }
        DbOkulEntities db = new DbOkulEntities();
        private void ogrlistele()
        {
            var degerler = from x in db.TblOgrenciler
                           select new
                           {
                               x.OgrID,
                               x.OgrAd,
                               x.OgrSoyad
                           };
            dataGridView1.DataSource = degerler.ToList();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=ERTAN\SQLEXPRESS;Initial Catalog=DbOkul;Integrated Security=True");
        private void box()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TblDersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "DersID";
            comboBox1.DisplayMember = "DersAd";
            comboBox1.DataSource = dt;
        }

        private void notlistele()
        {
            var degerler = from x in db.TblNotlar
                           select new
                           {
                               x.NotID,
                               x.NotDers,
                               x.TblDersler.DersAd,
                               x.NotOgr,
                               x.TblOgrenciler.OgrAd,
                               x.NotVize,
                               x.NotFinal,
                               x.NotQuiz,
                               x.NotOrt
                           };
            dataGridView2.DataSource = degerler.ToList();
            dataGridView2.Columns["NotDers"].Visible = false;
            dataGridView2.Columns["NotOgr"].Visible = false;
        }

        private void FrmNotYonetim_Load(object sender, EventArgs e)
        {
            ogrlistele();
            notlistele();
            box();
        }

        private void temizle()
        {
            TxtNotID.Text = "";
            TxtOgr.Text = "";
            TxtFinal.Text = "";
            TxtQuiz.Text = "";
            TxtVize.Text = "";
            TxtOrt.Text = "";
        }

        int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                temizle();
                TxtOgr.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                TxtNotID.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboBox1.SelectedValue = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtOgr.Text = dataGridView2.Rows[e.RowIndex].Cells["NotOgr"].Value.ToString();
                TxtVize.Text = dataGridView2.Rows[e.RowIndex].Cells["NotVize"].Value.ToString();
                TxtFinal.Text = dataGridView2.Rows[e.RowIndex].Cells["NotFinal"].Value.ToString();
                TxtQuiz.Text = dataGridView2.Rows[e.RowIndex].Cells["NotQuiz"].Value.ToString();
                double ortalama = (double.Parse(TxtVize.Text) *30 ) / 100 + (double.Parse(TxtFinal.Text) * 50) / 100 +
                    (double.Parse(TxtQuiz.Text) * 20) / 100;
                TxtOrt.Text = ortalama.ToString();
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

        private void BtnListele_Click(object sender, EventArgs e)
        {
            notlistele();
            temizle();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            
            if(TxtFinal.Text !="" && TxtVize.Text != "" &&  TxtQuiz.Text != "" && TxtOrt.Text != "")
            {
                DialogResult a = MessageBox.Show("Not eklemek istediğinize emin misiniz ?", "Soru", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                    TblNotlar x = new TblNotlar();
                    x.NotDers = int.Parse(comboBox1.SelectedValue.ToString());
                    x.NotOgr = id;
                    x.NotVize = int.Parse(TxtVize.Text);
                    x.NotFinal = int.Parse(TxtFinal.Text);
                    x.NotQuiz = int.Parse(TxtQuiz.Text);
                    x.NotOrt = int.Parse(TxtOrt.Text);
                    db.TblNotlar.Add(x);
                    db.SaveChanges();
                    MessageBox.Show("Not başarıyla eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    notlistele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Not eklenmedi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen notları giriniz","Uyarı");
            }
        }

        private void BtnHesapla_MouseEnter(object sender, EventArgs e)
        {
            BtnHesapla.BackColor = Color.Magenta;
        }

        private void BtnHesapla_MouseLeave(object sender, EventArgs e)
        {
            BtnHesapla.BackColor = Color.MediumVioletRed;
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            if(TxtFinal.Text != "" && TxtQuiz.Text != "" && TxtVize.Text != "")
            {
                int ortalama = (int.Parse(TxtVize.Text) * 30) / 100 + (int.Parse(TxtFinal.Text) * 50) / 100 +
                                    (int.Parse(TxtQuiz.Text) * 20) / 100;
               
                TxtOrt.Text = ortalama.ToString();
            }
            else
            {
                MessageBox.Show("Lütfen sınav notlarını giriniz","Uyarı");
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if(TxtNotID.Text != "")
            {
                DialogResult b = MessageBox.Show("Notu silmek istediğinize emin misiniz ?","Soru",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(b == DialogResult.Yes)
                {
                    int notid = int.Parse(TxtNotID.Text);
                    var deger = db.TblNotlar.Find(notid);
                    db.TblNotlar.Remove(deger);
                    db.SaveChanges();
                    MessageBox.Show("Not başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    notlistele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Not silinmedi", "Bilgi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek notu seçiniz","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmAkademisyenYonlendirme ekran = new FrmAkademisyenYonlendirme();
            ekran.giris = not;
            ekran.Show();
            this.Dispose();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            if(TxtOrt.Text != "" && TxtFinal.Text != "" && TxtVize.Text != "")
            {
                DialogResult c = MessageBox.Show("Notu güncellemek istediğinize emin misiniz ?", "Soru",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(c == DialogResult.Yes)
                {
                    int gid = int.Parse(TxtNotID.Text);
                    var x = db.TblNotlar.Find(gid);
                    x.NotDers = int.Parse(comboBox1.SelectedValue.ToString());
                    x.NotOgr = int.Parse(TxtOgr.Text.ToString());
                    x.NotVize = int.Parse(TxtVize.Text);
                    x.NotFinal = int.Parse(TxtFinal.Text);
                    x.NotQuiz = int.Parse(TxtQuiz.Text);
                    x.NotOrt = int.Parse(TxtOrt.Text);
                    db.SaveChanges();
                    MessageBox.Show("Not başarıyla güncellendi", "Bilgi");
                    notlistele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Not güncellenmedi","Bilgi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz notu seçiniz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
