namespace Customer_Relationship_Management
{
    partial class User_Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_Home));
            pictureBox3 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button4 = new Button();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            btnlogout = new Button();
            panel3 = new Panel();
            button5 = new Button();
            button1 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.None;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(50, 231);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(656, 600);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 48;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Gabriola", 50F, FontStyle.Bold);
            label1.Location = new Point(712, 231);
            label1.Name = "label1";
            label1.Size = new Size(673, 138);
            label1.TabIndex = 51;
            label1.Text = "WELCOME BACK!";
            label1.TextAlign = ContentAlignment.BottomLeft;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Ink Free", 26F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(781, 390);
            label2.Name = "label2";
            label2.Size = new Size(512, 76);
            label2.TabIndex = 52;
            label2.Text = "TIME FOR A BREW?";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Courier New", 10F);
            label3.Location = new Point(712, 466);
            label3.Name = "label3";
            label3.Size = new Size(634, 22);
            label3.TabIndex = 53;
            label3.Text = "Freshly brewed coffee and snacks, just a click away.";
            label3.Click += label3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.None;
            button4.BackColor = Color.Tan;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Impact", 24F);
            button4.ForeColor = Color.Sienna;
            button4.Location = new Point(758, 539);
            button4.Name = "button4";
            button4.Size = new Size(535, 85);
            button4.TabIndex = 54;
            button4.Text = "Order Now!";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.None;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(12, -5);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(143, 151);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 56;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.None;
            pictureBox4.BackgroundImageLayout = ImageLayout.None;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(161, 12);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(460, 119);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 51;
            pictureBox4.TabStop = false;
            // 
            // btnlogout
            // 
            btnlogout.Anchor = AnchorStyles.None;
            btnlogout.BackColor = Color.FromArgb(75, 54, 33);
            btnlogout.FlatAppearance.BorderSize = 0;
            btnlogout.FlatStyle = FlatStyle.Flat;
            btnlogout.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnlogout.ForeColor = SystemColors.Info;
            btnlogout.Location = new Point(1191, 49);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(179, 43);
            btnlogout.TabIndex = 46;
            btnlogout.Text = "LOG OUT";
            btnlogout.UseVisualStyleBackColor = false;
            btnlogout.Click += btnlogout_Click_1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(75, 54, 33);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(btnlogout);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(pictureBox5);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1408, 138);
            panel3.TabIndex = 35;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(75, 54, 33);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Verdana", 12F);
            button5.ForeColor = SystemColors.Info;
            button5.Location = new Point(1047, 48);
            button5.Name = "button5";
            button5.Size = new Size(147, 46);
            button5.TabIndex = 59;
            button5.Text = "REVIEWS";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(75, 54, 33);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Verdana", 12F);
            button1.ForeColor = SystemColors.Info;
            button1.Location = new Point(720, 48);
            button1.Name = "button1";
            button1.Size = new Size(161, 47);
            button1.TabIndex = 57;
            button1.Text = "PRODUCTS";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(75, 54, 33);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Verdana", 12F);
            button3.ForeColor = SystemColors.Info;
            button3.Location = new Point(893, 47);
            button3.Name = "button3";
            button3.Size = new Size(146, 47);
            button3.TabIndex = 58;
            button3.Text = "CART";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click_1;
            // 
            // User_Home
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 234, 211);
            ClientSize = new Size(1408, 914);
            Controls.Add(button4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(panel3);
            Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "User_Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button4;
        private Label homeUsername;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private Button btnlogout;
        private Panel panel3;
        private Button button5;
        private Button button1;
        private Button button3;
    }
}
