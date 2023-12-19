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
    public partial class FrmOgrenciGiris : Form
    {
        public FrmOgrenciGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=ERTAN\SQLEXPRESS;Initial Catalog=DbOkul;Integrated Security=True");

        private void BtnGiris_MouseEnter(object sender, EventArgs e)
        {
            BtnGiris.BackColor = Color.Magenta;
        }

        private void BtnGiris_MouseLeave(object sender, EventArgs e)
        {
            BtnGiris.BackColor = Color.MediumVioletRed;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmSecenek ekran = new FrmSecenek();
            ekran.Show();
            this.Dispose();
        }
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TblOgrenciler WHERE OgrNumara = @p1 and OgrSifre = @p2 and OgrID = @p3", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtNumara.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            komut.Parameters.AddWithValue("@p3", TxtID.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                FrmOgrenciYonlendirme ekran = new FrmOgrenciYonlendirme();
                ekran.ogrenci = int.Parse(TxtID.Text);
                ekran.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Numaranız veya şifreniz hatalı","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            baglanti.Close();
        }
    }
}
