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
    public partial class veli : Form
    {
        public veli()
        {
            InitializeComponent();
        }
         SqlConnection bag = new SqlConnection(@"Data Source=DESKTOP-FNE5H92;Initial Catalog=kres;Integrated Security=True");
        private void veli_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from ogrenci", bag);
            SqlDataReader dr;
            bag.Open();
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["o_adsoyad"]);
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

        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, bag);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button3_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from veli");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("Select * from veli where v_adisoyadi like '%" + textBox3.Text + "%'", bag);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bag.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string v_adisoyadi = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string v_ogadsoyad = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string v_telno = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string v_adres = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string v_kadi = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string v_sifre = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();
            string v_email = dataGridView1.Rows[secilialan].Cells[7].Value.ToString();

            textBox1.Text = v_adisoyadi;
            comboBox2.Text = v_ogadsoyad;
            textBox2.Text = v_telno;
            textBox4.Text = v_adres;
            textBox5.Text = v_kadi;
            textBox6.Text = v_sifre;
            textBox7.Text = v_email;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("insert into veli (v_adisoyadi, v_ogadsoyad, v_telno, v_adres, v_kadi, v_sifre, v_email) values (@v_adisoyadi, @v_ogadsoyad, @v_telno, @v_adres, @v_kadi, @v_sifre, @v_email)", bag);
            komut.Parameters.AddWithValue("@v_adisoyadi", textBox1.Text);
            komut.Parameters.AddWithValue("@v_ogadsoyad", comboBox2.Text);
            komut.Parameters.AddWithValue("@v_telno", textBox2.Text);
            komut.Parameters.AddWithValue("@v_adres", textBox4.Text);
            komut.Parameters.AddWithValue("@v_kadi", textBox5.Text);
            komut.Parameters.AddWithValue("@v_sifre", textBox6.Text);
            komut.Parameters.AddWithValue("@v_email", textBox7.Text);
            komut.ExecuteNonQuery();
            verilerigoster("select * from veli");
            bag.Close();


            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox1.Focus();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("update veli set v_adisoyadi='" + textBox1.Text + "',v_ogadsoyad='" + comboBox2.Text + "',v_telno='" + textBox2.Text + "',v_adres='" + textBox4.Text + "',v_kadi='" + textBox5.Text + "',v_sifre='" + textBox6.Text + "',v_email='" + textBox7.Text + "' where v_adisoyadi = '" + textBox1.Text + "'", bag);
            komut.ExecuteNonQuery();
            verilerigoster("select * from veli");
            bag.Close();
        }
        int id;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("delete from veli where v_adisoyadi='" + dataGridView1.CurrentRow.Cells["v_adisoyadi"].Value.ToString() + "'", bag);
                komut.ExecuteNonQuery();
                bag.Close();
                verilerigoster("select * from veli");
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

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Emin misiniz ? ", "Kapatiliyor", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
