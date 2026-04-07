namespace Customer_Relationship_Management
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            panel3 = new Panel();
            pictureBox2 = new PictureBox();
            lblExit = new Label();
            pictureBox1 = new PictureBox();
            btnDashboard = new Button();
            btnSales = new Button();
            btnCustomers = new Button();
            btnItems = new Button();
            btnCategories = new Button();
            btnHistory = new Button();
            btnLogout = new Button();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(75, 54, 33);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(lblExit);
            panel3.Controls.Add(pictureBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1160, 68);
            panel3.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, -14);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(98, 98);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // lblExit
            // 
            lblExit.AutoSize = true;
            lblExit.Font = new Font("Verdana", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExit.ForeColor = SystemColors.Info;
            lblExit.Location = new Point(1103, 9);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size(45, 48);
            lblExit.TabIndex = 11;
            lblExit.Text = "_";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(105, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(301, 70);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(85, 61, 30);
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ForeColor = SystemColors.Info;
            btnDashboard.Location = new Point(0, 68);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(171, 35);
            btnDashboard.TabIndex = 20;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // btnSales
            // 
            btnSales.BackColor = Color.FromArgb(85, 61, 30);
            btnSales.FlatAppearance.BorderSize = 0;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.ForeColor = SystemColors.Info;
            btnSales.Location = new Point(171, 68);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(171, 35);
            btnSales.TabIndex = 21;
            btnSales.Text = "Sales";
            btnSales.UseVisualStyleBackColor = false;
            // 
            // btnCustomers
            // 
            btnCustomers.BackColor = Color.FromArgb(85, 61, 30);
            btnCustomers.FlatAppearance.BorderSize = 0;
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.ForeColor = SystemColors.Info;
            btnCustomers.Location = new Point(342, 68);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(171, 35);
            btnCustomers.TabIndex = 22;
            btnCustomers.Text = "Customers";
            btnCustomers.UseVisualStyleBackColor = false;
            // 
            // btnItems
            // 
            btnItems.BackColor = Color.FromArgb(85, 61, 30);
            btnItems.FlatAppearance.BorderSize = 0;
            btnItems.FlatStyle = FlatStyle.Flat;
            btnItems.ForeColor = SystemColors.Info;
            btnItems.Location = new Point(513, 68);
            btnItems.Name = "btnItems";
            btnItems.Size = new Size(171, 35);
            btnItems.TabIndex = 23;
            btnItems.Text = "Items";
            btnItems.UseVisualStyleBackColor = false;
            // 
            // btnCategories
            // 
            btnCategories.BackColor = Color.FromArgb(85, 61, 30);
            btnCategories.FlatAppearance.BorderSize = 0;
            btnCategories.FlatStyle = FlatStyle.Flat;
            btnCategories.ForeColor = SystemColors.Info;
            btnCategories.Location = new Point(684, 68);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(171, 35);
            btnCategories.TabIndex = 24;
            btnCategories.Text = "Categories";
            btnCategories.UseVisualStyleBackColor = false;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.FromArgb(85, 61, 30);
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.ForeColor = SystemColors.Info;
            btnHistory.Location = new Point(855, 68);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(171, 35);
            btnHistory.TabIndex = 25;
            btnHistory.Text = "History";
            btnHistory.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(85, 61, 30);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = SystemColors.Info;
            btnLogout.Location = new Point(1026, 68);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(134, 35);
            btnLogout.TabIndex = 26;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // Items
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1160, 650);
            Controls.Add(btnLogout);
            Controls.Add(btnHistory);
            Controls.Add(btnCategories);
            Controls.Add(btnItems);
            Controls.Add(btnCustomers);
            Controls.Add(btnSales);
            Controls.Add(btnDashboard);
            Controls.Add(panel3);
            Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Items";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Items";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel3;
        private PictureBox pictureBox1;
        private Label lblExit;
        private PictureBox pictureBox2;
        private Button btnDashboard;
        private Button btnSales;
        private Button btnCustomers;
        private Button btnItems;
        private Button btnCategories;
        private Button btnHistory;
        private Button btnLogout;
    }
}