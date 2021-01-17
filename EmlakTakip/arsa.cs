using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EmlakTakip
{
    public partial class arsa : Form
    {
        public arsa()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti;
        OleDbCommand komut, komut2;
        OleDbDataAdapter da;
        public void Arsalar()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=emlakkayit.accdb");
            baglanti.Open();
            da = new OleDbDataAdapter("Select *From arsa", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
           
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void arsa_Load(object sender, EventArgs e)
        {
            Arsalar();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string sorgu = "Delete From arsa Where Adı=@adi";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@adi", dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Arsalar();
        }

        private void Güncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update arsa set Adı='" + textBox1.Text + "', Soyadı='" + textBox2.Text + "'," +
                " Telefon='" + textBox3.Text + "', Baslık='" + textBox4.Text + "', m2='" + textBox5.Text + "', Durum='" + comboBox1.Text + "', " +
                "Fiyat='" + textBox6.Text + "',İlce='" + textBox7.Text + "',İl='" + textBox8.Text + "'  where Adı='" + textBox1.Text + "' ", baglanti);
            komut.ExecuteNonQuery();

            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

            Arsalar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=emlakkayit.accdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from arsa where Adı='" + textBox1.Text + "' ", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox2.Text = oku["Soyadı"].ToString();
                textBox3.Text = oku["Telefon"].ToString();
                textBox4.Text = oku["Baslık"].ToString();
                textBox5.Text = oku["m2"].ToString();
                comboBox1.Text = oku["Durum"].ToString();
                textBox6.Text = oku["Fiyat"].ToString();
                textBox7.Text = oku["İlce"].ToString();
                textBox8.Text = oku["İl"].ToString();
                
            }
            baglanti.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            da = new OleDbDataAdapter("Select *From arsa where Adı like '"+textBox9.Text+"%' or Durum like '"+textBox9.Text+ "%'  or İl like '" + textBox9.Text + "%'   ", baglanti);
            DataTable tablo2 = new DataTable();
            da.Fill(tablo2);

            dataGridView1.DataSource = tablo2;
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            
        }

        private void arsa_Load_1(object sender, EventArgs e)
        {

        }

        private void Kaydet_Click(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=emlakkayit.accdb");
            baglanti.Open();
            string sorgu = "Insert into arsa(Adı,Soyadı,Telefon,Baslık,m2,Durum,Fiyat,İlce,İl) " + "values (@adi,@soyadi,@telefon,@baslik,@mkare,@durum,@fiyat,@ilce,@il)";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@adi", textBox1.Text);
            komut.Parameters.AddWithValue("@soyadi", textBox2.Text);
            komut.Parameters.AddWithValue("@telefon", textBox3.Text);
            komut.Parameters.AddWithValue("@baslik", textBox4.Text);
            komut.Parameters.AddWithValue("@mkare", textBox5.Text);
            komut.Parameters.AddWithValue("@bdurum", comboBox1.Text);
            komut.Parameters.AddWithValue("@fiyat", textBox6.Text);
            komut.Parameters.AddWithValue("@ilce", textBox7.Text);
            komut.Parameters.AddWithValue("@il", textBox8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            Arsalar();
        }

        



    }
}
