namespace Customer_Relationship_Management
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            txtRegisterPassword = new TextBox();
            lblRegisterPassword = new Label();
            txtRegisterUsername = new TextBox();
            lblRegisterUsername = new Label();
            txtRegisterConfirmPass = new TextBox();
            lblRegisterConfirmPass = new Label();
            btnRegister = new Button();
            btnRegisterLogin = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(75, 54, 33);
            panel1.Controls.Add(pictureBox2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 637);
            panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(300, 638);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(353, 72);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(415, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // txtRegisterPassword
            // 
            txtRegisterPassword.Location = new Point(353, 331);
            txtRegisterPassword.Name = "txtRegisterPassword";
            txtRegisterPassword.Size = new Size(415, 37);
            txtRegisterPassword.TabIndex = 14;
            // 
            // lblRegisterPassword
            // 
            lblRegisterPassword.AutoSize = true;
            lblRegisterPassword.ForeColor = Color.FromArgb(75, 54, 33);
            lblRegisterPassword.Location = new Point(353, 295);
            lblRegisterPassword.Name = "lblRegisterPassword";
            lblRegisterPassword.Size = new Size(128, 29);
            lblRegisterPassword.TabIndex = 13;
            lblRegisterPassword.Text = "password";
            // 
            // txtRegisterUsername
            // 
            txtRegisterUsername.Location = new Point(353, 252);
            txtRegisterUsername.Name = "txtRegisterUsername";
            txtRegisterUsername.Size = new Size(415, 37);
            txtRegisterUsername.TabIndex = 12;
            txtRegisterUsername.TextChanged += txtRegisterUsername_TextChanged;
            // 
            // lblRegisterUsername
            // 
            lblRegisterUsername.AutoSize = true;
            lblRegisterUsername.ForeColor = Color.FromArgb(75, 54, 33);
            lblRegisterUsername.Location = new Point(353, 216);
            lblRegisterUsername.Name = "lblRegisterUsername";
            lblRegisterUsername.Size = new Size(131, 29);
            lblRegisterUsername.TabIndex = 11;
            lblRegisterUsername.Text = "username";
            // 
            // txtRegisterConfirmPass
            // 
            txtRegisterConfirmPass.Location = new Point(353, 410);
            txtRegisterConfirmPass.Name = "txtRegisterConfirmPass";
            txtRegisterConfirmPass.Size = new Size(415, 37);
            txtRegisterConfirmPass.TabIndex = 16;
            // 
            // lblRegisterConfirmPass
            // 
            lblRegisterConfirmPass.AutoSize = true;
            lblRegisterConfirmPass.ForeColor = Color.FromArgb(75, 54, 33);
            lblRegisterConfirmPass.Location = new Point(353, 374);
            lblRegisterConfirmPass.Name = "lblRegisterConfirmPass";
            lblRegisterConfirmPass.Size = new Size(226, 29);
            lblRegisterConfirmPass.TabIndex = 15;
            lblRegisterConfirmPass.Text = "confirm password";
            lblRegisterConfirmPass.Click += label2_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(75, 54, 33);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = SystemColors.Info;
            btnRegister.Location = new Point(455, 481);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(197, 47);
            btnRegister.TabIndex = 19;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnRegisterLogin
            // 
            btnRegisterLogin.BackColor = SystemColors.Info;
            btnRegisterLogin.FlatAppearance.BorderSize = 0;
            btnRegisterLogin.FlatStyle = FlatStyle.Flat;
            btnRegisterLogin.Font = new Font("Verdana", 10F, FontStyle.Underline, GraphicsUnit.Point, 0);
            btnRegisterLogin.ForeColor = Color.FromArgb(75, 54, 33);
            btnRegisterLogin.Location = new Point(455, 531);
            btnRegisterLogin.Name = "btnRegisterLogin";
            btnRegisterLogin.Size = new Size(197, 34);
            btnRegisterLogin.TabIndex = 20;
            btnRegisterLogin.Text = "Login";
            btnRegisterLogin.UseVisualStyleBackColor = false;
            btnRegisterLogin.Click += btnRegisterLogin_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(15F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(997, 637);
            Controls.Add(btnRegisterLogin);
            Controls.Add(btnRegister);
            Controls.Add(txtRegisterConfirmPass);
            Controls.Add(lblRegisterConfirmPass);
            Controls.Add(txtRegisterPassword);
            Controls.Add(lblRegisterPassword);
            Controls.Add(txtRegisterUsername);
            Controls.Add(lblRegisterUsername);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Register";
            Text = "Register";
            Load += Register_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private TextBox txtRegisterPassword;
        private Label lblRegisterPassword;
        private TextBox txtRegisterUsername;
        private Label lblRegisterUsername;
        private TextBox txtRegisterConfirmPass;
        private Label lblRegisterConfirmPass;
        private Button btnRegister;
        private Button btnRegisterLogin;
    }
}