using Npgsql; //database baglanti olusum
using System;
using System.Collections.Generic;
using System.ComponentModel;  //aktif bir windows uygulaması olarak çalışması için ekliyoruz.
using System.Drawing;
using System.Data; 
using System.Linq;  //Sql ile yazdığımız sorgular ADO.NET sorgusu haline dönüştürülüyor 
using System.Text;
using System.Threading.Tasks; //eszamanli islem yapmayi saglar.
using System.Windows.Forms;

namespace hastane
{
    public partial class Form1 : Form
    {
      public   string randevusifre;
      public string pid; 
 
        private Button Kayitol;
        randevu frm;
        KayitOl kytol;
        AdminPaneli adm;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Hoşgeldiniz";
            
            
            Giris.Click += Buton_Click;  //giris butonuna tiklandiginda
              frm = new randevu();
              frm.Width = 800;
              frm.Height = 600;
              frm.Text = "RANDEVU ALMA SİSTEMİ";

              Kayitol = new Button(); //kayit butonu konum ve boyutu
              Kayitol.Text = "Kayit ol";
              Kayitol.SetBounds(79, 140, 100, 30);
              Controls.Add(Kayitol); 

              Kayitol.Click += Buton_Click; //kayit ol a tiklandiginda
              kytol = new KayitOl();
              kytol.Width = 800;
              kytol.Height = 600;
              kytol.Text = "Kayıt ol";

              adm = new AdminPaneli(); //admin yani yetki=1 oldugunda
              adm.Text = "ADMİN PANELİ";
            
            
        }

        void Buton_Click(object sender, EventArgs e) 
        {

            this.Hide();
          if (sender == Kayitol)
              kytol.Show();
            if(sender==Giris)
            {
                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Port=5433;Password=123;Database=hastane"))
                    {
                        conn.Open();
                        using (NpgsqlCommand cmd = new NpgsqlCommand())
                        {
                            cmd.Connection = conn;

                            
                            cmd.CommandText = "SELECT * FROM person  where tc=@deneme";
                            cmd.Parameters.AddWithValue("@deneme", kAdi.Text);
                            cmd.ExecuteNonQuery(); //sorguyu calistirir
                             
                            NpgsqlDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                if (sifre.Text == dr["sifre"].ToString())
                                {
                                    if (dr["yetki"].ToString() == "" + 1)
                                    {
                                        adm.Show();
 
                                    }
                                    else
                                    {
                                        frm.Show();
                                        frm.TC_Txtbx.Text = dr["tc"].ToString();
                                        frm.Ad_Txtbx.Text = dr["ad"].ToString();
                                        frm.Soyad_Txtbx.Text = dr["soyad"].ToString();
                                        frm.Cinsiyet_Txtbx.Text = dr["cinsiyet"].ToString();
                                        frm.Eposta_Txtbx.Text = dr["e_posta"].ToString();
                                        frm.Dogumt_dt.Text = dr["dogumt"].ToString();
                                         
                                         frm.pid = dr["personid"].ToString();
                                       

                                    }
                                       
                                }
                                else
                                    MessageBox.Show("Şifre hatalı");
                              
                                    
                            }
                            
                        }
                    }
                }
                catch (Exception msg)
                {
                    // something went wrong, and you wanna know why
                    MessageBox.Show(msg.ToString());
                    throw;
                }
            }
            //this.Hide();
        }

     
    }
}
