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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=emlakkayit.accdb");
        DataTable tablo = new DataTable();
        DataTable tablo2 = new DataTable();
        
       

       

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void müşteriKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form mus = new musteri();
            mus.Show();
        }

        private void müstakilEvlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ev = new ev();
            ev.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void arsalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form arsa = new arsa();
            arsa.Show();
        }

        private void işYeriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form isyeri = new isyeri();
            isyeri.Show();
        }

        private void turistlikTesisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form turistliktesis = new turistliktesis();
            turistliktesis.Show();
        }

       
    }
}
