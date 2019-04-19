using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane
{ 
  
    public partial class AdminPaneli : Form
    {  int[] sayilar = new int[5] { 1, 2, 4, 8, 16 };
        public AdminPaneli()
        {
            InitializeComponent();
        }

        private void AdminPaneli_Load(object sender, EventArgs e)
        {
            doktorliste.View = View.Details;
            doktorliste.FullRowSelect = true;
            
             
            doktorliste.Columns.Add("Tc", 100, HorizontalAlignment.Left);
            doktorliste.Columns.Add("Bölüm", 100, HorizontalAlignment.Left);
            doktorliste.Columns.Add("Ad", 100, HorizontalAlignment.Left);
            doktorliste.Columns.Add("Soyad", 100, HorizontalAlignment.Left);
            refresh();
        }
        private void refresh()
        {
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
                        bolum_combobx.Items.Clear();
                        while (dr.Read())
                        {
                            bolum_combobx.Items.Add(dr["bolumadi"].ToString());
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
                using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Port=5433;Password=123;Database=hastane"))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand())
                    {

                        cmd.Connection = conn;

                        // Insert some data
                        cmd.CommandText = "SELECT * FROM doktor";

                        cmd.ExecuteNonQuery();

                        NpgsqlDataReader dr = cmd.ExecuteReader();
                        doktorliste.Items.Clear();
                        while (dr.Read())
                        {
                            int sira = doktorliste.Items.Count;

                            //ilk eklediğimiz ana itemdir, ilk sütundan sonra gelen sütunları doldurabilmek için altitem(subitem) kullanırız.
                            doktorliste.Items.Add(dr["tc"].ToString());
                            doktorliste.Items[sira].SubItems.Add(dr["bolum"].ToString());
                            doktorliste.Items[sira].SubItems.Add(dr["ad"].ToString());
                            doktorliste.Items[sira].SubItems.Add(dr["soyad"].ToString());
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
        private void bolum_ekle_Click(object sender, EventArgs e)
        {
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
                        cmd.CommandText = "insert into bolum(bolumadi) values(@bolumadi)";
                        cmd.Parameters.AddWithValue("@bolumadi", bolum_txtbx.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bölüm eklenmiştir");
                        refresh();
                    }
                }
            }
            catch (Exception msg)
            {
                
                MessageBox.Show(msg.ToString());
                throw;
            }
        }

  
        private void button1_Click(object sender, EventArgs e)
        {
           
            int toplam=0;
            for(int i=0;i<5;i++){
                if (gunler_listbx.GetItemChecked(i))
                    toplam += sayilar[i];
            }
           
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
                     
                        cmd.CommandText = "insert into doktor values(@nextval('kadroid'),@tc,@ad,@soyad,@telno,'2',@nextval('doktorid'),@rank,@bolum,@baslangict,@calisma_gunu)";
                        cmd.Parameters.AddWithValue("@nextval('kadroid')", "nextval('kadroid')");
                        cmd.Parameters.AddWithValue("@tc", tc_masked.Text);
                        cmd.Parameters.AddWithValue("@ad", textBox7.Text);
                        cmd.Parameters.AddWithValue("@soyad", textBox6.Text);
                        cmd.Parameters.AddWithValue("@telno", maskedTextBox1.Text);
                        cmd.Parameters.AddWithValue("@nextval('doktorid')", "nextval('doktorid')");
                        cmd.Parameters.AddWithValue("@rank", derece_combobx.Text);
                        cmd.Parameters.AddWithValue("@bolum", bolum_combobx.Text);
                        cmd.Parameters.AddWithValue("@baslangict", DateTime.Parse(dateTimePicker1.Text));
                        cmd.Parameters.AddWithValue("@calisma_gunu", toplam);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Doktor eklenmiştir");
                        refresh();
                    }
                }
            }
            catch (Exception msg)
            {
                
                MessageBox.Show(msg.ToString());
                throw;
            }
        }

     

       

        private void button2_Click(object sender, EventArgs e)
        {
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
                        cmd.CommandText = "insert into yonetim values(@nextval('kadroid'),@tc,@ad,@soyad,@telno,'1',@kadro_title,@baslangict,'1')";
                        cmd.Parameters.AddWithValue("@nextval('kadroid')", "nextval('kadroid')");
                        cmd.Parameters.AddWithValue("@tc", tc_masked.Text);
                        cmd.Parameters.AddWithValue("@ad", textBox7.Text);
                        cmd.Parameters.AddWithValue("@soyad", textBox6.Text);
                        cmd.Parameters.AddWithValue("@telno", maskedTextBox1.Text);
                        cmd.Parameters.AddWithValue("@kadro_title", unvan_combobx.Text);
                        cmd.Parameters.AddWithValue("@baslangict",DateTime.Parse(dateTimePicker1.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Yönetici eklenmiştir");
                        refresh();
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

        private void doktorliste_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
                gunler_listbx.SetItemChecked(i, false);
            foreach (ListViewItem bilgi in doktorliste.SelectedItems)
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

                            if (dr.Read())
                            {
                                tc_masked.Text = dr["tc"].ToString();
                                textBox7.Text = dr["ad"].ToString();
                                textBox6.Text = dr["soyad"].ToString();
                                dateTimePicker1.Text = dr["baslangict"].ToString();
                                maskedTextBox1.Text = dr["telno"].ToString();
                                derece_combobx.Text = dr["rank"].ToString();
                                bolum_combobx.Text = dr["bolum"].ToString();
                                
                                int deger=Int32.Parse(dr["calisma_gunu"].ToString());
                                for (int i = 4; i >= 0; i--)
                                {
                                    if (deger >= sayilar[i])
                                    {
                                        deger = deger - sayilar[i];
                                        gunler_listbx.SetItemChecked(i, true);
                                    }
                                    if (deger == 0)
                                        break;
                                }

                            }

                        }
                    }
                }
                catch (Exception msg)
                {
                   
                    MessageBox.Show(msg.ToString());
                    throw;
                }

                //MessageBox.Show(doktorliste.Items..ToString());
            }
        }
        private void gunler_listbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int toplam = 0;
            for (int i = 0; i < 5; i++)
            {
                if (gunler_listbx.GetItemChecked(i))
                    toplam += sayilar[i];
            }
            foreach (ListViewItem bilgi in doktorliste.SelectedItems)
            {

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Port=5433;Password=123;Database=hastane"))
                    {
                        conn.Open();
                        using (NpgsqlCommand cmd = new NpgsqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = "UPDATE doktor SET ad = @ad, soyad = @soyad,telno=@telno,rank=@rank,bolum=@bolum,calisma_gunu=@calisma_gunu Where tc=@bilgi";
                            cmd.Parameters.AddWithValue("@bilgi", bilgi.Text);
                            cmd.Parameters.AddWithValue("@ad", textBox7.Text);
                            cmd.Parameters.AddWithValue("@soyad", textBox6.Text);
                            cmd.Parameters.AddWithValue("@telno", maskedTextBox1.Text);
                            cmd.Parameters.AddWithValue("@rank", derece_combobx.Text);
                            cmd.Parameters.AddWithValue("@bolum", bolum_combobx.Text);
                            cmd.Parameters.AddWithValue("@calisma_gunu", toplam);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Kayıt güncellenmiştir.");
                            refresh();
 
                               
                   

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

        private void sil_button_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem bilgi in doktorliste.SelectedItems)
            {

                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Port=5433;Password=123;Database=hastane"))
                    {
                        conn.Open();
                        using (NpgsqlCommand cmd = new NpgsqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = "delete from doktor where tc=@bilgi";

                            cmd.Parameters.AddWithValue("@bilgi", bilgi.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("SİLİNDİ");
                            refresh();
                           
                        }
                    }
                }
                catch (Exception msg)
                {
                    // something went wrong, and you wanna know why
                    MessageBox.Show(msg.ToString());
                    throw;
                }

                //MessageBox.Show(doktorliste.Items..ToString());
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bolum_combobx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void unvan_combobx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

   
    }
}
