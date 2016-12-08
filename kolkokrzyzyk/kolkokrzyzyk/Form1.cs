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
        System.Media.SoundPlayer buttonsound = new System.Media.SoundPlayer();
        System.Media.SoundPlayer owacja = new System.Media.SoundPlayer();
        System.Media.SoundPlayer boo = new System.Media.SoundPlayer();              // odtwarzacze dźwięku
        System.Media.SoundPlayer remis = new System.Media.SoundPlayer();
        bool ruch = true;               // kiedy true, ruch pierwszego ( X ) ;; kiedy false drugiego ( O )
        int zliczRuchy = 0;
        public static bool nakomputer = false;
        static String gracz1, gracz2;

        public Form1()  // inicjacja formy pierwszej
        {
            InitializeComponent();
            buttonsound.SoundLocation = "Button.wav";
            owacja.SoundLocation = "owacja.wav";
            boo.SoundLocation = "boo.wav";
            remis.SoundLocation = "remis.wav";
        }

        public static void podajImieGracza(string g1, string g2) // przypisanie nazw graczom
        {
            gracz1 = g1;
            gracz2 = g2;
        }
        private void Form1_Load(object sender, EventArgs e) // wywołanie okna wybierającego tryb rozgrywki
        {                                                   // oraz imiona graczy
            Form f2 = new Form2();
            f2.ShowDialog();
            winX.Text = gracz1;
            winO.Text = gracz2;
        }

        private void oAplikacjiToolStripMenuItem_Click(object sender, EventArgs e)  // opcja "O aplikacji" w zakładce "Pomoc"
        {
            MessageBox.Show("By Joanna Łukasiak & Piotr Kuśmierczyk", "O aplikacji");
        }

        private void wyjdźToolStripMenuItem_Click(object sender, EventArgs e) // opcja "Wyjdź w zakładce "Plik"
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)  
        {                                                     
            Button b = (Button)sender;
            if (ruch)                   // tworzenie zmiennej "ruch" która decyduje czy ruch jest X lub O;
            b.Text = "X";
            else
                b.Text = "O";
            buttonsound.Play();
            ruch = !ruch;
            b.Enabled = false;          // jednorazowa możliwość wciśnięcia przycisku na planszy
            zliczRuchy++;               // zliczanie ruchów
            wygrana();                  // użycie funkcji , która sprawdza czy warunek wygranej został spełniony


            if ((!ruch) && nakomputer)      
            {
                komputerruch();         // jeżeli wybraliśmy opcję "Gra przeciw SI" w pierwszym oknie, 
            }                           // inicjowana jest funkcja zawierająca podstawowe zasady działania komputerowego przeciwnika
        }
        private void komputerruch()
        {
            Button ruch = null;                 // przypisanie komputerowi znaku "O" ;; kolejne etapy algorytmu SI
            ruch = szukajlubblokuj("O");        // szukanie potrójnego O, dążenie do wygranej
            if (ruch == null)
            {
                ruch = szukajlubblokuj("X");    // blokowanie
                if (ruch == null)
                {                               
                    ruch = szukajrogu();        // szukanie rogu
                    if (ruch == null)
                    {
                        ruch = szukajmiejsca(); // szukanie jakiegokolwiek miejsca
                    }
                }
            }
            if (zliczRuchy != 9)
            {
                ruch.PerformClick();            // komputer wykonuje ruchy dopóki plansza nie jest pełna
            }
        }
        private Button szukajlubblokuj(string znak)
        {
            Console.WriteLine("Szukam lub blokuję:  " + znak);

            // testy poziome 

            if ((A1.Text == znak) && (A2.Text == znak) && (A3.Text == ""))              // sprawdza poziomo czy w wierszu jest puste miejsce
                return A3;                                                              // próbuje wygrać, a jeśli mamy 2 znaki "X" we wierszu
            if ((A2.Text == znak) && (A3.Text == znak) && (A1.Text == ""))              // blokuje
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

            // testy pionowe


            if ((A1.Text == znak) && (B1.Text == znak) && (C1.Text == ""))          // sprawdza pionowo czy w wierszu jest puste miejsce 
                return C1;                                                          // próbuje wygrać, a jeśli mamy 2 znaki "X" w kolumnie 
            if ((B1.Text == znak) && (C1.Text == znak) && (A1.Text == ""))          // blokuje
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

            // testy ukośne

            if ((A1.Text == znak) && (B2.Text == znak) && (C3.Text == ""))         // sprawdza poziomo czy po ukosie jest puste miejsce 
                return C3;                                                         // próbuje wygrać, a jeśli mamy 2 znaki "X"  
            if ((B2.Text == znak) && (C3.Text == znak) && (A1.Text == ""))         // blokuje
                return A1;
            if ((A3.Text == znak) && (C1.Text == znak) && (B2.Text == ""))
                return B2;

            if ((A3.Text == znak) && (B2.Text == znak) && (C1.Text == ""))
                return C1;
            if ((B2.Text == znak) && (C3.Text == znak) && (A1.Text == ""))
                return A1;
            if ((A3.Text == znak) && (C1.Text == znak) && (B2.Text == ""))
                return B2;

            
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
                if (A1.Text == "")                  // bazowo komputer szuka miejsca dla siebie w rogu planszy
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
            foreach (Control c in Controls)         // komputer w ostateczności zajmuje dowolne puste pole
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
        private void wygrana()    // warunek wygranej
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
                wylaczGuzik();         // wyłączanie przycisku po wygranej
                String winner = "";         // tworzenie zmiennej przechowującej imie zwycięzcy
                if (ruch == true)
                {
                    winner = gracz2;
                    O_licznik.Text = (int.Parse(O_licznik.Text) + 1).ToString();        // zwiekszenie licznika po zwycięstwie gracz2
                }
                else
                {
                    winner = gracz1;
                    X_licznik.Text = (int.Parse(X_licznik.Text) + 1).ToString();        // zwiekszenie licznika po zwycięstwie gracz 1
                }
                if (winner != "Komputer")
                {
                    owacja.Play();
                    MessageBox.Show("Wygrywa " + winner + "!", "Gratulacje!");      // komunikat po wygranej
                }
                else
                {
                    boo.Play();
                    MessageBox.Show( winner + " zwyciężył. Spróbuj jeszcze raz!", "Porażka!");   // komunikat po wygranej komputera
                }
                  
                

                ruch = true;            // zawartość funkcji nowaGraToolStripMenuItem_Click() , resetuje plansze po zwycięstwie
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
                    remis.Play();
                    MessageBox.Show("REMIS!", "Remis");
                    remis_licznik.Text = (int.Parse(remis_licznik.Text) + 1).ToString();        // zwiększa licznik remisów przy zapełnionej pełnej planszy

                    ruch = true;                // zawartość funkcji nowaGraToolStripMenuItem_Click() , resetuje plansze po remisie
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
        private void wylaczGuzik()          // funkcja wyłącza przycisk po jego użyciu
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
            ruch = true;            // oddaje kontrolę pierwszemu graczowi (X)
            zliczRuchy = 0;         // resetuje licznik ruchów

                foreach (Control c in Controls)          
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;           // uaktywnia przyciski   
                        b.Text = "";                // i usuwa umieszczone na nich znaki
                    }
                    catch { }
                }
        }

        private void button_enter(object sender, EventArgs e)       // pokazuje na najechaniu myszą na pole,
        {                                                           // znak gracza którego jest teraz kolej
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
        private void button_leave(object sender, EventArgs e)      // gdy "zdejmiemy" kursor z przycisku 
        {                                                          // znak znika
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

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resetLicznikówToolStripMenuItem_Click(object sender, EventArgs e)      // opcja "Reset Liczników" w zakładce "Plik"
        {                                                                                   // zeruje liczniki
            O_licznik.Text = "0";
            X_licznik.Text = "0";
            remis_licznik.Text = "0";
        }
    }
}


