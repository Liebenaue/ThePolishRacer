using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.InteropServices;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy window2.xaml
    /// </summary>
    public partial class window2 : Page
    {
        public window2()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            string i, cari;
            int a, ad, car, clan, money;
            double maxhp, s, run, vmax, basem, paliwo, m, fuelmax, ahp, res;
            double d, ms, rok;

            d = 12;
            ms = 7;
            rok = 2024;

            money = 50; // startowa ilość pieniędzy

            i = Convert.ToString(charName.Text);
            clan = Convert.ToInt32(charClan.Text);
            car = Convert.ToInt32(charCar.Text);

            if (car == 1 && clan >= 1 && clan <= 3)
            {
                // Przeliczenie statystyk
                s = 115;
                run = s * s;
                basem = 1300;
                paliwo = 53;
                m = basem + paliwo;
                fuelmax = 60;
                vmax = run / m * 18.7;
                res = m / 100 * s;
                maxhp = basem / 1.5;
                a = 18;
                ad = 0;
                ahp = maxhp;
                cari = "Kia Ceed";

                // Zapis do pliku
                using (StreamWriter sr = new StreamWriter("data.txt"))
                {
                    sr.WriteLine(i);        // 0: nazwa
                    sr.WriteLine(clan);     // 1: frakcja
                    sr.WriteLine(car);      // 2: typ samochodu
                    sr.WriteLine(s);        // 3: siła
                    sr.WriteLine(maxhp);    // 4: max HP
                    sr.WriteLine(res);      // 5: opór
                    sr.WriteLine(run);      // 6: zdolności biegowe
                    sr.WriteLine(vmax);     // 7: prędkość maks.
                    sr.WriteLine(basem);    // 8: masa bazowa
                    sr.WriteLine(paliwo);   // 9: masa paliwa
                    sr.WriteLine(m);        // 10: masa całkowita
                    sr.WriteLine(a);        // 11: wiek
                    sr.WriteLine(ad);       // 12: dni
                    sr.WriteLine(ahp);      // 13: aktualne HP
                    sr.WriteLine(fuelmax);  // 14: pojemność baku
                    sr.WriteLine(cari);     // 15: nazwa auta
                    sr.WriteLine(money);    // 16: pieniądze
                }

                using (StreamWriter sr = new StreamWriter("kalendarz.txt"))
                {
                    sr.WriteLine(d);
                    sr.WriteLine(ms);
                    sr.WriteLine(rok);
                }

                this.NavigationService.Navigate(new Uri("GameWindow.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("Wprowadzono nieprawidłowe dane.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
