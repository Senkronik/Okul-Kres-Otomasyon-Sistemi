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
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection(@"Data Source =DESKTOP-FNE5H92; Initial Catalog = kres; Integrated Security = True");
        public static String AccNumber;
        private void button1_Click(object sender, EventArgs e)
        {
            string AccNum = adminlogname.Text;
            string pin = adminlogpssw.Text;
            SqlCommand cmd = new SqlCommand();
            bag.Open();
            cmd.Connection = bag;
            cmd.CommandText = "SELECT * FROM yonetici where y_kadi='" + adminlogname.Text + "' AND y_sifre='" + adminlogpssw.Text + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                AccNumber = adminlogname.Text;
                ogrenci ogrenci = new ogrenci();
                ogrenci.Show();
                this.Hide();
                bag.Close();
            }
            else
            {
                MessageBox.Show("Yanlış hesap numarası veya PIN kodu!");
            }

            bag.Close();
        }

        private void giris_Load(object sender, EventArgs e)
        {

        }
    }
}
