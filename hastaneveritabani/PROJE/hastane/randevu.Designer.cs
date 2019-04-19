namespace hastane
{
    partial class randevu
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
            this.doktor_liste = new System.Windows.Forms.ListView();
            this.bolum = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // doktor_liste
            // 
            this.doktor_liste.Location = new System.Drawing.Point(399, 65);
            this.doktor_liste.Name = "doktor_liste";
            this.doktor_liste.Size = new System.Drawing.Size(285, 211);
            this.doktor_liste.TabIndex = 0;
            this.doktor_liste.UseCompatibleStateImageBehavior = false;
            this.doktor_liste.SelectedIndexChanged += new System.EventHandler(this.doktor_liste_SelectedIndexChanged);
            // 
            // bolum
            // 
            this.bolum.FormattingEnabled = true;
            this.bolum.Location = new System.Drawing.Point(399, 27);
            this.bolum.Name = "bolum";
            this.bolum.Size = new System.Drawing.Size(189, 21);
            this.bolum.TabIndex = 1;
            this.bolum.SelectedIndexChanged += new System.EventHandler(this.bolum_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 345);
            this.Controls.Add(this.bolum);
            this.Controls.Add(this.doktor_liste);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView doktor_liste;
        private System.Windows.Forms.ComboBox bolum;

    }
}