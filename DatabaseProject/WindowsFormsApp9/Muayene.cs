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
    public partial class Muayene : Form
    {
        public Muayene()
        {
            InitializeComponent();
            baglanti.Open();
            string sorgu = "select muayene.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , muayene.muayene_id as muayeneID, muayene.teshis from muayene " +
                         "inner join doktor on doktor.id=muayene.doktor_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Hastane; user ID=postgres; password=12345");
        private void Muayene_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            string sorgu = "select * from doktor";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);  
            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.Columns.Add(
             "adsoyad",
             typeof(string),
             "ad + ' ' + soyad ");

            comboBox1.DisplayMember = "adsoyad";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dt;

            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into muayene (hasta_tc,doktor_id,muayene_id,teshis) values (@p1,@p2,@p3,@p4)", baglanti);
            komut1.Parameters.AddWithValue("@p1", Convert.ToInt64(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", int.Parse( comboBox1.SelectedValue.ToString()));
            komut1.Parameters.AddWithValue("@p3", int.Parse(textBox4.Text));
            komut1.Parameters.AddWithValue("@p4", textBox3.Text);
            komut1.ExecuteNonQuery();
            string sorgu = "select muayene.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , muayene.muayene_id as muayeneID, muayene.teshis from muayene " +
                         "inner join doktor on doktor.id=muayene.doktor_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from muayene where muayene_id=@p1 ", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox4.Text));
            komut1.ExecuteNonQuery();
            string sorgu = "select muayene.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , muayene.muayene_id as muayeneID, muayene.teshis from muayene " +
                         "inner join doktor on doktor.id=muayene.doktor_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("update muayene set hasta_tc=@p1,doktor_id=@p2,teshis=@p4 where muayene_id=@p3", baglanti);
            komut1.Parameters.AddWithValue("@p1", Convert.ToInt64(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", int.Parse(comboBox1.SelectedValue.ToString()));
            komut1.Parameters.AddWithValue("@p3", int.Parse(textBox4.Text));
            komut1.Parameters.AddWithValue("@p4", textBox3.Text);
            komut1.ExecuteNonQuery();
            string sorgu = "select muayene.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , muayene.muayene_id as muayeneID, muayene.teshis from muayene " +
                         "inner join doktor on doktor.id=muayene.doktor_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
    }
}
