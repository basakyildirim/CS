
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace hastane
{
    public partial class KayitOl : Form
    {
        Form1 giris = new Form1();
        public KayitOl()
        {
            

            InitializeComponent();
        }

       
   

        private void button1_Click(object sender, EventArgs e)
        {
            if (sifre_txt.Text == sifre_tekrar.Text)
            {

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Port=5433;Password=123;Database=hastane"))
                    {
                        conn.Open();
                        using (NpgsqlCommand cmd = new NpgsqlCommand())
                        {
                            cmd.Connection = conn;

                             
                            cmd.CommandText = "insert into person(personid,tc,ad,soyad,cinsiyet,e_posta,sifre,dogumt,yetki)  VALUES (@nextval('serial'),  @tc, @ad , @soyad  , @cinsiyet, @eposta,@sifre ,@dogumt,'0')";
                            cmd.Parameters.AddWithValue("@nextval('serial')", "nextval('serial')");
                            cmd.Parameters.AddWithValue("@tc", tc_txt.Text);
                            cmd.Parameters.AddWithValue("@ad", ad_txt.Text);
                            cmd.Parameters.AddWithValue("@soyad", soyad_txt.Text);
                            cmd.Parameters.AddWithValue("@cinsiyet", cnsyet_combobox.Text);
                            cmd.Parameters.AddWithValue("@eposta", e_posta.Text);
                            cmd.Parameters.AddWithValue("@sifre", sifre_txt.Text);
                            cmd.Parameters.AddWithValue("@dogumt", DateTime.Parse(dateTimePicker1.Text));
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Kayıt Başarılı.");

                        }
                    }
                    giris.Show();
                    this.Close();

                }
                catch (Exception msg)
                {
 
                    MessageBox.Show(msg.ToString());
                    throw;
                }
            }
            else
                MessageBox.Show("Şifreler uyuşmuyor.");
        }

        private void KayitOl_Load(object sender, EventArgs e)
        {

        }
    }
}
