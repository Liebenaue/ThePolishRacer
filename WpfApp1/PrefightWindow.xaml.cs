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
    /// Logika interakcji dla klasy PrefightWindow.xaml
    /// </summary>
    public partial class PrefightWindow : Page
    {
        public PrefightWindow()
        {
            InitializeComponent();
        }

        private void yurtal_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("JurtalWindow.xaml", UriKind.RelativeOrAbsolute));

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

    }
}
