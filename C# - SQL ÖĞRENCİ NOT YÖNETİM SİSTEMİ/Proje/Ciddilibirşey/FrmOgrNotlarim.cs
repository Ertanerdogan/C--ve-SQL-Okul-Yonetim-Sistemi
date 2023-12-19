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
    public partial class FrmOgrNotlarim : Form
    {
        public FrmOgrNotlarim()
        {
            InitializeComponent();
        }
        public int kod;
        DbOkulEntities db = new DbOkulEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=ERTAN\SQLEXPRESS;Initial Catalog=DbOkul;Integrated Security=True");
        private void not()
        {
            var degerler = from x in db.TblNotlar
                           select new
                           {
                               x.NotDers,
                               x.TblDersler.DersAd,
                               x.NotOgr,
                               x.NotVize,
                               x.NotFinal,
                               x.NotQuiz,
                               x.NotOrt
                           };
            dataGridView1.DataSource = degerler.Where(x => x.NotOgr == kod).ToList();
            dataGridView1.Columns["NotDers"].Visible = false;
            dataGridView1.Columns["NotOgr"].Visible = false;
        }

        private void ders()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TblDersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "DersID";
            comboBox1.DisplayMember = "DersAd";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }
        private void FrmOgrNotlarim_Load(object sender, EventArgs e)
        {
            not();
            ders();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                TxtDers.Text = dataGridView1.Rows[e.RowIndex].Cells["DersAd"].Value.ToString();
                TxtVize.Text = dataGridView1.Rows[e.RowIndex].Cells["NotVize"].Value.ToString();
                TxtFinal.Text = dataGridView1.Rows[e.RowIndex].Cells["NotFinal"].Value.ToString();
                TxtQuiz.Text = dataGridView1.Rows[e.RowIndex].Cells["NotQuiz"].Value.ToString();
                TxtOrt.Text = dataGridView1.Rows[e.RowIndex].Cells["NotOrt"].Value.ToString();
            }
        }

        private void BtnYenile_MouseEnter(object sender, EventArgs e)
        {
            BtnYenile.BackColor = Color.Magenta;
        }

        private void BtnYenile_MouseLeave(object sender, EventArgs e)
        {
            BtnYenile.BackColor = Color.MediumVioletRed;
        }

        private void BtnYenile_Click(object sender, EventArgs e)
        {
            TxtDers.Text = "";
            TxtVize.Text = "";
            TxtFinal.Text = "";
            TxtQuiz.Text = "";
            TxtOrt.Text = "";
            not();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgrenciYonlendirme ekran = new FrmOgrenciYonlendirme();
            ekran.ogrenci = kod;
            ekran.Show();
            this.Dispose();
        }

        private void BtnAra_MouseEnter(object sender, EventArgs e)
        {
            BtnAra.BackColor = Color.Magenta;
        }

        private void BtnAra_MouseLeave(object sender, EventArgs e)
        {
            BtnAra.BackColor= Color.MediumVioletRed;
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TblNotlar
                           select new
                           {
                               x.NotDers,
                               x.TblDersler.DersAd,
                               x.NotOgr,
                               x.NotVize,
                               x.NotFinal,
                               x.NotQuiz,
                               x.NotOrt
                           };
            dataGridView1.DataSource = degerler.Where(x => x.NotOgr == kod && comboBox1.SelectedValue.ToString() == x.NotDers.ToString()).ToList();
            dataGridView1.Columns["NotDers"].Visible = false;
            dataGridView1.Columns["NotOgr"].Visible = false;
        }
    }
}
