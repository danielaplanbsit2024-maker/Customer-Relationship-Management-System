namespace Customer_Relationship_Management
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

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
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(75, 54, 33);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(570, 914);
            panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(140, 299);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(289, 314);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(677, 104);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(632, 177);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lblLoginUsername
            // 
            lblLoginUsername.Anchor = AnchorStyles.None;
            lblLoginUsername.AutoSize = true;
            lblLoginUsername.Font = new Font("Verdana", 20F);
            lblLoginUsername.ForeColor = Color.FromArgb(75, 54, 33);
            lblLoginUsername.Location = new Point(677, 408);
            lblLoginUsername.Name = "lblLoginUsername";
            lblLoginUsername.Size = new Size(219, 48);
            lblLoginUsername.TabIndex = 3;
            lblLoginUsername.Text = "username";
            // 
            // txtLoginUsername
            // 
            txtLoginUsername.Anchor = AnchorStyles.None;
            txtLoginUsername.Location = new Point(677, 459);
            txtLoginUsername.Name = "txtLoginUsername";
            txtLoginUsername.Size = new Size(632, 37);
            txtLoginUsername.TabIndex = 4;
            txtLoginUsername.TextChanged += txtLoginUsername_TextChanged;
            // 
            // txtLoginPassword
            // 
            txtLoginPassword.Anchor = AnchorStyles.None;
            txtLoginPassword.Location = new Point(677, 569);
            txtLoginPassword.Name = "txtLoginPassword";
            txtLoginPassword.Size = new Size(632, 37);
            txtLoginPassword.TabIndex = 6;
            // 
            // lblLoginPassword
            // 
            lblLoginPassword.Anchor = AnchorStyles.None;
            lblLoginPassword.AutoSize = true;
            lblLoginPassword.Font = new Font("Verdana", 20F);
            lblLoginPassword.ForeColor = Color.FromArgb(75, 54, 33);
            lblLoginPassword.Location = new Point(677, 518);
            lblLoginPassword.Name = "lblLoginPassword";
            lblLoginPassword.Size = new Size(210, 48);
            lblLoginPassword.TabIndex = 5;
            lblLoginPassword.Text = "password";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.BackColor = Color.FromArgb(75, 54, 33);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.Info;
            btnLogin.Location = new Point(840, 691);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(298, 82);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnLoginRegister
            // 
            btnLoginRegister.Anchor = AnchorStyles.None;
            btnLoginRegister.BackColor = SystemColors.Info;
            btnLoginRegister.FlatAppearance.BorderSize = 0;
            btnLoginRegister.FlatStyle = FlatStyle.Flat;
            btnLoginRegister.Font = new Font("Verdana", 16F, FontStyle.Underline, GraphicsUnit.Point, 0);
            btnLoginRegister.ForeColor = Color.FromArgb(75, 54, 33);
            btnLoginRegister.Location = new Point(892, 776);
            btnLoginRegister.Name = "btnLoginRegister";
            btnLoginRegister.Size = new Size(202, 47);
            btnLoginRegister.TabIndex = 10;
            btnLoginRegister.Text = "Register";
            btnLoginRegister.UseVisualStyleBackColor = false;
            btnLoginRegister.Click += btnLoginRegister_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(15F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1408, 914);
            Controls.Add(btnLoginRegister);
            Controls.Add(btnLogin);
            Controls.Add(txtLoginPassword);
            Controls.Add(lblLoginPassword);
            Controls.Add(txtLoginUsername);
            Controls.Add(lblLoginUsername);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Login";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Login";
            WindowState = FormWindowState.Minimized;
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
    }
}