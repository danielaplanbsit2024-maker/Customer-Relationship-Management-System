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
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            btnlogout = new Button();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button4 = new Button();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(75, 54, 33);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(btnlogout);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1280, 111);
            panel3.TabIndex = 35;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(112, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(261, 52);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 9);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(108, 86);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // btnlogout
            // 
            btnlogout.BackColor = Color.FromArgb(75, 54, 33);
            btnlogout.FlatAppearance.BorderSize = 0;
            btnlogout.FlatStyle = FlatStyle.Flat;
            btnlogout.Font = new Font("Verdana", 15F);
            btnlogout.ForeColor = SystemColors.Info;
            btnlogout.Location = new Point(1084, 12);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(184, 75);
            btnlogout.TabIndex = 46;
            btnlogout.Text = "Logout";
            btnlogout.UseVisualStyleBackColor = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(52, 214);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(565, 462);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 48;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Gabriola", 50F, FontStyle.Bold);
            label1.Location = new Point(623, 214);
            label1.Name = "label1";
            label1.Size = new Size(454, 124);
            label1.TabIndex = 51;
            label1.Text = "WELCOME BACK!";
            label1.TextAlign = ContentAlignment.BottomLeft;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Ink Free", 26F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(648, 377);
            label2.Name = "label2";
            label2.Size = new Size(363, 64);
            label2.TabIndex = 52;
            label2.Text = "TIME FOR A BREW?";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Courier New", 10F);
            label3.Location = new Point(648, 441);
            label3.Name = "label3";
            label3.Size = new Size(424, 17);
            label3.TabIndex = 53;
            label3.Text = "Freshly brewed coffee and snacks, just a click away.";
            label3.Click += label3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Tan;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Impact", 20F);
            button4.ForeColor = Color.Sienna;
            button4.Location = new Point(648, 492);
            button4.Name = "button4";
            button4.Size = new Size(535, 85);
            button4.TabIndex = 54;
            button4.Text = "Order Now";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // User_Home
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 234, 211);
            ClientSize = new Size(1280, 785);
            Controls.Add(button4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(panel3);
            Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "User_Home";
            Text = "1";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button button1;
        private Button btnlogout;
        private Button button3;
        private PictureBox pictureBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button4;
        private Button button5;
        private Label homeUsername;
    }
}