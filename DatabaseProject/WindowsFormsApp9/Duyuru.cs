using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace WindowsFormsApp9
{
    public partial class Duyuru : Form
    {
      
        public Duyuru()
        {
            InitializeComponent();
            string sorgu = "select * from duyurular ORDER BY id ASC";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Hastane; user ID=postgres; password=12345");
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand kmt = new NpgsqlCommand(@"duyuru_ekle", baglanti);
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("id", int.Parse(textBox5.Text));
            kmt.Parameters.AddWithValue("baslik", textBox1.Text);
            kmt.Parameters.AddWithValue("aciklama", textBox2.Text);
            kmt.ExecuteNonQuery();
            string sorgu = "select * from duyurular ORDER BY id ASC";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from duyurular where id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox5.Text));
            komut1.ExecuteNonQuery();
            string sorgu = "select * from duyurular ORDER BY id ASC";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand kmt3 = new NpgsqlCommand("update duyurular set baslik=@p2,aciklama=@p3 where id=@p1" , baglanti);
            kmt3.Parameters.AddWithValue("@p1", int.Parse(textBox5.Text));
            kmt3.Parameters.AddWithValue("@p2", textBox1.Text);
            kmt3.Parameters.AddWithValue("@p3", textBox2.Text);
            kmt3.ExecuteNonQuery();
            string sorgu = "select * from duyurular ORDER BY id ASC";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
    }
}
