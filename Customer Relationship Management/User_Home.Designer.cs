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
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            btnlogout = new Button();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
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
            label1.Size = new Size(673, 222);
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
            label2.Location = new Point(734, 490);
            label2.Name = "label2";
            label2.Size = new Size(363, 64);
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
            label3.Location = new Point(734, 582);
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
            button4.Location = new Point(780, 695);
            button4.Name = "button4";
            button4.Size = new Size(535, 85);
            button4.TabIndex = 54;
            button4.Text = "Order Now";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.None;
            pictureBox4.BackgroundImageLayout = ImageLayout.None;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(161, 15);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(500, 119);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 51;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.None;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(12, -2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(143, 150);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 56;
            pictureBox5.TabStop = false;
            // 
            // btnlogout
            // 
            btnlogout.Anchor = AnchorStyles.None;
            btnlogout.BackColor = Color.FromArgb(75, 54, 33);
            btnlogout.FlatAppearance.BorderSize = 0;
            btnlogout.FlatStyle = FlatStyle.Flat;
            btnlogout.Font = new Font("Verdana", 15F);
            btnlogout.ForeColor = SystemColors.Info;
            btnlogout.Location = new Point(1201, 37);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(184, 75);
            btnlogout.TabIndex = 46;
            btnlogout.Text = "Logout";
            btnlogout.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.None;
            panel3.BackColor = Color.FromArgb(75, 54, 33);
            panel3.Controls.Add(btnlogout);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(pictureBox5);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1408, 145);
            panel3.TabIndex = 35;
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
            Controls.Add(panel3);
            Controls.Add(pictureBox3);
            Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "User_Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            WindowState = FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
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
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private Button btnlogout;
        private Panel panel3;
    }
}