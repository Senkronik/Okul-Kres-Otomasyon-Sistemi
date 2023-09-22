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
    public partial class duyuru : Form
    {
        public duyuru()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-FNE5H92;Initial Catalog=kres;Integrated Security=True");
        private void duyuru_Load(object sender, EventArgs e)
        {

        }

        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, bag);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
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
            SqlCommand komut = new SqlCommand("update duyuru set dy_baslik='" + textBox1.Text + "',dy_tarih='" + textBox2.Text + "',dy_donem='" + comboBox2.Text + "',dy_icerik='"  + textBox8.Text + "' where dy_baslik = '" + textBox1.Text + "'", bag);
            komut.ExecuteNonQuery();
            verilerigoster("select * from duyuru");
            bag.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("insert into ogretmen (dy_baslik, dy_tarih, dy_donem, dy_icerik) values (@dy_baslik, @dy_tarih, @dy_donem, @dy_icerik)", bag);
            komut.Parameters.AddWithValue("@dy_baslik", textBox1.Text);
            komut.Parameters.AddWithValue("@dy_tarih", textBox2.Text);
            komut.Parameters.AddWithValue("@dy_donem", comboBox2.Text);
            komut.Parameters.AddWithValue("@dy_icerik", textBox8.Text);
            komut.ExecuteNonQuery();
            verilerigoster("select * from duyuru");
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
                SqlCommand komut = new SqlCommand("delete from duyuru where dy_baslik='" + dataGridView1.CurrentRow.Cells["dy_baslik"].Value.ToString() + "'", bag);
                komut.ExecuteNonQuery();
                bag.Close();
                verilerigoster("select * from duyuru");
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
            SqlCommand komut = new SqlCommand("Select * from duyuru  where dy_tarih like '%" + dateTimePicker2.Text + "%'", bag);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bag.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from duyuru");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string dy_baslik = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string dy_tarih = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string dy_donem = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string dy_icerik = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            
            textBox1.Text = dy_baslik;
            textBox2.Text = dy_tarih;
            comboBox2.Text = dy_donem;
            textBox8.Text = dy_icerik;
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
