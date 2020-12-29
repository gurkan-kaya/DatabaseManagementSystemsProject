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
    public partial class Yatis : Form
    {
        public Yatis()
        {
            InitializeComponent();
            baglanti.Open();
            string sorgu = "select * from yatis order by id asc";
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
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into yatis (hasta_tc,oda_no,yatilacak_gun,id) values (@p1,@p2,@p3,@p4)", baglanti);
            komut1.Parameters.AddWithValue("@p1", Convert.ToInt64(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", Convert.ToInt32(textBox5.Text));
            komut1.Parameters.AddWithValue("@p3", Convert.ToInt32(textBox4.Text));
            komut1.Parameters.AddWithValue("@p4", Convert.ToInt32(textBox2.Text));
            komut1.ExecuteNonQuery();
           

            string sorgu = "select * from yatis order by id asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from yatis where id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", Convert.ToInt32(textBox2.Text));
            komut1.ExecuteNonQuery();

            string sorgu = "select * from yatis order by id asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("update yatis set hasta_tc=@p1,oda_no=@p2,yatilacak_gun=@p3 where id=@p4 ", baglanti);
            komut1.Parameters.AddWithValue("@p1", Convert.ToInt64(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", Convert.ToInt32(textBox5.Text));
            komut1.Parameters.AddWithValue("@p3", Convert.ToInt32(textBox4.Text));
            komut1.Parameters.AddWithValue("@p4", Convert.ToInt32(textBox2.Text));
            komut1.ExecuteNonQuery();


            string sorgu = "select * from yatis order by id asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
    }
}
