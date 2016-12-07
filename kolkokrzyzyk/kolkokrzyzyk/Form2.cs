using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kolkokrzyzyk
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void g2_TextChanged(object sender, EventArgs e)
        {
            if (g2.Text.ToUpper() == "KOMPUTER")
                Form1.nakomputer = true;
            else
                Form1.nakomputer = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.podajImieGracza(g1.Text,g2.Text);
            this.Close();
        }

        private void g2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
                button1.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g2.Text = "Komputer";
            Form1.podajImieGracza(g1.Text, g2.Text);
            this.Close();
        }

        private void g1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
