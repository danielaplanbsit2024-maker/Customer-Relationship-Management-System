namespace Customer_Relationship_Management
{
    partial class User_Checkout_Ewallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_Checkout_Ewallet));
            panel3 = new Panel();
            Reviews = new Button();
            pictureBox1 = new PictureBox();
            btnMinimizeCustomers = new Button();
            pictureBox2 = new PictureBox();
            btnhome = new Button();
            btnProducts = new Button();
            cart = new Button();
            label7 = new Label();
            amountToBePaid = new Label();
            label6 = new Label();
            name = new TextBox();
            label3 = new Label();
            phoneNo = new TextBox();
            label1 = new Label();
            Amount = new TextBox();
            label2 = new Label();
            confirmPayment = new Button();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(75, 54, 33);
            panel3.Controls.Add(Reviews);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(btnMinimizeCustomers);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(btnhome);
            panel3.Controls.Add(btnProducts);
            panel3.Controls.Add(cart);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1160, 74);
            panel3.TabIndex = 53;
            // 
            // Reviews
            // 
            Reviews.BackColor = Color.FromArgb(75, 54, 33);
            Reviews.FlatAppearance.BorderSize = 0;
            Reviews.FlatStyle = FlatStyle.Flat;
            Reviews.ForeColor = SystemColors.Info;
            Reviews.Location = new Point(1010, 13);
            Reviews.Name = "Reviews";
            Reviews.Size = new Size(147, 46);
            Reviews.TabIndex = 55;
            Reviews.Text = "REVIEWS";
            Reviews.UseVisualStyleBackColor = false;
            Reviews.Click += Reviews_Click;
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
            // btnhome
            // 
            btnhome.BackColor = Color.FromArgb(75, 54, 33);
            btnhome.FlatAppearance.BorderSize = 0;
            btnhome.FlatStyle = FlatStyle.Flat;
            btnhome.ForeColor = SystemColors.Info;
            btnhome.Location = new Point(552, 12);
            btnhome.Name = "btnhome";
            btnhome.Size = new Size(146, 47);
            btnhome.TabIndex = 46;
            btnhome.Text = "HOME";
            btnhome.UseVisualStyleBackColor = false;
            btnhome.Click += btnhome_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(75, 54, 33);
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.ForeColor = SystemColors.Info;
            btnProducts.Location = new Point(707, 12);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(146, 47);
            btnProducts.TabIndex = 45;
            btnProducts.Text = "PRODUCTS";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // cart
            // 
            cart.BackColor = Color.FromArgb(75, 54, 33);
            cart.FlatAppearance.BorderSize = 0;
            cart.FlatStyle = FlatStyle.Flat;
            cart.ForeColor = SystemColors.Info;
            cart.Location = new Point(857, 12);
            cart.Name = "cart";
            cart.Size = new Size(146, 47);
            cart.TabIndex = 47;
            cart.Text = "CART";
            cart.UseVisualStyleBackColor = false;
            cart.Click += cart_Click;
            // 
            // label7
            // 
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(292, 150);
            label7.Name = "label7";
            label7.Size = new Size(644, 54);
            label7.TabIndex = 65;
            label7.Text = "GCASH";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // amountToBePaid
            // 
            amountToBePaid.BackColor = SystemColors.ControlDark;
            amountToBePaid.FlatStyle = FlatStyle.System;
            amountToBePaid.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            amountToBePaid.Location = new Point(639, 228);
            amountToBePaid.Name = "amountToBePaid";
            amountToBePaid.Size = new Size(291, 43);
            amountToBePaid.TabIndex = 67;
            amountToBePaid.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(282, 228);
            label6.Name = "label6";
            label6.Size = new Size(370, 43);
            label6.TabIndex = 66;
            label6.Text = "TOTAL AMOUNT TO BE PAID:";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // name
            // 
            name.BorderStyle = BorderStyle.FixedSingle;
            name.Location = new Point(551, 291);
            name.Multiline = true;
            name.Name = "name";
            name.Size = new Size(391, 40);
            name.TabIndex = 69;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(298, 291);
            label3.Name = "label3";
            label3.Size = new Size(253, 40);
            label3.TabIndex = 68;
            label3.Text = "NAME";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // phoneNo
            // 
            phoneNo.BorderStyle = BorderStyle.FixedSingle;
            phoneNo.Location = new Point(551, 330);
            phoneNo.Multiline = true;
            phoneNo.Name = "phoneNo";
            phoneNo.Size = new Size(391, 40);
            phoneNo.TabIndex = 71;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(298, 330);
            label1.Name = "label1";
            label1.Size = new Size(253, 40);
            label1.TabIndex = 70;
            label1.Text = "PHONE NUMBER";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Amount
            // 
            Amount.BorderStyle = BorderStyle.FixedSingle;
            Amount.Location = new Point(551, 369);
            Amount.Multiline = true;
            Amount.Name = "Amount";
            Amount.Size = new Size(391, 40);
            Amount.TabIndex = 73;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(298, 369);
            label2.Name = "label2";
            label2.Size = new Size(253, 40);
            label2.TabIndex = 72;
            label2.Text = "AMOUNT";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // confirmPayment
            // 
            confirmPayment.BackColor = Color.SeaGreen;
            confirmPayment.BackgroundImageLayout = ImageLayout.None;
            confirmPayment.FlatStyle = FlatStyle.Flat;
            confirmPayment.ForeColor = SystemColors.ButtonFace;
            confirmPayment.Location = new Point(466, 471);
            confirmPayment.Name = "confirmPayment";
            confirmPayment.Size = new Size(299, 52);
            confirmPayment.TabIndex = 74;
            confirmPayment.Text = "CONFIRM PAYMENT";
            confirmPayment.UseVisualStyleBackColor = false;
            confirmPayment.Click += confirmPayment_Click;
            // 
            // User_Checkout_Ewallet
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 650);
            Controls.Add(confirmPayment);
            Controls.Add(Amount);
            Controls.Add(label2);
            Controls.Add(phoneNo);
            Controls.Add(label1);
            Controls.Add(name);
            Controls.Add(label3);
            Controls.Add(amountToBePaid);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(panel3);
            Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "User_Checkout_Ewallet";
            Text = "User_Checkout_Ewallet";
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private Button Reviews;
        private PictureBox pictureBox1;
        private Button btnMinimizeCustomers;
        private PictureBox pictureBox2;
        private Button btnhome;
        private Button btnProducts;
        private Button cart;
        private Label label7;
        private Label amountToBePaid;
        private Label label6;
        private TextBox name;
        private Label label3;
        private TextBox phoneNo;
        private Label label1;
        private TextBox Amount;
        private Label label2;
        private Button confirmPayment;
    }
}