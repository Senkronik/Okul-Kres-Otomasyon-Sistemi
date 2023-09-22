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
    public partial class etkinlik : Form
    {
        public etkinlik()
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

        private void etkinlik_Load(object sender, EventArgs e)
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

        private void button13_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("update etkinlik set e_baslik='" + textBox1.Text + "',e_tarih='" + textBox2.Text + "',e_donem='" + comboBox2.Text + "',e_icerik='" + textBox8.Text + "' where e_baslik = '" + textBox1.Text + "'", bag);
            komut.ExecuteNonQuery();
            verilerigoster("select * from etkinlik");
            bag.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("insert into etkinlik (e_baslik, e_tarih, e_donem, e_icerik) values (@e_baslik, @e_tarih, @e_donem, @e_icerik)", bag);
            komut.Parameters.AddWithValue("@e_baslik", textBox1.Text);
            komut.Parameters.AddWithValue("@e_tarih", textBox2.Text);
            komut.Parameters.AddWithValue("@e_donem", comboBox2.Text);
            komut.Parameters.AddWithValue("@e_icerik", textBox8.Text);
            komut.ExecuteNonQuery();
            verilerigoster("select * from etkinlik");
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
                SqlCommand komut = new SqlCommand("delete from etkinlik where e_baslik='" + dataGridView1.CurrentRow.Cells["e_baslik"].Value.ToString() + "'", bag);
                komut.ExecuteNonQuery();
                bag.Close();
                verilerigoster("select * from etkinlik");
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
            SqlCommand komut = new SqlCommand("Select * from etkinlik where e_tarih like '%" + dateTimePicker2.Text + "%'", bag);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bag.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from etkinlik");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string e_baslik = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string e_tarih = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string e_donem = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string e_icerik = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            
            textBox1.Text = e_baslik;
            textBox2.Text = e_tarih;
            comboBox2.Text = e_donem;
            textBox8.Text = e_icerik;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Emin misiniz ? ", "Kapatiliyor", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
