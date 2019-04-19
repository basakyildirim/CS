using Npgsql;
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

namespace hastane
{
    public partial class randevu : Form
    {

        Form1 s = new Form1();
        string tc;
        private Button Kaydet;
        
        public string pid;
        private Label Ad_label;
        private Label Soyad_label;
        private Label TC_label;
        private Label Cinsiyet_label;
        private Label Eposta_label;
        private Label Dogumt_label;
        private Label Randevut_label;
        private Label Telno_label;
        public TextBox Ad_Txtbx;
        public TextBox Soyad_Txtbx;
        public TextBox TC_Txtbx;
        public TextBox Cinsiyet_Txtbx;
        public TextBox Eposta_Txtbx;
        public TextBox Dogumt_Txtbx;
        public DateTimePicker Randevut_Txtbx;
        public TextBox Telno_Txtbx;
        public DateTimePicker Dogumt_dt;
        public randevu()
        { 
            TC_label = new Label();
            TC_label.Text = "Kimlik No";
            TC_label.SetBounds(10, 20, 100, 20);
            Ad_label = new Label();
            Ad_label.Text = "Adınız";
            Ad_label.SetBounds(10, 50, 100, 20);
            Soyad_label = new Label();
            Soyad_label.Text = "Soyadınız";
            Soyad_label.SetBounds(10, 80, 100, 20);
            Cinsiyet_label = new Label();
            Cinsiyet_label.Text = "Cinsiyet";
            Cinsiyet_label.SetBounds(10, 110, 100, 20);
            Eposta_label = new Label();
            Eposta_label.Text = "E posta";
            Eposta_label.SetBounds(10, 140, 100, 20);
            Dogumt_label = new Label();
            Dogumt_label.Text = "Doğum Tarihi";
            Dogumt_label.SetBounds(10, 170, 100, 20); 
            Randevut_label = new Label();
            Randevut_label.Text = "Randevu Tarihi";
            Randevut_label.SetBounds(10, 200, 100, 20);
            Telno_label = new Label();
            Telno_label.Text = "Telefon NO";
            Telno_label.SetBounds(10, 230, 100, 20);
            
            TC_Txtbx = new TextBox();
            TC_Txtbx.SetBounds(130, 20, 70, 20);
            Ad_Txtbx = new TextBox();
            Ad_Txtbx.SetBounds(130, 50, 70, 20);
            Soyad_Txtbx = new TextBox();
            Soyad_Txtbx.SetBounds(130, 80, 70, 20);
            Cinsiyet_Txtbx = new TextBox();
            Cinsiyet_Txtbx.SetBounds(130, 110, 70, 20);
            Eposta_Txtbx = new TextBox();
            Eposta_Txtbx.SetBounds(130, 140, 70, 20);

            Randevut_Txtbx = new DateTimePicker();
            Randevut_Txtbx.SetBounds(130, 200, 70, 20);
            Telno_Txtbx = new TextBox();
            Telno_Txtbx.SetBounds(130, 230, 70, 20);
            Dogumt_dt = new DateTimePicker();
            Dogumt_dt.SetBounds(130, 170, 120, 20);
            Controls.Add(TC_label);
            Controls.Add(Ad_label);
            Controls.Add(Soyad_label);
            Controls.Add(Cinsiyet_label);
            Controls.Add(Eposta_label);
            Controls.Add(Dogumt_label);
            Controls.Add(Randevut_label);
            Controls.Add(Telno_label);
        
            Controls.Add(TC_Txtbx);
            Controls.Add(Ad_Txtbx);
            Controls.Add(Soyad_Txtbx);
            Controls.Add(Cinsiyet_Txtbx);
            Controls.Add(Eposta_Txtbx);
            
            Controls.Add(Randevut_Txtbx);
            Controls.Add(Telno_Txtbx);
            Controls.Add(Dogumt_dt);
            Kaydet = new Button();
            Kaydet.Text = "Randevu al";
            Kaydet.SetBounds(250, 250,90, 40);
       
            Controls.Add(Kaydet);
            Kaydet.Click += Kaydet_Click;
           
            InitializeComponent();
        }

        
        void Kaydet_Click(object sender, EventArgs e)
        {
           foreach (ListViewItem bilgi in doktor_liste.SelectedItems)
          
                        {
                          
                            try
                            {
                                using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Port=5433;Password=123;Database=hastane"))
                                {
                                    conn.Open();
                                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                                    {
                                        cmd.Connection = conn;
                                        cmd.CommandText = "select * from doktor where tc=@bilgi";
                                         
                                        cmd.Parameters.AddWithValue("@bilgi", bilgi.Text);
                                        
                                        cmd.ExecuteNonQuery();
                                        NpgsqlDataReader dr = cmd.ExecuteReader();

                                        while (dr.Read())
                                        {
                                              tc=dr["tc"].ToString();
                                              bilgi.Text = dr["doktorid"].ToString();
                                           
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
                          
             try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=123;Port=5433;Database=hastane"))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
 
                        
                        // Insert some data
                        cmd.CommandText = "insert into randevu(personid,tc,ad,soyad,cinsiyet,e_posta,dogumt,randevuid,randevut,doktorid,telno)VALUES (@personid,  @tc, @ad , @soyad  , @cinsiyet, @eposta,@dogumt,@nextval('randevuid'),@randevutarihi,@doktorid,@telno)";
                        cmd.Parameters.AddWithValue("@personid",pid);
                        cmd.Parameters.AddWithValue("@tc",TC_Txtbx.Text);
                        cmd.Parameters.AddWithValue("@ad", Ad_Txtbx.Text);
                        cmd.Parameters.AddWithValue("@soyad", Soyad_Txtbx.Text);
                        cmd.Parameters.AddWithValue("@cinsiyet", Cinsiyet_Txtbx.Text);
                        cmd.Parameters.AddWithValue("@eposta", Eposta_Txtbx.Text);
                        cmd.Parameters.AddWithValue("@dogumt", DateTime.Parse(Dogumt_dt.Text));
                        cmd.Parameters.AddWithValue("@nextval('randevuid')", "nextval('randevuid')");
                        cmd.Parameters.AddWithValue("@randevutarihi", DateTime.Parse(Randevut_Txtbx.Text));
                        cmd.Parameters.AddWithValue("@doktorid", bilgi.Text);
                        cmd.Parameters.AddWithValue("@telno", Telno_Txtbx.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Başarılı");
                        s.Show();
                        this.Close();


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
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            doktor_liste.View = View.Details;

            // Ad, Soyad ve No isimlerinde, 100 genişliğinde, sola yatık şekilde 3 tane sütun(column)ekler.
            doktor_liste.Columns.Add("Tc", 100, HorizontalAlignment.Left);
            doktor_liste.Columns.Add("Ad", 100, HorizontalAlignment.Left);
            doktor_liste.Columns.Add("Soyad", 100, HorizontalAlignment.Left);
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Port=5433;Password=123;Database=hastane"))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {
                        NpgsqlCommand cmd1 = new NpgsqlCommand();
                        cmd.Connection = conn;
                        cmd1.Connection = conn;
                        // Insert some data
                        cmd.CommandText = "SELECT * FROM bolum";

                        cmd.ExecuteNonQuery();

                        NpgsqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            bolum.Items.Add(dr["bolumadi"].ToString());
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

        private void bolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            doktor_liste.Items.Clear();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Port=5433;password=123;Database=hastane"))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {

                        cmd.Connection = conn;

                        // Insert some data
                        cmd.CommandText = "SELECT * FROM doktor where bolum=@bolum";
                        cmd.Parameters.AddWithValue("@bolum", bolum.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();

                        NpgsqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            int sira = doktor_liste.Items.Count;

                            //ilk eklediğimiz ana itemdir, ilk sütundan sonra gelen sütunları doldurabilmek için altitem(subitem) kullanırız.
                            doktor_liste.Items.Add(dr["tc"].ToString());
                            doktor_liste.Items[sira].SubItems.Add(dr["ad"].ToString());
                            doktor_liste.Items[sira].SubItems.Add(dr["soyad"].ToString());


                            
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

        private void doktor_liste_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
 
       
        
        
        }
    }

