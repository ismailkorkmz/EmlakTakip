using System;
using EmlakTakip;
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
    public partial class musteri : Form
    {
        public musteri()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti;
        OleDbCommand komut, komut2;
        OleDbDataAdapter da;

        public void Baglanti()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=emlakkayit.accdb");
            baglanti.Open();
            da = new OleDbDataAdapter("Select *From musteri", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void Kaydet_Click(object sender, EventArgs e) 
        {
            baglanti.Open();
            string sorgu = "Insert into musteri(TC,Adı,Soyadı,İl,Telefon,Adres) " +
                "values (@tckimlik,@adi,@soyadi,@il,@telefon,@adres)";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@tckimlik", textBox1.Text);
            komut.Parameters.AddWithValue("@adi", textBox2.Text);
            komut.Parameters.AddWithValue("@soyadi", textBox3.Text);
            komut.Parameters.AddWithValue("@il", textBox4.Text);
            komut.Parameters.AddWithValue("@telefon", textBox5.Text);
            komut.Parameters.AddWithValue("@adres", textBox6.Text);
            komut.Parameters.AddWithValue("@tckimlik", dataGridView1.CurrentRow.Cells[0].Value);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Baglanti();
        }

        private void Güncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update musteri set TC='" + textBox1.Text + "', Adı='" + textBox2.Text + "', Soyadı='" + textBox3.Text + "', " +
                "İl='" + textBox4.Text + "', Telefon='" + textBox5.Text + "', Adres='" + textBox6.Text + "' where tc='" + textBox1.Text + "' ", baglanti);
            komut.ExecuteNonQuery();

            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            Baglanti();
            

        }
        private void Sil_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From musteri Where TC=@TC";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@TC", dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Baglanti();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from musteri where TC='" +textBox1.Text+ "' ", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox2.Text = oku["Adı"].ToString();
                textBox3.Text = oku["Soyadı"].ToString();
                textBox4.Text = oku["İl"].ToString();
                textBox5.Text = oku["Telefon"].ToString();
                textBox6.Text = oku["Adres"].ToString();
            }
            baglanti.Close();

        }

        private void Arama_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            da = new OleDbDataAdapter("Select *From musteri where Adı like '" + Arama.Text + "%' or TC like '" + Arama.Text + "%' or Adres like '" + Arama.Text + "%'    ", baglanti);
            DataTable tablo2 = new DataTable();
            da.Fill(tablo2);

            dataGridView1.DataSource = tablo2;
            baglanti.Close();
        }

        private void Temizle_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            Arama.Clear();

        }

        private void musteri_Load(object sender, EventArgs e)
        {
            Baglanti();
        }
    }
}
