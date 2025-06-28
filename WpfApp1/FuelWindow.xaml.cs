using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfApp1
{
    public partial class FuelWindow : Page
    {
        double paliwo, fuelmax;
        int money;

        public FuelWindow()
        {
            InitializeComponent();

            try
            {
                // Wczytanie danych z data.txt
                var lines = File.ReadLines("data.txt").ToList();
                paliwo = Convert.ToDouble(lines.Skip(9).First());      // 9: paliwo
                fuelmax = Convert.ToDouble(lines.Skip(14).First());    // 14: pojemność baku
                money = int.Parse(lines.Skip(16).First());             // 16: pieniądze

                fuelLabel.Content = $"Paliwo: {paliwo} / {fuelmax} L";
                moneyLabel.Content = $"Pieniądze: {money} zł";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas wczytywania danych: " + ex.Message);
                this.NavigationService?.GoBack();
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(fuelInput.Text, out double iloscLitrow) || iloscLitrow <= 0)
            {
                MessageBox.Show("Wprowadź poprawną, dodatnią liczbę litrów.");
                return;
            }

            double koszt = iloscLitrow * 5.19;

            if (paliwo + iloscLitrow > fuelmax)
            {
                MessageBox.Show($"Nie zmieści się tyle paliwa. Maksymalna pojemność baku to {fuelmax} L.");
                return;
            }

            if (money < koszt)
            {
                MessageBox.Show($"Masz za mało pieniędzy. Potrzebujesz {koszt:0.00} zł, a masz {money} zł.");
                return;
            }

            try
            {
                var lines = File.ReadAllLines("data.txt");
                paliwo += iloscLitrow;
                money -= (int)Math.Round(koszt);

                lines[9] = paliwo.ToString("0.00");     // aktualizacja paliwa
                lines[16] = money.ToString();           // aktualizacja pieniędzy

                File.WriteAllLines("data.txt", lines);

                MessageBox.Show("Paliwo zatankowane pomyślnie!");
                this.NavigationService?.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd zapisu do pliku: " + ex.Message);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.GoBack();
        }
    }
}