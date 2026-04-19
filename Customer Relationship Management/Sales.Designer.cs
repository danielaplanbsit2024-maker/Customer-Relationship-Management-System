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
            btnSalesToHistory = new Button();
            btnSalesLogout = new Button();
            label9 = new Label();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            btnDashboardLogout = new Button();
            dateTimePicker2 = new DateTimePicker();
            textBox1 = new TextBox();
            button3 = new Button();
            btnExportToExcel = new Button();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            label4 = new Label();
            label16 = new Label();
            label5 = new Label();
            label17 = new Label();
            label6 = new Label();
            button5 = new Button();
            button6 = new Button();
            panel3 = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalesToCustomers
            // 
            btnSalesToCustomers.BackColor = Color.FromArgb(85, 61, 30);
            btnSalesToCustomers.FlatAppearance.BorderSize = 0;
            btnSalesToCustomers.FlatStyle = FlatStyle.Flat;
            btnSalesToCustomers.ForeColor = SystemColors.Info;
            btnSalesToCustomers.Location = new Point(555, 3);
            btnSalesToCustomers.Name = "btnSalesToCustomers";
            btnSalesToCustomers.Size = new Size(289, 60);
            btnSalesToCustomers.TabIndex = 29;
            btnSalesToCustomers.Text = "Customers";
            btnSalesToCustomers.UseVisualStyleBackColor = false;
            btnSalesToCustomers.Click += btnSalesToCustomers_Click;
            // 
            // btnSales
            // 
            btnSales.BackColor = Color.FromArgb(85, 61, 30);
            btnSales.FlatAppearance.BorderSize = 0;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.ForeColor = SystemColors.Info;
            btnSales.Location = new Point(302, 3);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(247, 60);
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
            btnSalesToDashboard.Location = new Point(3, 3);
            btnSalesToDashboard.Name = "btnSalesToDashboard";
            btnSalesToDashboard.Size = new Size(293, 60);
            btnSalesToDashboard.TabIndex = 27;
            btnSalesToDashboard.Text = "Dashboard";
            btnSalesToDashboard.UseVisualStyleBackColor = false;
            // 
            // btnSalesToHistory
            // 
            btnSalesToHistory.BackColor = Color.FromArgb(85, 61, 30);
            btnSalesToHistory.FlatAppearance.BorderSize = 0;
            btnSalesToHistory.FlatStyle = FlatStyle.Flat;
            btnSalesToHistory.ForeColor = SystemColors.Info;
            btnSalesToHistory.Location = new Point(850, 3);
            btnSalesToHistory.Name = "btnSalesToHistory";
            btnSalesToHistory.Size = new Size(289, 60);
            btnSalesToHistory.TabIndex = 32;
            btnSalesToHistory.Text = "History";
            btnSalesToHistory.UseVisualStyleBackColor = false;
            // 
            // btnSalesLogout
            // 
            btnSalesLogout.BackColor = Color.FromArgb(85, 61, 30);
            btnSalesLogout.FlatAppearance.BorderSize = 0;
            btnSalesLogout.FlatStyle = FlatStyle.Flat;
            btnSalesLogout.ForeColor = SystemColors.Info;
            btnSalesLogout.Location = new Point(1145, 3);
            btnSalesLogout.Name = "btnSalesLogout";
            btnSalesLogout.Size = new Size(255, 60);
            btnSalesLogout.TabIndex = 33;
            btnSalesLogout.Text = "Logout";
            btnSalesLogout.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.BackColor = Color.Tan;
            label9.Font = new Font("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(0, 205);
            label9.Name = "label9";
            label9.Size = new Size(1408, 113);
            label9.TabIndex = 35;
            label9.Click += label9_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Tan;
            label1.Font = new Font("Lucida Sans", 14F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(30, 225);
            label1.Name = "label1";
            label1.Size = new Size(195, 32);
            label1.TabIndex = 36;
            label1.Text = "START DATE";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.None;
            dateTimePicker1.CalendarFont = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Location = new Point(30, 260);
            dateTimePicker1.MaxDate = new DateTime(9000, 12, 31, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(201, 37);
            dateTimePicker1.TabIndex = 37;
            dateTimePicker1.Value = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Tan;
            label2.Font = new Font("Lucida Sans", 14F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(245, 225);
            label2.Name = "label2";
            label2.Size = new Size(162, 32);
            label2.TabIndex = 38;
            label2.Text = "END DATE";
            // 
            // btnDashboardLogout
            // 
            btnDashboardLogout.Anchor = AnchorStyles.None;
            btnDashboardLogout.BackColor = Color.White;
            btnDashboardLogout.FlatAppearance.BorderSize = 0;
            btnDashboardLogout.FlatStyle = FlatStyle.Flat;
            btnDashboardLogout.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboardLogout.ForeColor = Color.FromArgb(85, 61, 30);
            btnDashboardLogout.Location = new Point(573, 268);
            btnDashboardLogout.Name = "btnDashboardLogout";
            btnDashboardLogout.Size = new Size(159, 32);
            btnDashboardLogout.TabIndex = 40;
            btnDashboardLogout.Text = "Apply Filters";
            btnDashboardLogout.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Anchor = AnchorStyles.None;
            dateTimePicker2.CalendarFont = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker2.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker2.Location = new Point(245, 260);
            dateTimePicker2.MaxDate = new DateTime(9000, 12, 31, 0, 0, 0, 0);
            dateTimePicker2.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(201, 37);
            dateTimePicker2.TabIndex = 41;
            dateTimePicker2.Value = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.Location = new Point(738, 268);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(325, 32);
            textBox1.TabIndex = 42;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.BackColor = Color.PeachPuff;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Verdana", 12F, FontStyle.Bold);
            button3.ForeColor = Color.FromArgb(85, 61, 30);
            button3.Location = new Point(1083, 232);
            button3.Name = "button3";
            button3.Size = new Size(147, 65);
            button3.TabIndex = 43;
            button3.Text = "CLEAR";
            button3.UseVisualStyleBackColor = false;
            // 
            // btnExportToExcel
            // 
            btnExportToExcel.Anchor = AnchorStyles.None;
            btnExportToExcel.BackColor = Color.PeachPuff;
            btnExportToExcel.FlatAppearance.BorderSize = 0;
            btnExportToExcel.FlatStyle = FlatStyle.Flat;
            btnExportToExcel.Font = new Font("Verdana", 12F, FontStyle.Bold);
            btnExportToExcel.ForeColor = Color.FromArgb(85, 61, 30);
            btnExportToExcel.Location = new Point(1241, 232);
            btnExportToExcel.Name = "btnExportToExcel";
            btnExportToExcel.Size = new Size(147, 65);
            btnExportToExcel.TabIndex = 44;
            btnExportToExcel.Text = "EXPORT";
            btnExportToExcel.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = Color.Tan;
            label3.Font = new Font("Lucida Sans", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(582, 226);
            label3.Name = "label3";
            label3.Size = new Size(459, 32);
            label3.TabIndex = 45;
            label3.Text = "SEARCH INVOICE / CUSTOMER";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(9, 326);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1389, 468);
            dataGridView1.TabIndex = 46;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.BackColor = Color.Tan;
            label4.Font = new Font("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(0, 801);
            label4.Name = "label4";
            label4.Size = new Size(1408, 113);
            label4.TabIndex = 47;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.None;
            label16.AutoSize = true;
            label16.BackColor = SystemColors.ControlDark;
            label16.Font = new Font("Verdana", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = SystemColors.ControlDark;
            label16.Location = new Point(619, 476);
            label16.Name = "label16";
            label16.Size = new Size(191, 34);
            label16.TabIndex = 48;
            label16.Text = "[database]";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ControlDark;
            label5.Font = new Font("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlDark;
            label5.Location = new Point(179, 545);
            label5.Name = "label5";
            label5.Size = new Size(1079, 25);
            label5.TabIndex = 49;
            label5.Text = "InvoiceID | Date and Time | Customer Name | OrderID | CAtegory | Subtotal | Add-ons | Total";
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.None;
            label17.AutoSize = true;
            label17.BackColor = Color.Tan;
            label17.Font = new Font("Verdana", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.Black;
            label17.Location = new Point(11, 840);
            label17.Name = "label17";
            label17.Size = new Size(581, 34);
            label17.TabIndex = 50;
            label17.Text = "TOTAL FOR PERIOD: PHP 45,200.00";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.BackColor = Color.Tan;
            label6.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(596, 842);
            label6.Name = "label6";
            label6.Size = new Size(227, 29);
            label6.TabIndex = 51;
            label6.Text = "Transactions: 345";
            label6.Click += label6_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.None;
            button5.BackColor = Color.PeachPuff;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Verdana", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.FromArgb(85, 61, 30);
            button5.Location = new Point(1121, 816);
            button5.Name = "button5";
            button5.Size = new Size(273, 86);
            button5.TabIndex = 52;
            button5.Text = "ISSUE REFUND";
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.None;
            button6.BackColor = Color.FromArgb(75, 54, 33);
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Verdana", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Location = new Point(836, 816);
            button6.Name = "button6";
            button6.Size = new Size(278, 86);
            button6.TabIndex = 53;
            button6.Text = "VIEW RECEIPTS";
            button6.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.None;
            panel3.BackColor = Color.FromArgb(75, 54, 33);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(pictureBox1);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1408, 146);
            panel3.TabIndex = 64;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(11, -10);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(158, 165);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(186, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(534, 133);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.None;
            flowLayoutPanel2.BackColor = Color.FromArgb(85, 61, 30);
            flowLayoutPanel2.Controls.Add(btnSalesToDashboard);
            flowLayoutPanel2.Controls.Add(btnSales);
            flowLayoutPanel2.Controls.Add(btnSalesToCustomers);
            flowLayoutPanel2.Controls.Add(btnSalesToHistory);
            flowLayoutPanel2.Controls.Add(btnSalesLogout);
            flowLayoutPanel2.Location = new Point(0, 146);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1408, 59);
            flowLayoutPanel2.TabIndex = 65;
            // 
            // Sales
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1408, 914);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(panel3);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(label6);
            Controls.Add(label17);
            Controls.Add(label5);
            Controls.Add(label16);
            Controls.Add(label4);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(btnExportToExcel);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(btnDashboardLogout);
            Controls.Add(label2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Controls.Add(label9);
            Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Sales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sales";
            WindowState = FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalesToCustomers;
        private Button btnSales;
        private Button btnSalesToDashboard;
        private Button btnSalesToHistory;
        private Button btnSalesLogout;
        private Label label9;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private Button btnDashboardLogout;
        private DateTimePicker dateTimePicker2;
        private TextBox textBox1;
        private Button button3;
        private Button btnExportToExcel;
        private Label label3;
        private DataGridView dataGridView1;
        private Label label4;
        private Label label16;
        private Label label5;
        private Label label17;
        private Label label6;
        private Button button5;
        private Button button6;
        private Panel panel3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}