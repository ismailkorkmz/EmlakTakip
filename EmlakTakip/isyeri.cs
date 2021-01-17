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
    public partial class isyeri : Form
    {
        public isyeri()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti;
        OleDbCommand komut, komut2;
        OleDbDataAdapter da;
        public void İsYeri()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=emlakkayit.accdb");
            baglanti.Open();
            da = new OleDbDataAdapter("Select *From isyeri", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=emlakkayit.accdb");
            baglanti.Open();
            string sorgu = "Insert into isyeri(Adı,Soyadı,Telefon,EmlakTürü,m2,Durum,BinaYası,Isıtma,OdaSayısı,Fiyat,Adres,Acıklama) " 
                + "values (@adi,@soyadi,@telefon,@etürü,@mkare,@durum,@binayasi,@isitma,@osayisi,@fiyat,@adres,@aciklama)";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@adi", textBox1.Text);
            komut.Parameters.AddWithValue("@soyadi", textBox2.Text);
            komut.Parameters.AddWithValue("@telefon", textBox3.Text);
            komut.Parameters.AddWithValue("@etürü", textBox4.Text);
            komut.Parameters.AddWithValue("@mkare", textBox5.Text);
            komut.Parameters.AddWithValue("@durum", comboBox1.Text);
            komut.Parameters.AddWithValue("@binayasi", textBox6.Text);
            komut.Parameters.AddWithValue("@isitma", textBox7.Text);
            komut.Parameters.AddWithValue("@osayisi", textBox8.Text);
            komut.Parameters.AddWithValue("@fiyat", textBox9.Text);
            komut.Parameters.AddWithValue("@adres", textBox10.Text);
            komut.Parameters.AddWithValue("@aciklama", textBox11.Text);
           
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
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            İsYeri();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From isyeri Where Adı=@adi";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@adi", dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            İsYeri();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update isyeri set  Adı='" + textBox1.Text + "', Soyadı='" + textBox2.Text + "', Telefon='" + textBox3.Text + "', EmlakTürü='" + textBox4.Text + "', m2='" + textBox5.Text + "', Durum='"+comboBox1.Text+"', BinaYası='"+textBox6.Text+"', Isıtma='"+textBox7.Text+"', OdaSayısı='"+textBox8.Text+"', Fiyat='"+textBox9.Text+"', Adres='"+textBox10.Text+"', Acıklama='"+textBox11.Text+"'  where Adı='" + textBox1.Text + "' ", baglanti);
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
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();

            İsYeri();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=emlakkayit.accdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from isyeri where Adı='" + textBox1.Text + "' ", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox2.Text = oku["Soyadı"].ToString();
                textBox3.Text = oku["Telefon"].ToString();
                textBox4.Text = oku["EmlakTürü"].ToString();
                textBox5.Text = oku["m2"].ToString();
                comboBox1.Text = oku["Durum"].ToString();
                textBox6.Text = oku["BinaYası"].ToString();
                textBox7.Text = oku["Isıtma"].ToString();
                textBox8.Text = oku["OdaSayısı"].ToString();
                textBox9.Text = oku["Fiyat"].ToString();
                textBox10.Text = oku["Adres"].ToString();
                textBox11.Text = oku["Acıklama"].ToString();
            }
            baglanti.Close();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            da = new OleDbDataAdapter("Select *From isyeri where Adı like '" + textBox12.Text + "%' or EmlakTürü like '" + textBox12.Text + "%'  or Fiyat like '" + textBox12.Text + "%'   ", baglanti);
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
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
        }

        private void isyeri_Load(object sender, EventArgs e)
        {
            İsYeri();
        }
    }
}
