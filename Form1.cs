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
    public partial class Form1 : Form
    {
        bool ruch = true; // kiedy true, ruch pierwszego ( X ) ;; kiedy false drugiego ( O )
        int zliczRuchy = 0;
        public static bool nakomputer = false;
        static String gracz1, gracz2;

        public Form1()
        {
            InitializeComponent();
        }

        public static void podajImieGracza(string g1, string g2)
        {
            gracz1 = g1;
            gracz2 = g2;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.ShowDialog();
            winX.Text = gracz1;
            winO.Text = gracz2;

        }

        private void oAplikacjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Joanna Łukasiak & Piotr Kuśmierczyk", "O aplikacji");
        }

        private void wyjdźToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (ruch)
                b.Text = "X";
            else
                b.Text = "O";

            ruch = !ruch;
            b.Enabled = false;
            zliczRuchy++;
            wygrana();


            if ((!ruch) && nakomputer)
            {
                komputerruch();
            }
        }
        private void komputerruch()
        {
            Button ruch = null;
            ruch = szukajlubblokuj("O");
            if (ruch == null)
            {
                ruch = szukajlubblokuj("X");
                if (ruch == null)
                {
                    ruch = szukajrogu();
                    if (ruch == null)
                    {
                        ruch = szukajmiejsca();
                    }
                }
            }
            if (zliczRuchy != 9)
            {
                ruch.PerformClick();
            }
        }
        private Button szukajlubblokuj(string znak)
        {
            Console.WriteLine("Szukam lub blokuję:  " + znak);
            if ((A1.Text == znak) && (A2.Text == znak) && (A3.Text == ""))
                return A3;
            if ((A2.Text == znak) && (A3.Text == znak) && (A1.Text == ""))
                return A1;
            if ((A1.Text == znak) && (A3.Text == znak) && (A2.Text == ""))
                return A2;

            if ((B1.Text == znak) && (B2.Text == znak) && (B3.Text == ""))
                return B3;
            if ((B2.Text == znak) && (B3.Text == znak) && (B1.Text == ""))
                return B1;
            if ((B1.Text == znak) && (B3.Text == znak) && (B2.Text == ""))
                return B2;

            if ((C1.Text == znak) && (C2.Text == znak) && (C3.Text == ""))
                return C3;
            if ((C2.Text == znak) && (C3.Text == znak) && (C1.Text == ""))
                return C1;
            if ((C1.Text == znak) && (C3.Text == znak) && (C2.Text == ""))
                return C2;

            // testy poziome 


            if ((A1.Text == znak) && (B1.Text == znak) && (C1.Text == ""))
                return C1;
            if ((B1.Text == znak) && (C1.Text == znak) && (A1.Text == ""))
                return A1;
            if ((A1.Text == znak) && (C1.Text == znak) && (B1.Text == ""))
                return B1;

            if ((A2.Text == znak) && (B2.Text == znak) && (C2.Text == ""))
                return C2;
            if ((B2.Text == znak) && (C2.Text == znak) && (A2.Text == ""))
                return A2;
            if ((A2.Text == znak) && (C2.Text == znak) && (B2.Text == ""))
                return B2;

            if ((A3.Text == znak) && (B3.Text == znak) && (C3.Text == ""))
                return C3;
            if ((B3.Text == znak) && (C3.Text == znak) && (A3.Text == ""))
                return A3;
            if ((A3.Text == znak) && (C3.Text == znak) && (B3.Text == ""))
                return B3;

            // testy pionowe

            if ((A1.Text == znak) && (B2.Text == znak) && (C3.Text == ""))
                return C3;
            if ((B2.Text == znak) && (C3.Text == znak) && (A1.Text == ""))
                return A1;
            if ((A3.Text == znak) && (C1.Text == znak) && (B2.Text == ""))
                return B2;

            if ((A3.Text == znak) && (B2.Text == znak) && (C1.Text == ""))
                return C1;
            if ((B2.Text == znak) && (C3.Text == znak) && (A1.Text == ""))
                return A1;
            if ((A3.Text == znak) && (C1.Text == znak) && (B2.Text == ""))
                return B2;

            // testy ukośne
            return null;
        }
        private Button szukajrogu()
        {
            Console.WriteLine("Szukam rogu...");
            if (A1.Text == "0")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }
            if (A3.Text == "0")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }
            if (C1.Text == "0")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (A3.Text == "")
                    return A3;
            }
            if (C3.Text == "0")
            {
                if (A1.Text == "")
                    return A1;
                if (C1.Text == "")
                    return C1;
                if (A3.Text == "")
                    return A3;
            }
            return null;
        }
        private Button szukajmiejsca()
        {
            Console.WriteLine("Szukam miejsca...");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if(b!=null)
                {
                    if (b.Text == "")
                        return b;
                }

            }
            return null;
        }
        private void wygrana()
        {
            // sprawdza poziomo
            bool mamyzwyciezce = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                mamyzwyciezce = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                mamyzwyciezce = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                mamyzwyciezce = true;

            // sprawdza na ukos
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                mamyzwyciezce = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                mamyzwyciezce = true;


            // sprawdza pionowo
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                mamyzwyciezce = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                mamyzwyciezce = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                mamyzwyciezce = true;


            if (mamyzwyciezce == true)
            {
                wylaczGuzik();
                String winner = "";
                if (ruch == true)
                {
                    winner = gracz2;
                    O_licznik.Text = (int.Parse(O_licznik.Text) + 1).ToString();
                }
                else
                {
                    winner = gracz1;
                    X_licznik.Text = (int.Parse(X_licznik.Text) + 1).ToString();
                } 
                MessageBox.Show("Wygrywa " + winner, "Gratulacje!");

                // nowa gra
                ruch = true;
                zliczRuchy = 0;

                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }
                    catch { }
                }


            }
            else
            {
                if (zliczRuchy == 9)
                {
                    MessageBox.Show("REMIS!", "Remis");
                    remis_licznik.Text = (int.Parse(remis_licznik.Text) + 1).ToString();

                    ruch = true;
                    zliczRuchy = 0;

                    foreach (Control c in Controls)
                    {
                        try
                        {
                            Button b = (Button)c;
                            b.Enabled = true;
                            b.Text = "";
                        }
                        catch { }
                    }
                }
            }
        }
        private void wylaczGuzik()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        public void nowaGraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ruch = true;
            zliczRuchy = 0;

                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }
                    catch { }
                }
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {

                if (ruch)
                {
                    b.Text = "X";
                }
                else
                {
                    b.Text = "O";
                }
            }
        }
        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(b.Enabled)
            {
                b.Text = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void X_licznik_Click(object sender, EventArgs e)
        {

        }

        private void resetLicznikówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            O_licznik.Text = "0";
            X_licznik.Text = "0";
            remis_licznik.Text = "0";
        }
    }
}


