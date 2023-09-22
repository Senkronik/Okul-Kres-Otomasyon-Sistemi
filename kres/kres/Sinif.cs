using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kres
{
    public partial class Sinif : Form
    {
        public Sinif()
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

        private void Sinif_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from ogretmen", bag);
            SqlDataReader dr;
            bag.Open();
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["og_adisoyadi"]);
            }
            bag.Close();
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

        private void button13_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("update sinif set s_adi='" + textBox1.Text + "',s_kontenjan='" + textBox8.Text + "',s_donem='" + comboBox1.Text + "',s_ogretmen='" + comboBox2.Text + "' where s_adi = '" + textBox1.Text + "'", bag);
            komut.ExecuteNonQuery();
            verilerigoster("select * from sinif");
            bag.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("insert into sinif (s_adi, s_kontenjan, s_donem, s_ogretmen) values (@s_adi, @s_kontenjan, @s_donem, @s_ogretmen)", bag);
            komut.Parameters.AddWithValue("@s_adi", textBox1.Text);
            komut.Parameters.AddWithValue("@s_kontenjan", textBox8.Text);
            komut.Parameters.AddWithValue("@s_donem", comboBox1.Text);
            komut.Parameters.AddWithValue("@s_ogretmen", comboBox2.Text);
            komut.ExecuteNonQuery();
            verilerigoster("select * from sinif");
            bag.Close();

            textBox1.Clear();
            textBox8.Clear();
            textBox1.Focus();
        }
        int id;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("delete from sinif where s_adi='" + dataGridView1.CurrentRow.Cells["s_adi"].Value.ToString() + "'", bag);
                komut.ExecuteNonQuery();
                bag.Close();
                verilerigoster("select * from sinif");
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
            SqlCommand komut = new SqlCommand("Select * from sinif where s_adi like '%" + textBox3.Text + "%'", bag);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bag.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from sinif");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string s_adi = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string s_kontenjan = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string s_donem = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string s_ogretmen = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            
            textBox1.Text = s_adi;
            textBox8.Text = s_kontenjan;
            comboBox1.Text = s_donem;
            comboBox2.Text = s_ogretmen;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Emin misiniz ? ", "Kapatiliyor", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
