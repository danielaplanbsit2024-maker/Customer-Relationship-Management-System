namespace Customer_Relationship_Management
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            lblLoginUsername = new Label();
            txtLoginUsername = new TextBox();
            txtLoginPassword = new TextBox();
            lblLoginPassword = new Label();
            btnLogin = new Button();
            btnLoginRegister = new Button();
            btnLoginExit = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(75, 54, 33);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 600);
            panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-1, -1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(300, 594);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(357, 80);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(415, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // lblLoginUsername
            // 
            lblLoginUsername.AutoSize = true;
            lblLoginUsername.ForeColor = Color.FromArgb(75, 54, 33);
            lblLoginUsername.Location = new Point(357, 259);
            lblLoginUsername.Name = "lblLoginUsername";
            lblLoginUsername.Size = new Size(131, 29);
            lblLoginUsername.TabIndex = 3;
            lblLoginUsername.Text = "username";
            // 
            // txtLoginUsername
            // 
            txtLoginUsername.Location = new Point(357, 295);
            txtLoginUsername.Name = "txtLoginUsername";
            txtLoginUsername.Size = new Size(415, 37);
            txtLoginUsername.TabIndex = 4;
            // 
            // txtLoginPassword
            // 
            txtLoginPassword.Location = new Point(357, 386);
            txtLoginPassword.Name = "txtLoginPassword";
            txtLoginPassword.Size = new Size(415, 37);
            txtLoginPassword.TabIndex = 6;
            // 
            // lblLoginPassword
            // 
            lblLoginPassword.AutoSize = true;
            lblLoginPassword.ForeColor = Color.FromArgb(75, 54, 33);
            lblLoginPassword.Location = new Point(357, 350);
            lblLoginPassword.Name = "lblLoginPassword";
            lblLoginPassword.Size = new Size(128, 29);
            lblLoginPassword.TabIndex = 5;
            lblLoginPassword.Text = "password";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(75, 54, 33);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = SystemColors.Info;
            btnLogin.Location = new Point(461, 459);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(197, 47);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // btnLoginRegister
            // 
            btnLoginRegister.BackColor = SystemColors.Info;
            btnLoginRegister.FlatAppearance.BorderSize = 0;
            btnLoginRegister.FlatStyle = FlatStyle.Flat;
            btnLoginRegister.Font = new Font("Verdana", 10F, FontStyle.Underline, GraphicsUnit.Point, 0);
            btnLoginRegister.ForeColor = Color.FromArgb(75, 54, 33);
            btnLoginRegister.Location = new Point(461, 509);
            btnLoginRegister.Name = "btnLoginRegister";
            btnLoginRegister.Size = new Size(197, 34);
            btnLoginRegister.TabIndex = 10;
            btnLoginRegister.Text = "Register";
            btnLoginRegister.UseVisualStyleBackColor = false;
            // 
            // btnLoginExit
            // 
            btnLoginExit.BackColor = SystemColors.Info;
            btnLoginExit.FlatAppearance.BorderSize = 0;
            btnLoginExit.FlatStyle = FlatStyle.Flat;
            btnLoginExit.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLoginExit.ForeColor = Color.FromArgb(75, 54, 33);
            btnLoginExit.Location = new Point(790, 2);
            btnLoginExit.Name = "btnLoginExit";
            btnLoginExit.Size = new Size(38, 34);
            btnLoginExit.TabIndex = 11;
            btnLoginExit.Text = "X";
            btnLoginExit.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(15F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(830, 600);
            Controls.Add(btnLoginExit);
            Controls.Add(btnLoginRegister);
            Controls.Add(btnLogin);
            Controls.Add(txtLoginPassword);
            Controls.Add(lblLoginPassword);
            Controls.Add(txtLoginUsername);
            Controls.Add(lblLoginUsername);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label lblLoginUsername;
        private TextBox txtLoginUsername;
        private TextBox txtLoginPassword;
        private Label lblLoginPassword;
        private Button btnLogin;
        private Label lblRegister;
        private PictureBox pictureBox2;
        private Button btnLoginRegister;
        private Button btnLoginExit;
    }
}