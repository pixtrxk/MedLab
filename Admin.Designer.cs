namespace MedLab
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AdminPasswordTB = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoginBTN = new Bunifu.Framework.UI.BunifuThinButton2();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(215, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 47);
            this.label2.TabIndex = 77;
            this.label2.Text = "MedLab";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(254, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 76;
            this.label1.Text = "Password";
            // 
            // AdminPasswordTB
            // 
            this.AdminPasswordTB.Location = new System.Drawing.Point(212, 182);
            this.AdminPasswordTB.Multiline = true;
            this.AdminPasswordTB.Name = "AdminPasswordTB";
            this.AdminPasswordTB.Size = new System.Drawing.Size(176, 27);
            this.AdminPasswordTB.TabIndex = 75;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MedLab.Properties.Resources.fizzing_flask;
            this.pictureBox1.Location = new System.Drawing.Point(265, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 80;
            this.pictureBox1.TabStop = false;
            // 
            // LoginBTN
            // 
            this.LoginBTN.ActiveBorderThickness = 1;
            this.LoginBTN.ActiveCornerRadius = 20;
            this.LoginBTN.ActiveFillColor = System.Drawing.Color.Firebrick;
            this.LoginBTN.ActiveForecolor = System.Drawing.Color.LightGray;
            this.LoginBTN.ActiveLineColor = System.Drawing.Color.DarkMagenta;
            this.LoginBTN.BackColor = System.Drawing.SystemColors.Control;
            this.LoginBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoginBTN.BackgroundImage")));
            this.LoginBTN.ButtonText = "Login";
            this.LoginBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginBTN.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBTN.ForeColor = System.Drawing.Color.SeaGreen;
            this.LoginBTN.IdleBorderThickness = 1;
            this.LoginBTN.IdleCornerRadius = 20;
            this.LoginBTN.IdleFillColor = System.Drawing.Color.Firebrick;
            this.LoginBTN.IdleForecolor = System.Drawing.Color.Honeydew;
            this.LoginBTN.IdleLineColor = System.Drawing.Color.Firebrick;
            this.LoginBTN.Location = new System.Drawing.Point(212, 226);
            this.LoginBTN.Margin = new System.Windows.Forms.Padding(5);
            this.LoginBTN.Name = "LoginBTN";
            this.LoginBTN.Size = new System.Drawing.Size(176, 47);
            this.LoginBTN.TabIndex = 78;
            this.LoginBTN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LoginBTN.Click += new System.EventHandler(this.LoginBTN_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 306);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoginBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AdminPasswordTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 LoginBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AdminPasswordTB;
    }
}