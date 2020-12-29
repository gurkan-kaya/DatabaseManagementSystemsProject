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
    public partial class Randevu : Form
    {
        public Randevu()
        {
            InitializeComponent();
            baglanti.Open();
            string sorgu = "select randevu.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , randevu.randevu_id as randevuID, randevu.tarih from randevu " +
            "inner join doktor on doktor.id=randevu.doktor_id";

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
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into randevu (hasta_tc,doktor_id,tarih,randevu_id) values (@p1,@p2,@p3,@p4)", baglanti);
            komut1.Parameters.AddWithValue("@p1",Convert.ToInt64(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", int.Parse(comboBox1.SelectedValue.ToString()));
            komut1.Parameters.AddWithValue("@p3", DateTime.Parse( maskedTextBox1.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBox3.Text));
            komut1.ExecuteNonQuery();

            string sorgu = "select randevu.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , randevu.randevu_id as randevuID, randevu.tarih from randevu " +
             "inner join doktor on doktor.id=randevu.doktor_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from randevu where randevu_id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
            komut1.ExecuteNonQuery();
            string sorgu = "select randevu.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , randevu.randevu_id as randevuID, randevu.tarih from randevu " +
            "inner join doktor on doktor.id=randevu.doktor_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Randevu_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("update randevu set hasta_tc=@p1,doktor_id=@p2,tarih=@p3 where randevu_id=@p4", baglanti);
            komut1.Parameters.AddWithValue("@p1", Convert.ToInt64(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", int.Parse(comboBox1.SelectedValue.ToString()));
            komut1.Parameters.AddWithValue("@p3", DateTime.Parse(maskedTextBox1.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBox3.Text));
            komut1.ExecuteNonQuery();

            string sorgu = "select randevu.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , randevu.randevu_id as randevuID, randevu.tarih from randevu " +
             "inner join doktor on doktor.id=randevu.doktor_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
    }
}
