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
    public partial class yemek : Form
    {
        public yemek()
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
        private void yemek_Load(object sender, EventArgs e)
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
            SqlCommand komut = new SqlCommand("update yemek set ye_donem='" + textBox1.Text + "',ye_tur1='" + textBox8.Text + "',ye_tur2='" + textBox2.Text + "', ye_tarih='" + textBox3.Text + "' where ye_donem = '" + textBox8.Text + "'", bag);
            komut.ExecuteNonQuery();
            verilerigoster("select * from yemek");
            bag.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("insert into yemek (ye_donem, ye_tarih, ye_tur1, ye_tur2) values (@ye_donem, @ye_tarih, @ye_tur1, @ye_tur2)", bag);
            komut.Parameters.AddWithValue("@ye_baslik", textBox1.Text);
            komut.Parameters.AddWithValue("@ye_tarih", textBox3.Text);
            komut.Parameters.AddWithValue("@ye_tur1", textBox2.Text);
            komut.Parameters.AddWithValue("@ye_tur2", textBox8.Text);
            komut.ExecuteNonQuery();
            verilerigoster("select * from yemek");
            bag.Close();


            textBox1.Clear();
            textBox8.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }
        int id;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("delete from yemek where ye_donem='" + dataGridView1.CurrentRow.Cells["ye_donem"].Value.ToString() + "'", bag);
                komut.ExecuteNonQuery();
                bag.Close();
                verilerigoster("select * from yemek");
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
            SqlCommand komut = new SqlCommand("Select * from yemek where ye_tarih like '%" + dateTimePicker2.Text + "%'", bag);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bag.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from yemek");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string ye_donem = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            string ye_tarih = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string ye_tur1 = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string ye_tur2 = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();

            textBox1.Text = ye_donem;
            textBox3.Text = ye_tarih;
            textBox2.Text = ye_tur1;
            textBox8.Text = ye_tur2;
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
