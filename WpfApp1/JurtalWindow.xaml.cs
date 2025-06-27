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
    /// Logika interakcji dla klasy JurtalWindow.xaml
    /// </summary>
    public partial class JurtalWindow : Page
    {
        public JurtalWindow()
        {
            InitializeComponent();
        }

        public double action;

        private void Enemy1_Click(object sender, RoutedEventArgs e)
        {
            action = 1;
            this.NavigationService.Navigate(new Uri("DuelWindow.xaml", UriKind.RelativeOrAbsolute));
            using (StreamWriter sr = new StreamWriter("action.txt"))
            {
                sr.WriteLine(action);
            }
        }

        private void Enemy2_Click(object sender, RoutedEventArgs e)
        {
            action = 2;
            this.NavigationService.Navigate(new Uri("DuelWindow.xaml", UriKind.RelativeOrAbsolute));
            using (StreamWriter sr = new StreamWriter("action.txt"))
            {
                sr.WriteLine(action);
            }
        }

        private void Enemy3_Click(object sender, RoutedEventArgs e)
        {
            action = 3;
            this.NavigationService.Navigate(new Uri("DuelWindow.xaml", UriKind.RelativeOrAbsolute));
            using (StreamWriter sr = new StreamWriter("action.txt"))
            {
                sr.WriteLine(action);
            }
        }

        private void Enemy4_Click(object sender, RoutedEventArgs e)
        {
            action = 4;
            this.NavigationService.Navigate(new Uri("DuelWindow.xaml", UriKind.RelativeOrAbsolute));
            using (StreamWriter sr = new StreamWriter("action.txt"))
            {
                sr.WriteLine(action);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
