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
    public partial class turistliktesis : Form
    {
        public turistliktesis()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti;
        OleDbCommand komut, komut2;
        OleDbDataAdapter da;
        public void Turist()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=emlakkayit.accdb");
            baglanti.Open();
            da = new OleDbDataAdapter("Select *From turistliktesis", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=emlakkayit.accdb");
            baglanti.Open();
            string sorgu = "Insert into turistliktesis(Adı,Soyadı,Telefon,EmlakTipi,OdaSayısı,Durum,YatakSayısı,KatSayısı,BinaYası,m2,ZeminEtütü,Fiyat,Adres) "
                + "values (@adi,@soyadi,@telefon,@etipi,@osayisi,@durum,@ysayisi,@ksayisi,@binayasi,@m2,@zeminetütü,@fiyat,@adres)";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@adi", textBox1.Text);
            komut.Parameters.AddWithValue("@soyadi", textBox2.Text);
            komut.Parameters.AddWithValue("@telefon", textBox3.Text);
            komut.Parameters.AddWithValue("@etipi", textBox4.Text);
            komut.Parameters.AddWithValue("@osayisi", textBox5.Text);
            komut.Parameters.AddWithValue("@durum", comboBox1.Text);
            komut.Parameters.AddWithValue("@ysayisi", textBox6.Text);
            komut.Parameters.AddWithValue("@ksayisi", textBox7.Text);
            komut.Parameters.AddWithValue("@binayasi", textBox8.Text);
            komut.Parameters.AddWithValue("@m2", textBox9.Text);
            komut.Parameters.AddWithValue("@zeminetütü", textBox10.Text);
            komut.Parameters.AddWithValue("@fiyat", textBox11.Text);
            komut.Parameters.AddWithValue("@adres", textBox11.Text);

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
            textBox12.Clear();
            Turist();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=emlakkayit.accdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from turistliktesis where Adı='" + textBox1.Text + "' ", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox2.Text = oku["Soyadı"].ToString();
                textBox3.Text = oku["Telefon"].ToString();
                textBox4.Text = oku["EmlakTipi"].ToString();
                textBox5.Text = oku["OdaSayısı"].ToString();
                comboBox1.Text = oku["Durum"].ToString();
                textBox6.Text = oku["YatakSayısı"].ToString();
                textBox7.Text = oku["KatSayısı"].ToString();
                textBox8.Text = oku["BinaYası"].ToString();
                textBox9.Text = oku["m2"].ToString();
                textBox10.Text = oku["ZeminEtütü"].ToString();
                textBox11.Text = oku["Fiyat"].ToString();
                textBox12.Text = oku["Adres"].ToString();
            }
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From turistliktesis Where Adı=@adi";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@adi", dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Turist();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update turistliktesis set  Adı='" + textBox1.Text + "', Soyadı='" + textBox2.Text + "', Telefon='" + textBox3.Text + "', EmlakTipi='" + textBox4.Text + "', OdaSayısı='" + textBox5.Text + "', Durum='" + comboBox1.Text + "', YatakSayısı='" + textBox6.Text + "', KatSayısı='" + textBox7.Text + "', BinaYası='" + textBox8.Text + "', m2='" + textBox9.Text + "', ZeminEtütü='" + textBox10.Text + "', Fiyat='" + textBox11.Text + "', Adres='"+textBox12.Text+"'   where Adı='" + textBox1.Text + "' ", baglanti);
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
            textBox12.Clear();
            Turist();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            da = new OleDbDataAdapter("Select *From turistliktesis where Adı like '" + textBox13.Text + "%' or Adres like '" + textBox13.Text + "%'  or Durum like '" + textBox13.Text + "%'   ", baglanti);
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
            textBox13.Clear();
        }

        private void turistliktesis_Load(object sender, EventArgs e)
        {
            Turist();
        }
    }
}
