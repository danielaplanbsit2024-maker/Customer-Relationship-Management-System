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
            txtRegisterPassword = new TextBox();
            lblRegisterPassword = new Label();
            txtRegisterUsername = new TextBox();
            lblRegisterUsername = new Label();
            txtRegisterConfirmPass = new TextBox();
            lblRegisterConfirmPass = new Label();
            btnRegister = new Button();
            btnRegisterLogin = new Button();
            panel2 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtRegisterPassword
            // 
            txtRegisterPassword.Location = new Point(679, 529);
            txtRegisterPassword.Name = "txtRegisterPassword";
            txtRegisterPassword.Size = new Size(632, 37);
            txtRegisterPassword.TabIndex = 14;
            // 
            // lblRegisterPassword
            // 
            lblRegisterPassword.AutoSize = true;
            lblRegisterPassword.Font = new Font("Verdana", 20F);
            lblRegisterPassword.ForeColor = Color.FromArgb(75, 54, 33);
            lblRegisterPassword.Location = new Point(679, 478);
            lblRegisterPassword.Name = "lblRegisterPassword";
            lblRegisterPassword.Size = new Size(210, 48);
            lblRegisterPassword.TabIndex = 13;
            lblRegisterPassword.Text = "password";
            // 
            // txtRegisterUsername
            // 
            txtRegisterUsername.Location = new Point(679, 415);
            txtRegisterUsername.Name = "txtRegisterUsername";
            txtRegisterUsername.Size = new Size(632, 37);
            txtRegisterUsername.TabIndex = 12;
            txtRegisterUsername.TextChanged += txtRegisterUsername_TextChanged;
            // 
            // lblRegisterUsername
            // 
            lblRegisterUsername.AutoSize = true;
            lblRegisterUsername.Font = new Font("Verdana", 20F);
            lblRegisterUsername.ForeColor = Color.FromArgb(75, 54, 33);
            lblRegisterUsername.Location = new Point(679, 364);
            lblRegisterUsername.Name = "lblRegisterUsername";
            lblRegisterUsername.Size = new Size(219, 48);
            lblRegisterUsername.TabIndex = 11;
            lblRegisterUsername.Text = "username";
            // 
            // txtRegisterConfirmPass
            // 
            txtRegisterConfirmPass.Location = new Point(679, 645);
            txtRegisterConfirmPass.Name = "txtRegisterConfirmPass";
            txtRegisterConfirmPass.Size = new Size(632, 37);
            txtRegisterConfirmPass.TabIndex = 16;
            // 
            // lblRegisterConfirmPass
            // 
            lblRegisterConfirmPass.AutoSize = true;
            lblRegisterConfirmPass.Font = new Font("Verdana", 20F);
            lblRegisterConfirmPass.ForeColor = Color.FromArgb(75, 54, 33);
            lblRegisterConfirmPass.Location = new Point(679, 594);
            lblRegisterConfirmPass.Name = "lblRegisterConfirmPass";
            lblRegisterConfirmPass.Size = new Size(376, 48);
            lblRegisterConfirmPass.TabIndex = 15;
            lblRegisterConfirmPass.Text = "confirm password";
            lblRegisterConfirmPass.Click += label2_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(75, 54, 33);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = SystemColors.Info;
            btnRegister.Location = new Point(857, 741);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(258, 77);
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
            btnRegisterLogin.Font = new Font("Verdana", 16F, FontStyle.Underline, GraphicsUnit.Point, 0);
            btnRegisterLogin.ForeColor = Color.FromArgb(75, 54, 33);
            btnRegisterLogin.Location = new Point(877, 821);
            btnRegisterLogin.Name = "btnRegisterLogin";
            btnRegisterLogin.Size = new Size(223, 48);
            btnRegisterLogin.TabIndex = 20;
            btnRegisterLogin.Text = "Login";
            btnRegisterLogin.UseVisualStyleBackColor = false;
            btnRegisterLogin.Click += btnRegisterLogin_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.FromArgb(75, 54, 33);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(pictureBox3);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(570, 914);
            panel2.TabIndex = 2;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.None;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(140, 299);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(289, 314);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(679, 89);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(632, 177);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(15F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1408, 914);
            Controls.Add(pictureBox1);
            Controls.Add(panel2);
            Controls.Add(btnRegisterLogin);
            Controls.Add(btnRegister);
            Controls.Add(txtRegisterConfirmPass);
            Controls.Add(lblRegisterConfirmPass);
            Controls.Add(txtRegisterPassword);
            Controls.Add(lblRegisterPassword);
            Controls.Add(txtRegisterUsername);
            Controls.Add(lblRegisterUsername);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Register";
            Text = "Register";
            Load += Register_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtRegisterPassword;
        private Label lblRegisterPassword;
        private TextBox txtRegisterUsername;
        private Label lblRegisterUsername;
        private TextBox txtRegisterConfirmPass;
        private Label lblRegisterConfirmPass;
        private Button btnRegister;
        private Button btnRegisterLogin;
        private Panel panel2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
    }
}