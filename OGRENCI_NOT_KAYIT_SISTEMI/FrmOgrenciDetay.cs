using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace OGRENCI_NOT_KAYIT_SISTEMI
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        public string numara;

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-JJBSGN9K\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True");


        //Data Source=LAPTOP-JJBSGN9K\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            lblNum.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLDERS where OGRNUMARA=@P1", baglanti);
            komut.Parameters.AddWithValue("@P1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while ( dr.Read())
            {

                lblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                lblSnv1.Text = dr[4].ToString();
                lblSnv2.Text = dr[5].ToString();
                lblSnv3.Text = dr[6].ToString();
                lblOrt.Text = dr[7].ToString();
                lblDurum.Text = dr[8].ToString();

            }

            baglanti.Close();

        }
    }
}
