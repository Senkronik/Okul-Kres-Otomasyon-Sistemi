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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace kres
{
    public partial class ogrenci : Form
    {
        public ogrenci()
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
        private void button15_Click(object sender, EventArgs e)
        {
            Sinif frm = new Sinif();
            frm.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("insert into ogrenci(o_adsoyad, o_tc, o_cinsiyet, o_sinif, o_donem, o_kayittarihi) values (@o_adsoyad, @o_tc, @o_cinsiyet, @o_sinif, @o_donem, @o_kayittarihi)", bag);
            komut.Parameters.AddWithValue("@o_adsoyad", textBox1.Text);
            komut.Parameters.AddWithValue("@o_tc", textBox2.Text);
            komut.Parameters.AddWithValue("@o_cinsiyet", comboBox2.Text);
            komut.Parameters.AddWithValue("@o_sinif", comboBox3.Text);
            komut.Parameters.AddWithValue("@o_donem", comboBox4.Text);
             //= dateTimePicker2.Value.ToShortDateString();
            komut.Parameters.AddWithValue("@o_kayittarihi", textBox4.Text);
            komut.ExecuteNonQuery();
            verilerigoster("select * from ogrenci");
            bag.Close();


            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("update ogrenci set o_adsoyad='" + textBox1.Text + "', o_tc='" + textBox2.Text + "',o_cinsiyet='" + comboBox2.Text + "',o_sinif='" + comboBox3.Text + "',o_donem='" + comboBox4.Text + "',o_kayittarihi='" + textBox4.Text + "' where o_adsoyad = '" + textBox1.Text + "'", bag);
            komut.ExecuteNonQuery();
            verilerigoster("select * from ogrenci");
            bag.Close();
        }
        int id;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("delete from ogrenci where o_adsoyad='" + dataGridView1.CurrentRow.Cells["o_adsoyad"].Value.ToString() + "'", bag);
                komut.ExecuteNonQuery();
                bag.Close();
                verilerigoster("select * from ogrenci");
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

        private void button3_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from ogrenci");
        }

        private void ogrenci_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from sinif", bag);
            SqlDataReader dr;
            bag.Open();
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                comboBox3.Items.Add(dr["s_sinif"]);
            }
            bag.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("Select * from ogrenci where o_adsoyad like '%" + textBox3.Text + "%'", bag);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bag.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string o_adsoyad = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string o_tc = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string o_cinsiyet = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string o_sinif = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string o_donem = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string o_kayittarihi = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();
            

            textBox1.Text = o_adsoyad;
            textBox2.Text = o_tc;
            comboBox2.Text = o_cinsiyet;
            comboBox3.Text = o_sinif;
            comboBox4.Text = o_donem;
            textBox4.Text = o_kayittarihi;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            veli frm = new veli();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ogrenci frm = new ogrenci();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ogretmen frm = new ogretmen();
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
