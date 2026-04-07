namespace Customer_Relationship_Management
{
    partial class Sales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales));
            btnSalesToCustomers = new Button();
            btnSales = new Button();
            btnSalesToDashboard = new Button();
            btnSalesToCategories = new Button();
            btnSalesToItems = new Button();
            btnSalesToHistory = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            btnSalesLogout = new Button();
            btnMinimizeSales = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalesToCustomers
            // 
            btnSalesToCustomers.BackColor = Color.FromArgb(85, 61, 30);
            btnSalesToCustomers.FlatAppearance.BorderSize = 0;
            btnSalesToCustomers.FlatStyle = FlatStyle.Flat;
            btnSalesToCustomers.ForeColor = SystemColors.Info;
            btnSalesToCustomers.Location = new Point(342, 68);
            btnSalesToCustomers.Name = "btnSalesToCustomers";
            btnSalesToCustomers.Size = new Size(171, 35);
            btnSalesToCustomers.TabIndex = 29;
            btnSalesToCustomers.Text = "Customers";
            btnSalesToCustomers.UseVisualStyleBackColor = false;
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
            btnSales.TabIndex = 28;
            btnSales.Text = "Sales";
            btnSales.UseVisualStyleBackColor = false;
            // 
            // btnSalesToDashboard
            // 
            btnSalesToDashboard.BackColor = Color.FromArgb(85, 61, 30);
            btnSalesToDashboard.FlatAppearance.BorderSize = 0;
            btnSalesToDashboard.FlatStyle = FlatStyle.Flat;
            btnSalesToDashboard.ForeColor = SystemColors.Info;
            btnSalesToDashboard.Location = new Point(0, 68);
            btnSalesToDashboard.Name = "btnSalesToDashboard";
            btnSalesToDashboard.Size = new Size(171, 35);
            btnSalesToDashboard.TabIndex = 27;
            btnSalesToDashboard.Text = "Dashboard";
            btnSalesToDashboard.UseVisualStyleBackColor = false;
            // 
            // btnSalesToCategories
            // 
            btnSalesToCategories.BackColor = Color.FromArgb(85, 61, 30);
            btnSalesToCategories.FlatAppearance.BorderSize = 0;
            btnSalesToCategories.FlatStyle = FlatStyle.Flat;
            btnSalesToCategories.ForeColor = SystemColors.Info;
            btnSalesToCategories.Location = new Point(684, 68);
            btnSalesToCategories.Name = "btnSalesToCategories";
            btnSalesToCategories.Size = new Size(171, 35);
            btnSalesToCategories.TabIndex = 31;
            btnSalesToCategories.Text = "Categories";
            btnSalesToCategories.UseVisualStyleBackColor = false;
            // 
            // btnSalesToItems
            // 
            btnSalesToItems.BackColor = Color.FromArgb(85, 61, 30);
            btnSalesToItems.FlatAppearance.BorderSize = 0;
            btnSalesToItems.FlatStyle = FlatStyle.Flat;
            btnSalesToItems.ForeColor = SystemColors.Info;
            btnSalesToItems.Location = new Point(513, 68);
            btnSalesToItems.Name = "btnSalesToItems";
            btnSalesToItems.Size = new Size(171, 35);
            btnSalesToItems.TabIndex = 30;
            btnSalesToItems.Text = "Items";
            btnSalesToItems.UseVisualStyleBackColor = false;
            // 
            // btnSalesToHistory
            // 
            btnSalesToHistory.BackColor = Color.FromArgb(85, 61, 30);
            btnSalesToHistory.FlatAppearance.BorderSize = 0;
            btnSalesToHistory.FlatStyle = FlatStyle.Flat;
            btnSalesToHistory.ForeColor = SystemColors.Info;
            btnSalesToHistory.Location = new Point(855, 68);
            btnSalesToHistory.Name = "btnSalesToHistory";
            btnSalesToHistory.Size = new Size(171, 35);
            btnSalesToHistory.TabIndex = 32;
            btnSalesToHistory.Text = "History";
            btnSalesToHistory.UseVisualStyleBackColor = false;
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
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(75, 54, 33);
            panel3.Controls.Add(btnMinimizeSales);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(pictureBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1160, 68);
            panel3.TabIndex = 2;
            // 
            // btnSalesLogout
            // 
            btnSalesLogout.BackColor = Color.FromArgb(85, 61, 30);
            btnSalesLogout.FlatAppearance.BorderSize = 0;
            btnSalesLogout.FlatStyle = FlatStyle.Flat;
            btnSalesLogout.ForeColor = SystemColors.Info;
            btnSalesLogout.Location = new Point(1026, 68);
            btnSalesLogout.Name = "btnSalesLogout";
            btnSalesLogout.Size = new Size(134, 35);
            btnSalesLogout.TabIndex = 33;
            btnSalesLogout.Text = "Logout";
            btnSalesLogout.UseVisualStyleBackColor = false;
            // 
            // btnMinimizeSales
            // 
            btnMinimizeSales.BackColor = Color.FromArgb(75, 54, 33);
            btnMinimizeSales.FlatAppearance.BorderSize = 0;
            btnMinimizeSales.FlatStyle = FlatStyle.Flat;
            btnMinimizeSales.Font = new Font("Verdana", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMinimizeSales.ForeColor = SystemColors.Info;
            btnMinimizeSales.Location = new Point(1094, 0);
            btnMinimizeSales.Name = "btnMinimizeSales";
            btnMinimizeSales.Size = new Size(54, 65);
            btnMinimizeSales.TabIndex = 28;
            btnMinimizeSales.Text = "_";
            btnMinimizeSales.UseVisualStyleBackColor = false;
            // 
            // Sales
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1160, 650);
            Controls.Add(btnSalesLogout);
            Controls.Add(panel3);
            Controls.Add(btnSalesToHistory);
            Controls.Add(btnSalesToItems);
            Controls.Add(btnSalesToCategories);
            Controls.Add(btnSalesToDashboard);
            Controls.Add(btnSales);
            Controls.Add(btnSalesToCustomers);
            Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Sales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sales";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalesToCustomers;
        private Button btnSales;
        private Button btnSalesToDashboard;
        private Button btnSalesToCategories;
        private Button btnSalesToItems;
        private Button btnSalesToHistory;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel3;
        private Button btnSalesLogout;
        private Button btnMinimizeSales;
    }
}