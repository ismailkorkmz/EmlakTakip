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
    public partial class ev : Form
    {
        public ev()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti;
        OleDbCommand komut, komut2;
        OleDbDataAdapter da;

        public void Evler()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=emlakkayit.accdb");
            baglanti.Open();
            da = new OleDbDataAdapter("Select *From ev", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void Güncelle_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update ev set ID='" + textBox6.Text + "', Adres='" + textBox1.Text + "', KatSayısı='" + textBox2.Text + "'," +
                " OdaSayısı='" + textBox3.Text + "', Durum='" + comboBox1.Text + "', BinaYası='" + textBox4.Text + "', " +
                "Fiyat='" + textBox5.Text + "' where ID='" + textBox6.Text + "' ", baglanti);
            komut.ExecuteNonQuery();

            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            Evler();
        }

        private void Sil_Click(object sender, EventArgs e)
        {
            
            string sorgu = "Delete From ev Where ID=@id";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Evler();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ev_Load(object sender, EventArgs e)
        {
            Evler();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=emlakkayit.accdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from ev where ID='" + textBox6.Text + "' ", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox1.Text = oku["Adres"].ToString();
                textBox2.Text = oku["KatSayısı"].ToString();
                textBox3.Text = oku["OdaSayısı"].ToString();
                comboBox1.Text = oku["Durum"].ToString();
                textBox4.Text = oku["BinaYası"].ToString();
                textBox5.Text = oku["Fiyat"].ToString();
            }
            baglanti.Close();
        }

        private void Arama_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            da = new OleDbDataAdapter("Select *From ev where ID like '" + Arama.Text + "%' " +"or Fiyat like '" + Arama.Text + "%'  or Adres like '" + Arama.Text + "%'   ", baglanti);
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

        private void Kaydet_Click(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=emlakkayit.accdb");
            baglanti.Open();
            string sorgu = "Insert into ev(ID,Adres,KatSayısı,OdaSayısı,Durum,BinaYası,Fiyat) " + "values (@id,@adres,@ksayisi,@osayisi,@durum,@binayasi,@fiyat)";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", textBox6.Text);
            komut.Parameters.AddWithValue("@adres", textBox1.Text);
            komut.Parameters.AddWithValue("@ksayisi", textBox2.Text);
            komut.Parameters.AddWithValue("@osayisi", textBox3.Text);
            komut.Parameters.AddWithValue("@durum", comboBox1.Text);
            komut.Parameters.AddWithValue("@binayasi", textBox4.Text);
            komut.Parameters.AddWithValue("@fiyat", textBox5.Text);
            
            komut.ExecuteNonQuery();
            baglanti.Close();
            
            Evler();
        }
    }
}
