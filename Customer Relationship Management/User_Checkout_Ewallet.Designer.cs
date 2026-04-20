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
            Reviews = new Button();
            btnMinimizeCustomers = new Button();
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
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            button1 = new Button();
            button5 = new Button();
            button3 = new Button();
            btnLogout = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // Reviews
            // 
            Reviews.BackColor = Color.FromArgb(75, 54, 33);
            Reviews.FlatAppearance.BorderSize = 0;
            Reviews.FlatStyle = FlatStyle.Flat;
            Reviews.Font = new Font("Microsoft Sans Serif", 14F);
            Reviews.ForeColor = SystemColors.Info;
            Reviews.Location = new Point(1097, 46);
            Reviews.Name = "Reviews";
            Reviews.Size = new Size(151, 46);
            Reviews.TabIndex = 55;
            Reviews.Text = "REVIEWS";
            Reviews.UseVisualStyleBackColor = false;
            Reviews.Click += Reviews_Click;
            // 
            // btnMinimizeCustomers
            // 
            btnMinimizeCustomers.BackColor = Color.FromArgb(75, 54, 33);
            btnMinimizeCustomers.FlatAppearance.BorderSize = 0;
            btnMinimizeCustomers.FlatStyle = FlatStyle.Flat;
            btnMinimizeCustomers.Font = new Font("Microsoft Sans Serif", 14F);
            btnMinimizeCustomers.ForeColor = SystemColors.Info;
            btnMinimizeCustomers.Location = new Point(1248, 46);
            btnMinimizeCustomers.Name = "btnMinimizeCustomers";
            btnMinimizeCustomers.Size = new Size(148, 46);
            btnMinimizeCustomers.TabIndex = 29;
            btnMinimizeCustomers.Text = "LOGOUT";
            btnMinimizeCustomers.UseVisualStyleBackColor = false;
            // 
            // btnhome
            // 
            btnhome.BackColor = Color.FromArgb(75, 54, 33);
            btnhome.FlatAppearance.BorderSize = 0;
            btnhome.FlatStyle = FlatStyle.Flat;
            btnhome.Font = new Font("Microsoft Sans Serif", 14F);
            btnhome.ForeColor = SystemColors.Info;
            btnhome.Location = new Point(669, 46);
            btnhome.Name = "btnhome";
            btnhome.Size = new Size(115, 46);
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
            btnProducts.Font = new Font("Microsoft Sans Serif", 14F);
            btnProducts.ForeColor = SystemColors.Info;
            btnProducts.Location = new Point(784, 46);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(185, 46);
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
            cart.Font = new Font("Microsoft Sans Serif", 14F);
            cart.ForeColor = SystemColors.Info;
            cart.Location = new Point(969, 46);
            cart.Name = "cart";
            cart.Size = new Size(128, 46);
            cart.TabIndex = 47;
            cart.Text = "CART";
            cart.UseVisualStyleBackColor = false;
            cart.Click += cart_Click;
            // 
            // label7
            // 
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Impact", 36F);
            label7.Location = new Point(70, 214);
            label7.Name = "label7";
            label7.Size = new Size(1260, 107);
            label7.TabIndex = 65;
            label7.Text = "GCASH";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // amountToBePaid
            // 
            amountToBePaid.BackColor = SystemColors.ControlDark;
            amountToBePaid.FlatStyle = FlatStyle.System;
            amountToBePaid.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            amountToBePaid.Location = new Point(684, 362);
            amountToBePaid.Name = "amountToBePaid";
            amountToBePaid.Size = new Size(588, 86);
            amountToBePaid.TabIndex = 67;
            amountToBePaid.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Font = new Font("Impact", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(124, 362);
            label6.Name = "label6";
            label6.Size = new Size(554, 86);
            label6.TabIndex = 66;
            label6.Text = "TOTAL AMOUNT TO BE PAID:";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // name
            // 
            name.BorderStyle = BorderStyle.FixedSingle;
            name.Location = new Point(668, 503);
            name.Multiline = true;
            name.Name = "name";
            name.Size = new Size(604, 57);
            name.TabIndex = 69;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Verdana", 14F);
            label3.Location = new Point(124, 503);
            label3.Name = "label3";
            label3.Size = new Size(536, 57);
            label3.TabIndex = 68;
            label3.Text = "NAME";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // phoneNo
            // 
            phoneNo.BorderStyle = BorderStyle.FixedSingle;
            phoneNo.Location = new Point(668, 560);
            phoneNo.Multiline = true;
            phoneNo.Name = "phoneNo";
            phoneNo.Size = new Size(604, 57);
            phoneNo.TabIndex = 71;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Verdana", 14F);
            label1.Location = new Point(124, 560);
            label1.Name = "label1";
            label1.Size = new Size(536, 57);
            label1.TabIndex = 70;
            label1.Text = "PHONE NUMBER";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Amount
            // 
            Amount.BorderStyle = BorderStyle.FixedSingle;
            Amount.Location = new Point(668, 617);
            Amount.Multiline = true;
            Amount.Name = "Amount";
            Amount.Size = new Size(604, 57);
            Amount.TabIndex = 73;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Verdana", 14F);
            label2.Location = new Point(124, 617);
            label2.Name = "label2";
            label2.Size = new Size(536, 57);
            label2.TabIndex = 72;
            label2.Text = "AMOUNT";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // confirmPayment
            // 
            confirmPayment.BackColor = Color.SeaGreen;
            confirmPayment.BackgroundImageLayout = ImageLayout.None;
            confirmPayment.FlatStyle = FlatStyle.Flat;
            confirmPayment.Font = new Font("Verdana", 18F);
            confirmPayment.ForeColor = SystemColors.ButtonFace;
            confirmPayment.Location = new Point(428, 726);
            confirmPayment.Name = "confirmPayment";
            confirmPayment.Size = new Size(540, 94);
            confirmPayment.TabIndex = 74;
            confirmPayment.Text = "CONFIRM PAYMENT";
            confirmPayment.UseVisualStyleBackColor = false;
            confirmPayment.Click += confirmPayment_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(75, 54, 33);
            panel1.Controls.Add(Reviews);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(btnMinimizeCustomers);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(btnhome);
            panel1.Controls.Add(cart);
            panel1.Controls.Add(btnProducts);
            panel1.Location = new Point(-1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1468, 137);
            panel1.TabIndex = 75;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.None;
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(161, 9);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(500, 119);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 51;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.None;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(12, -6);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(143, 150);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 56;
            pictureBox4.TabStop = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.FromArgb(75, 54, 33);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Verdana", 14F);
            button1.ForeColor = SystemColors.Info;
            button1.Location = new Point(1394, 65);
            button1.Name = "button1";
            button1.Size = new Size(194, 47);
            button1.TabIndex = 45;
            button1.Text = "PRODUCTS";
            button1.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.None;
            button5.BackColor = Color.FromArgb(75, 54, 33);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Verdana", 14F);
            button5.ForeColor = SystemColors.Info;
            button5.Location = new Point(1725, 65);
            button5.Name = "button5";
            button5.Size = new Size(186, 47);
            button5.TabIndex = 55;
            button5.Text = "REVIEWS";
            button5.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.BackColor = Color.FromArgb(75, 54, 33);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Verdana", 14F);
            button3.ForeColor = SystemColors.Info;
            button3.Location = new Point(1588, 65);
            button3.Name = "button3";
            button3.Size = new Size(137, 47);
            button3.TabIndex = 47;
            button3.Text = "CART";
            button3.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.None;
            btnLogout.BackColor = Color.FromArgb(75, 54, 33);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Verdana", 14F);
            btnLogout.ForeColor = SystemColors.Info;
            btnLogout.Location = new Point(1911, 65);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(153, 47);
            btnLogout.TabIndex = 29;
            btnLogout.Text = "LOGOUT";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // User_Checkout_Ewallet
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1408, 914);
            Controls.Add(panel1);
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
            Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "User_Checkout_Ewallet";
            Text = "User_Checkout_Ewallet";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Reviews;
        private Button btnMinimizeCustomers;
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
        private Panel panel1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Button button1;
        private Button button5;
        private Button button3;
        private Button btnLogout;
    }
}