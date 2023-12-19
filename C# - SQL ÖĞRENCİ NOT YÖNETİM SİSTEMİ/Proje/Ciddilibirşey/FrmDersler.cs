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
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        public int ders;

        private void BtnYenile_MouseEnter(object sender, EventArgs e)
        {
            BtnYenile.BackColor = Color.Magenta;
        }
        DbOkulEntities db = new DbOkulEntities();

        private void fonk()
        {
            var degerler = from x in db.TblDersler
                           select new
                           {
                               x.DersID,
                               x.DersAd
                           };
            dataGridView1.DataSource = degerler.ToList();
        }
        private void BtnYenile_MouseLeave(object sender, EventArgs e)
        {
            BtnYenile.BackColor = Color.MediumVioletRed;
        }

        private void BtnYenile_Click(object sender, EventArgs e)
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            fonk();
        }

        private void FrmDersler_Load(object sender, EventArgs e)
        {
            fonk();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgrenciYonlendirme ekran = new FrmOgrenciYonlendirme();
            ekran.ogrenci = ders;
            ekran.Show();
            this.Dispose();
        }
    }
}
