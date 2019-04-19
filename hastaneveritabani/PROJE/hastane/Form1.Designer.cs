namespace hastane
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.KullaniciAdi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kAdi = new System.Windows.Forms.TextBox();
            this.sifre = new System.Windows.Forms.TextBox();
            this.Giris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KullaniciAdi
            // 
            this.KullaniciAdi.AutoSize = true;
            this.KullaniciAdi.Location = new System.Drawing.Point(12, 51);
            this.KullaniciAdi.Name = "KullaniciAdi";
            this.KullaniciAdi.Size = new System.Drawing.Size(49, 13);
            this.KullaniciAdi.TabIndex = 0;
            this.KullaniciAdi.Text = "Kimlik no";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre";
           
            // 
            // kAdi
            // 
            this.kAdi.Location = new System.Drawing.Point(79, 51);
            this.kAdi.Name = "kAdi";
            this.kAdi.Size = new System.Drawing.Size(100, 20);
            this.kAdi.TabIndex = 2;
            // 
            // sifre
            // 
            this.sifre.Location = new System.Drawing.Point(79, 77);
            this.sifre.Name = "sifre";
            this.sifre.Size = new System.Drawing.Size(100, 20);
            this.sifre.TabIndex = 3;
             
            // 
            // Giris
            // 
            this.Giris.Location = new System.Drawing.Point(79, 104);
            this.Giris.Name = "Giris";
            this.Giris.Size = new System.Drawing.Size(100, 29);
            this.Giris.TabIndex = 4;
            this.Giris.Text = "Giriş";
            this.Giris.UseVisualStyleBackColor = true;
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 217);
            this.Controls.Add(this.Giris);
            this.Controls.Add(this.sifre);
            this.Controls.Add(this.kAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KullaniciAdi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label KullaniciAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox kAdi;
        private System.Windows.Forms.TextBox sifre;
        private System.Windows.Forms.Button Giris;
    }
}

