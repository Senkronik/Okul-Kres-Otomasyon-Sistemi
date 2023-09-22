using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kres
{
    public partial class muhasebe : Form
    {
        public muhasebe()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-FNE5H92;Initial Catalog=kres;Integrated Security=True");

         public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, bag);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void muhasebe_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ogrenci frm = new ogrenci();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            veli frm = new veli();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ogretmen frm = new ogretmen();
            frm.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Sinif frm = new Sinif();
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ders frm = new ders();
            frm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            duyuru frm = new duyuru();
            frm.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            etkinlik frm = new etkinlik();
            frm.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            yemek frm = new yemek();
            frm.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            muhasebe frm = new muhasebe();
            frm.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Emin misiniz ? ", "Kapatiliyor", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("update muhasebe set m_gelirgider='" + comboBox2.Text + "',m_tarih='" + textBox2.Text + "',m_tutar='" + textBox1.Text + "',m_gidert='" + comboBox1.Text + "',m_odemet='" + comboBox3.Text + "',m_donem='" + comboBox4.Text + "' where m_gelirgider = '" + comboBox1.Text + "'", bag);
            komut.ExecuteNonQuery();
            verilerigoster("select * from muhasebe");
            bag.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("insert into muhasebe (m_gelirgider, m_tarih, m_tutar, m_gidert, m_odemet, m_donem) values (@m_gelirgider, @m_tarih, @m_tutar, @m_gidert, @m_odemet, @m_donem)", bag);
            komut.Parameters.AddWithValue("@m_gelirgider", comboBox2.Text);
            komut.Parameters.AddWithValue("@m_tarih", textBox2.Text);
            komut.Parameters.AddWithValue("@m_tutar", textBox1.Text);
            komut.Parameters.AddWithValue("@m_gidert", comboBox1.Text);
            komut.Parameters.AddWithValue("@m_odemet", comboBox3.Text);
            komut.Parameters.AddWithValue("@m_donem", comboBox4.Text);
            komut.ExecuteNonQuery();
            verilerigoster("select * from muhasebe");
            bag.Close();


            textBox1.Clear();
            comboBox2.Focus();
        }
        int id;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("delete from muhasebe where m_gelirgider='" + dataGridView1.CurrentRow.Cells["m_gelirgider"].Value.ToString() + "'", bag);
                komut.ExecuteNonQuery();
                bag.Close();
                verilerigoster("select * from muhasebe");
                MessageBox.Show("Kayıt Silindi");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Bu kategori silinememektedir.");
            }
            finally
            {
                bag.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("Select * from muhasebe where m_donem like '%" + textBox9.Text + "%'", bag);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bag.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from muhasebe");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string m_gelirgider = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string m_tarih = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string m_tutar = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string m_gidert = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string m_odemet = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string m_donem = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();

            comboBox2.Text = m_gelirgider;
            textBox2.Text = m_tarih;
            textBox1.Text = m_tutar;
            comboBox1.Text = m_gidert;
            comboBox3.Text = m_odemet;
            comboBox4.Text = m_donem; 
        }
    }
}
