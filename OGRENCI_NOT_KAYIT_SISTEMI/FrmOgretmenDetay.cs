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
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }

        

        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dbNotKayitDataSet.TBLDERS' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);

        }


        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-JJBSGN9K\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@p1,@p2,@p3)", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(MskNum.Text));
            komut3.Parameters.AddWithValue("@p2", txtAd.Text);
            komut3.Parameters.AddWithValue("@p3", txtSoyAd.Text);
           
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ogrencı kaydedildi.");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;




            MskNum.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtSoyAd.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            txtSnv1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSnv2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtSnv3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            double ortalama, s1, s2, s3;
            s1= Convert.ToDouble(txtSnv1.Text);
            s2= Convert.ToDouble(txtSnv2.Text);
            s3= Convert.ToDouble(txtSnv3.Text);

            ortalama = (s1 + s2 + s3) / 3;
            lblOrt.Text=ortalama.ToString();
            string durum;
            if(ortalama>=50)
            {
                durum = "true";
            }
            else
            {
                durum = "false";
            }

        
            
      
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("UPDATE TBLDERS SET OGRS1=@P1, OGRS2=@P2, OGRS3=@P3, ORTALAMA=@P4, DURUM=@P5 WHERE OGRNUMARA=@P6", baglanti);
            komut3.Parameters.AddWithValue("@P1", (txtSnv1.Text));
            komut3.Parameters.AddWithValue("@P2", (txtSnv2.Text));
            komut3.Parameters.AddWithValue("@P3", (txtSnv3.Text));
            komut3.Parameters.AddWithValue("@P4", decimal.Parse(lblOrt.Text));
            komut3.Parameters.AddWithValue("@P5", durum);
            komut3.Parameters.AddWithValue("@P6", (MskNum.Text));


            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("guncelleme gerceklesti.");


            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);


        }

        private void button3_Click(object sender, EventArgs e)
        {


            int gecen = 0, kalan = 0; int i = 0;



            while (dataGridView1.Rows[i].Cells[0].Value != null)

            {

                if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "True")

                    gecen = gecen + 1;

                if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "False")

                    kalan++;

                i++;

            }

            lblKlnSay.Text = kalan.ToString();

            lblGcnSay.Text = gecen.ToString();

        }





    }
    
}
