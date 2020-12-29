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
    public partial class Doktor : Form
    {
        public Doktor()
        {
            InitializeComponent();
            baglanti.Open();
            string sorgu = "select * from doktor order by id asc";
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
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into doktor (id,ad,soyad,brans,telefon) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox5.Text);
            komut1.Parameters.AddWithValue("@p3", textBox4.Text);
            komut1.Parameters.AddWithValue("@p4", comboBox1.SelectedValue.ToString());
            komut1.Parameters.AddWithValue("@p5", textBox3.Text);
            komut1.ExecuteNonQuery();
            string sorgu = "select * from doktor order by id asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Doktor_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from brans";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "brans_adi";
            comboBox1.ValueMember = "brans_adi";
            comboBox1.DataSource = dt;

            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from doktor where id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.ExecuteNonQuery();
            string sorgu = "select * from doktor order by id asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("update doktor set ad=@p2,soyad=@p3,brans=@p4,telefon=@p5 where id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox5.Text);
            komut1.Parameters.AddWithValue("@p3", textBox4.Text);
            komut1.Parameters.AddWithValue("@p4", comboBox1.SelectedValue.ToString());
            komut1.Parameters.AddWithValue("@p5", textBox3.Text);
            komut1.ExecuteNonQuery();
            string sorgu = "select * from doktor order by id asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from doktor where id = @p1", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            baglanti.Close();
        }
    }
}
