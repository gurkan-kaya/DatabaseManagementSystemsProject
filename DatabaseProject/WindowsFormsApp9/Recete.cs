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
    public partial class Recete : Form
    {
        public Recete()
        {
            InitializeComponent();


            baglanti.Open();
            string sorgu = "select recete.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , recete.id as receteID, recete_ilac.ilac_adi, ilac.kullanim_bilgi from recete " +
            "inner join recete_ilac ON recete.id=recete_ilac.recete_id " +
            "inner join ilac ON ilac.ilac_adi=recete_ilac.ilac_adi " +
            "inner join doktor on doktor.id=recete.doktor_id";          
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
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into recete (id,hasta_tc,doktor_id) values (@p1,@p2,@p5)", baglanti);
            NpgsqlCommand komut2 = new NpgsqlCommand("insert into recete_ilac (ilac_adi,recete_id) values (@p3,@p4)", baglanti);
 
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.Parameters.AddWithValue("@p4", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2",Convert.ToInt64(textBox5.Text));
            komut2.Parameters.AddWithValue("@p3", textBox2.Text);
            komut1.Parameters.AddWithValue("@p5", int.Parse(comboBox1.SelectedValue.ToString()));
            komut1.ExecuteNonQuery();
            komut2.ExecuteNonQuery();
            string sorgu = "select recete.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , recete.id as receteID, recete_ilac.ilac_adi, ilac.kullanim_bilgi from recete " +
             "inner join recete_ilac ON recete.id=recete_ilac.recete_id " +
             "inner join ilac ON ilac.ilac_adi=recete_ilac.ilac_adi " +
             "inner join doktor on doktor.id=recete.doktor_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("insert into recete_ilac (ilac_adi,recete_id) values (@p2,@p3)", baglanti);
            komut2.Parameters.AddWithValue("@p2", textBox2.Text);
            komut2.Parameters.AddWithValue("@p3", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            string sorgu = "select recete.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , recete.id as receteID, recete_ilac.ilac_adi, ilac.kullanim_bilgi from recete " +
            "inner join recete_ilac ON recete.id=recete_ilac.recete_id " +
            "inner join ilac ON ilac.ilac_adi=recete_ilac.ilac_adi " +
            "inner join doktor on doktor.id=recete.doktor_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Recete_Load(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from recete where id=@p1", baglanti);
            NpgsqlCommand komut2 = new NpgsqlCommand("delete from recete_ilac where recete_id=@p2", baglanti);

            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.Parameters.AddWithValue("@p2", int.Parse(textBox1.Text));
            komut1.ExecuteNonQuery();
            komut2.ExecuteNonQuery();
            string sorgu = "select recete.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , recete.id as receteID, recete_ilac.ilac_adi, ilac.kullanim_bilgi from recete " +
             "inner join recete_ilac ON recete.id=recete_ilac.recete_id " +
             "inner join ilac ON ilac.ilac_adi=recete_ilac.ilac_adi " +
             "inner join doktor on doktor.id=recete.doktor_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("update recete set hasta_tc=@p2,doktor_id=@p5 where id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", Convert.ToInt64(textBox5.Text));
            komut1.Parameters.AddWithValue("@p5", int.Parse(comboBox1.SelectedValue.ToString()));
            komut1.ExecuteNonQuery();
            string sorgu = "select recete.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , recete.id as receteID, recete_ilac.ilac_adi, ilac.kullanim_bilgi from recete " +
             "inner join recete_ilac ON recete.id=recete_ilac.recete_id " +
             "inner join ilac ON ilac.ilac_adi=recete_ilac.ilac_adi " +
             "inner join doktor on doktor.id=recete.doktor_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
    }
}
