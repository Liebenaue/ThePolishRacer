using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Page
    {
        public GameWindow() // Okno główne gry + wyświetlanie daty
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            double d, ms, rok;

            // Odczyt daty z pliku
            d = Convert.ToDouble(File.ReadLines("kalendarz.txt").First());
            ms = Convert.ToDouble(File.ReadLines("kalendarz.txt").Skip(1).Take(1).First());
            rok = Convert.ToDouble(File.ReadLines("kalendarz.txt").Skip(2).Take(1).First());

            // Wyświetlanie daty
            if ((d < 10) && (ms < 10))
            {
                string strd = d.ToString();
                string strms = ms.ToString();
                string strrok = rok.ToString();
                string dateString = "0" + strd + "/0" + strms + "/" + strrok;
                calendar.Text = dateString;
            }
            if ((d < 10) && (ms >= 10))
            {
                string strd = d.ToString();
                string strms = ms.ToString();
                string strrok = rok.ToString();
                string dateString = "0" + strd + "/" + strms + "/" + strrok;
                calendar.Text = dateString;
            }
            if ((d >= 10) && (ms < 10))
            {
                string strd = d.ToString();
                string strms = ms.ToString();
                string strrok = rok.ToString();
                string dateString = strd + "/0" + strms + "/" + strrok;
                calendar.Text = dateString;
            }
            if ((d >= 10) && (ms >= 10))
            {
                string strd = d.ToString();
                string strms = ms.ToString();
                string strrok = rok.ToString();
                string dateString = strd + "/" + strms + "/" + strrok;
                calendar.Text = dateString;
            }
        }

        // public double runs = 0; // flaga dziennego grania w Snake (nieużywana)

        private void comp_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("PrecompWindow.xaml", UriKind.RelativeOrAbsolute));
        }

        private void stat_Click(object sender, RoutedEventArgs e) // Funkcja pokazująca statystyki
        {
            this.NavigationService.Navigate(new Uri("window3.xaml", UriKind.RelativeOrAbsolute));
        }

        public void train_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("TrainWindow.xaml", UriKind.RelativeOrAbsolute));
        }

        public void nextday_Click(object sender, RoutedEventArgs e) // Zakończenie dnia, odświeżenie okna i aktualizacja danych
        {
            double d, ms, rok;
            string i;
            int clan, car, money;
            double s, maxhp, res, run, vmax, basem, paliwo, m, a, ad, ahp, fuelmax;
            string cari;

            // Odczyt daty
            d = Convert.ToDouble(File.ReadLines("kalendarz.txt").First());
            ms = Convert.ToDouble(File.ReadLines("kalendarz.txt").Skip(1).Take(1).First());
            rok = Convert.ToDouble(File.ReadLines("kalendarz.txt").Skip(2).Take(1).First());

            // Odczyt statów
            i = File.ReadLines("data.txt").First();                                     // 0: nazwa
            clan = int.Parse(File.ReadLines("data.txt").Skip(1).Take(1).First());       // 1: frakcja
            car = int.Parse(File.ReadLines("data.txt").Skip(2).Take(1).First());        // 2: typ auta
            s = Convert.ToDouble(File.ReadLines("data.txt").Skip(3).Take(1).First());   // 3: siła
            maxhp = Convert.ToDouble(File.ReadLines("data.txt").Skip(4).Take(1).First());// 4: max HP
            res = Convert.ToDouble(File.ReadLines("data.txt").Skip(5).Take(1).First()); // 5: opór
            run = Convert.ToDouble(File.ReadLines("data.txt").Skip(6).Take(1).First()); // 6: bieg
            vmax = Convert.ToDouble(File.ReadLines("data.txt").Skip(7).Take(1).First());// 7: prędkość
            basem = Convert.ToDouble(File.ReadLines("data.txt").Skip(8).Take(1).First());// 8: masa bazowa
            paliwo = Convert.ToDouble(File.ReadLines("data.txt").Skip(9).Take(1).First());// 9: paliwo
            m = Convert.ToDouble(File.ReadLines("data.txt").Skip(10).Take(1).First());  // 10: masa całk.
            a = Convert.ToDouble(File.ReadLines("data.txt").Skip(11).Take(1).First());  // 11: wiek
            ad = Convert.ToDouble(File.ReadLines("data.txt").Skip(12).Take(1).First()); // 12: dni po ur.
            ahp = Convert.ToDouble(File.ReadLines("data.txt").Skip(13).Take(1).First());// 13: aktualne HP
            fuelmax = Convert.ToDouble(File.ReadLines("data.txt").Skip(14).Take(1).First());// 14: poj. baku
            cari = File.ReadLines("data.txt").Skip(15).Take(1).First();                 // 15: nazwa auta
            money = int.Parse(File.ReadLines("data.txt").Skip(16).Take(1).First());     // 16: pieniądze

            // Przykład: codzienna zmiana paliwa lub pieniędzy (do przyszłego zaimplementowania)
            // paliwo = Math.Max(0, paliwo - new Random().Next(1, 5));
            // money += new Random().Next(50, 100);

            // Aktualizacja dnia i wieku
            d++;
            ad++;

            if (((ms == 1) || (ms == 3) || (ms == 5) || (ms == 7) || (ms == 8) || (ms == 10) || (ms == 12)) && (d > 31))
            {
                d -= 31;
                ms++;
            }
            if (((ms == 4) || (ms == 6) || (ms == 9) || (ms == 11)) && (d > 30))
            {
                d -= 30;
                ms++;
            }
            if ((ms == 2) && (d > 28))
            {
                d -= 28;
                ms++;
            }
            if (ms > 12)
            {
                ms = 1;
                d = 1;
                rok++;
            }
            if (ad == 365)
            {
                ad -= 365;
                a++;
            }

            // Leczenie HP
            if (ahp < maxhp)
                ahp += 100;
            if (ahp > maxhp)
                ahp = maxhp;

            // Zapis kalendarza
            using (StreamWriter sr = new StreamWriter("kalendarz.txt"))
            {
                sr.WriteLine(d);
                sr.WriteLine(ms);
                sr.WriteLine(rok);
            }

            // Zapis statów
            using (StreamWriter sr = new StreamWriter("data.txt"))
            {
                sr.WriteLine(i);        // 0
                sr.WriteLine(clan);     // 1
                sr.WriteLine(car);      // 2
                sr.WriteLine(s);        // 3
                sr.WriteLine(maxhp);    // 4
                sr.WriteLine(res);      // 5
                sr.WriteLine(run);      // 6
                sr.WriteLine(vmax);     // 7
                sr.WriteLine(basem);    // 8
                sr.WriteLine(paliwo);   // 9
                sr.WriteLine(m);        // 10
                sr.WriteLine(a);        // 11
                sr.WriteLine(ad);       // 12
                sr.WriteLine(ahp);      // 13
                sr.WriteLine(fuelmax);  // 14
                sr.WriteLine(cari);     // 15
                sr.WriteLine(money);    // 16
            }

            // (Reset dziennych flag do wykorzystania w przyszłości)

            // Odświeżenie
            init();
        }

        private void back_Click(object sender, RoutedEventArgs e) // Funkcja cofająca do menu głównego
        {
            // (zapisywanie dziennych flag pominiete)
            this.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
