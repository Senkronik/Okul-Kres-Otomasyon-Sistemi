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
    public partial class ogretmen : Form
    {
        public ogretmen()
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
        private void ogretmen_Load(object sender, EventArgs e)
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
            SqlCommand komut = new SqlCommand("update ogretmen set og_adisoyadi='" + textBox1.Text + "',og_tc='" + textBox8.Text + "',og_telno='" + textBox2.Text + "',og_adres='" + textBox4.Text + "',og_kadi='" + textBox5.Text + "',og_sifre='" + textBox6.Text + "',og_maas='" + textBox7.Text + "' where og_adisoyadi = '" + textBox1.Text + "'", bag);
            komut.ExecuteNonQuery();
            verilerigoster("select * from ogretmen");
            bag.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("insert into ogretmen (og_adisoyadi, og_tc, og_telno, og_adres, og_kadi, og_sifre, og_maas) values (@og_adisoyadi, @og_tc, @og_telno, @og_adres, @og_kadi, @og_sifre, @og_maas)", bag);
            komut.Parameters.AddWithValue("@og_adisoyadi", textBox1.Text);
            komut.Parameters.AddWithValue("@og_tc", textBox8.Text);
            komut.Parameters.AddWithValue("@og_telno", textBox2.Text);
            komut.Parameters.AddWithValue("@og_adres", textBox4.Text);
            komut.Parameters.AddWithValue("@og_kadi", textBox5.Text);
            komut.Parameters.AddWithValue("@og_sifre", textBox6.Text);
            komut.Parameters.AddWithValue("@og_maas", textBox7.Text);
            komut.ExecuteNonQuery();
            verilerigoster("select * from ogretmen");
            bag.Close();


            textBox1.Clear();
            textBox2.Clear();
            textBox8.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox1.Focus();
        }
        int id;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("delete from ogretmen where og_id='" + dataGridView1.CurrentRow.Cells["og_id"].Value.ToString() + "'", bag);
                komut.ExecuteNonQuery();
                bag.Close();
                verilerigoster("select * from ogretmen");
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
            SqlCommand komut = new SqlCommand("Select * from ogretmen where og_adisoyadi like '%" + textBox3.Text + "%'", bag);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bag.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from ogretmen");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string og_adisoyadi = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string og_tc = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string og_telno = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string og_adres = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string og_kadi = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string og_sifre = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();
            string og_maas = dataGridView1.Rows[secilialan].Cells[7].Value.ToString();
            
            textBox1.Text = og_adisoyadi;
            textBox8.Text = og_tc;
            textBox2.Text = og_telno;
            textBox4.Text = og_adres;
            textBox5.Text = og_kadi;
            textBox6.Text = og_sifre;
            textBox7.Text = og_maas;
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
