using System;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy TrainWindow.xaml
    /// </summary>
    public partial class TrainWindow : Page
    {
        public TrainWindow()
        {
            InitializeComponent();
        }

        private void strenght_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new Uri("PrefightWindow.xaml", UriKind.RelativeOrAbsolute));
        }

        private void business_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new Uri("RunningWindow.xaml", UriKind.RelativeOrAbsolute));
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}