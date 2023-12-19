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
    public partial class FrmAkademisyenler : Form
    {
        public FrmAkademisyenler()
        {
            InitializeComponent();
        }
        public int aka;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgrenciYonlendirme ekran = new FrmOgrenciYonlendirme();
            ekran.ogrenci = aka;
            ekran.Show();
            this.Dispose();
        }
        DbOkulEntities db = new DbOkulEntities();

        private void akademisyen()
        {
            var degerler = from x in db.TblAkademisyen
                           select new
                           {
                               x.AkademisyenID,
                               x.AkademisyenAd,
                               x.AkademisyenSoyad,
                               x.AkademisyenDers,
                               x.TblDersler.DersAd
                           };
            dataGridView1.DataSource = degerler.ToList();
            dataGridView1.Columns["AkademisyenDers"].Visible = false;
        }
        private void FrmAkademisyenler_Load(object sender, EventArgs e)
        {
            akademisyen();
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
            akademisyen();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtDers.Text = dataGridView1.Rows[e.RowIndex].Cells["DersAd"].Value.ToString();
            }
        }
    }
}
