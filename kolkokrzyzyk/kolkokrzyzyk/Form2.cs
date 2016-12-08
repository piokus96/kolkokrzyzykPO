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

        private void g2_TextChanged(object sender, EventArgs e)     // jeżeli nazwa drugiego gracza brzmi "komputer"
        {                                                           // uruchamia grę przeciwko SI
            if (g2.Text.ToUpper() == "KOMPUTER")
                Form1.nakomputer = true;
            else
                Form1.nakomputer = false;
        }

        private void button1_Click(object sender, EventArgs e)      // przypisuje graczom podane imiona i zamyka pierwsze okno
        {
            Form1.podajImieGracza(g1.Text,g2.Text);
            this.Close();
        }

        private void g2_KeyPress(object sender, KeyPressEventArgs e)    // pozwala po wpisaniu imienia drugiego gracza zatwierdzić
        {                                                               // swój wybór klawiszem "Enter"
            if (e.KeyChar.ToString() == "\r")
                button1.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)          // po kliknięciu przycisku "Gra przeciwko SI"
        {                                                               // nadaje imię "komputer" graczowi2 czym uruchamia grę przeciw komputerowi
            g2.Text = "Komputer";
            Form1.podajImieGracza(g1.Text, g2.Text);                    // zczytuje oba imiona aby je wyświetlić w oknie gry
            this.Close();                                               // zamyka pierwsze okno
        }

        private void g1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
