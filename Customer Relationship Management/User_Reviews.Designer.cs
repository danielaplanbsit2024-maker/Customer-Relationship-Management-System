namespace Customer_Relationship_Management
{
    partial class User_Reviews
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_Reviews));
            panel3 = new Panel();
            button5 = new Button();
            pictureBox1 = new PictureBox();
            btnMinimizeCustomers = new Button();
            pictureBox2 = new PictureBox();
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            reviewDescription = new TextBox();
            btnSubmit = new Button();
            btnHome = new Button();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(75, 54, 33);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(btnMinimizeCustomers);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(button3);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1160, 74);
            panel3.TabIndex = 52;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(75, 54, 33);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = SystemColors.Info;
            button5.Location = new Point(1010, 13);
            button5.Name = "button5";
            button5.Size = new Size(147, 46);
            button5.TabIndex = 55;
            button5.Text = "REVIEWS";
            button5.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(95, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(261, 52);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btnMinimizeCustomers
            // 
            btnMinimizeCustomers.BackColor = Color.FromArgb(75, 54, 33);
            btnMinimizeCustomers.FlatAppearance.BorderSize = 0;
            btnMinimizeCustomers.FlatStyle = FlatStyle.Flat;
            btnMinimizeCustomers.Font = new Font("Verdana", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMinimizeCustomers.ForeColor = SystemColors.Info;
            btnMinimizeCustomers.Location = new Point(1203, 0);
            btnMinimizeCustomers.Name = "btnMinimizeCustomers";
            btnMinimizeCustomers.Size = new Size(59, 57);
            btnMinimizeCustomers.TabIndex = 29;
            btnMinimizeCustomers.Text = "_";
            btnMinimizeCustomers.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-5, -8);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(108, 86);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(75, 54, 33);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.Info;
            button2.Location = new Point(552, 12);
            button2.Name = "button2";
            button2.Size = new Size(146, 47);
            button2.TabIndex = 46;
            button2.Text = "HOME";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(75, 54, 33);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.Info;
            button1.Location = new Point(707, 12);
            button1.Name = "button1";
            button1.Size = new Size(146, 47);
            button1.TabIndex = 45;
            button1.Text = "PRODUCTS";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(75, 54, 33);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = SystemColors.Info;
            button3.Location = new Point(857, 12);
            button3.Name = "button3";
            button3.Size = new Size(146, 47);
            button3.TabIndex = 47;
            button3.Text = "CART";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Franklin Gothic Medium", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1, 84);
            label1.Name = "label1";
            label1.Size = new Size(1157, 65);
            label1.TabIndex = 54;
            label1.Text = "REVIEWS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(293, 180);
            label2.Name = "label2";
            label2.Size = new Size(567, 54);
            label2.TabIndex = 55;
            label2.Text = "CUSTOMER REVIEWS";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // reviewDescription
            // 
            reviewDescription.BorderStyle = BorderStyle.FixedSingle;
            reviewDescription.Location = new Point(293, 261);
            reviewDescription.Multiline = true;
            reviewDescription.Name = "reviewDescription";
            reviewDescription.PlaceholderText = "FEEDBACK";
            reviewDescription.Size = new Size(567, 244);
            reviewDescription.TabIndex = 68;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.SeaGreen;
            btnSubmit.BackgroundImageLayout = ImageLayout.None;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.ForeColor = SystemColors.ButtonFace;
            btnSubmit.Location = new Point(589, 539);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(271, 52);
            btnSubmit.TabIndex = 69;
            btnSubmit.Text = "SUBMIT FEEDBACK";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.Firebrick;
            btnHome.BackgroundImageLayout = ImageLayout.None;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.ForeColor = SystemColors.ControlLightLight;
            btnHome.Location = new Point(293, 539);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(260, 52);
            btnHome.TabIndex = 70;
            btnHome.Text = "BACK TO HOME";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // User_Reviews
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 650);
            Controls.Add(btnHome);
            Controls.Add(btnSubmit);
            Controls.Add(reviewDescription);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel3);
            Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "User_Reviews";
            Text = "User_Reviews";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private Button button5;
        private PictureBox pictureBox1;
        private Button btnMinimizeCustomers;
        private PictureBox pictureBox2;
        private Button button2;
        private Button button1;
        private Button button3;
        private Label label1;
        private Label label2;
        private TextBox reviewDescription;
        private Button btnSubmit;
        private Button btnHome;
    }
}