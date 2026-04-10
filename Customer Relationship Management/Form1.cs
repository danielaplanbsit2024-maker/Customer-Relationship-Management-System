using System;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // placeholder
        }

        private void label11_Click(object sender, EventArgs e)
        {
            // placeholder
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Start button behavior: open Dashboard
            var dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
