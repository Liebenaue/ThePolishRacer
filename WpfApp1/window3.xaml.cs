using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class window3 : Page
    {
        public window3()
        {
            InitializeComponent();

            try
            {
                // Odczyt danych z pliku
                string[] lines = File.ReadAllLines("data.txt");

                // Parsowanie danych
                string name = lines[0];
                int clan = int.Parse(lines[1]);
                int carType = int.Parse(lines[2]);
                double strength = double.Parse(lines[3]);
                double maxhp = Math.Round(double.Parse(lines[4]), 0);
                double resistance = double.Parse(lines[5]);
                double run = double.Parse(lines[6]);
                double vmax = double.Parse(lines[7]);
                double baseMass = double.Parse(lines[8]);
                double fuelMass = double.Parse(lines[9]);
                double totalMass = double.Parse(lines[10]);
                double age = double.Parse(lines[11]);
                double ageDays = double.Parse(lines[12]);
                double ahp = Math.Round(double.Parse(lines[13]), 0);
                double fuelMax = double.Parse(lines[14]);
                string carModel = lines[15];
                int money = int.Parse(lines[16]);

                // Tworzenie stringów typu "ahp/maxhp" i "fuelMass/fuelMax"
                string hpString = $"{ahp}/{maxhp}";
                string fuelString = $"{fuelMass}/{fuelMax}";
                string massString = $"{totalMass}/{baseMass}";

                // Przypisanie do kontrolek
                charName.Text = name;
                carName.Text = carModel;
                charAge.Text = age.ToString("0");
                charAgeDays.Text = ageDays.ToString("0");
                charStrength.Text = strength.ToString("0");
                charHP.Text = hpString;
                charRes.Text = resistance.ToString("0");
                charRun.Text = run.ToString("0.000");
                charSpeed.Text = vmax.ToString("0.000");
                charMass.Text = massString;
                carFuelMass.Text = fuelString;
                charMoney.Text = money.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd odczytu danych:\n{ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void charName_Loaded(object sender, RoutedEventArgs e)
        {
            // już przypisane w konstruktorze
        }

        private void carName_Loaded(object sender, RoutedEventArgs e)
        {
            // już przypisane w konstruktorze
        }
    }
}