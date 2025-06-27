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
    /// Logika interakcji dla klasy DuelWindow.xaml
    /// </summary>
    public partial class DuelWindow : Page
    {
        public DuelWindow()
        {
            InitializeComponent();
            //cnter - grubość, s - sila, m-masa, res-opór
            double wzr, cnter, maxhp, res, s, run, vmax, bmi, m, fat, bfat, skeletm, skinm, musclem, a, ad, ahp;

            //Zmienne na staty przeciwnika
            double ea, ewzr, emaxhp, em, es, eres, evmax, eahp;

            action = Convert.ToDouble(File.ReadLines("action.txt").First());

            //Odczyt statów przeciwnika z pliku
            if (action==1)
            {
                string ei = File.ReadLines("enemy1.txt").First();
                charName2.Text = ei;
                ea = Convert.ToDouble(File.ReadLines("enemy1.txt").Skip(1).Take(1).First());
                ewzr = Convert.ToDouble(File.ReadLines("enemy1.txt").Skip(2).Take(1).First());
                emaxhp = Math.Round(Convert.ToDouble(File.ReadLines("enemy1.txt").Skip(3).Take(1).First()), 0);
                em = Convert.ToDouble(File.ReadLines("enemy1.txt").Skip(4).Take(1).First());
                es = Convert.ToDouble(File.ReadLines("enemy1.txt").Skip(5).Take(1).First());
                eres = Convert.ToDouble(File.ReadLines("enemy1.txt").Skip(6).Take(1).First());
                evmax = Convert.ToDouble(File.ReadLines("enemy1.txt").Skip(7).Take(1).First());
                eahp = emaxhp;

                string stremaxhp = emaxhp.ToString();
                string streahp = eahp.ToString();

                string ehpString = streahp + "/" + stremaxhp;
                charHP2.Text = ehpString;

                //Wyświetlenie statystyk przeciwnika w boxach//
                charAge2.Text = Math.Round(double.Parse(File.ReadLines("enemy1.txt").Skip(1).Take(1).First()), 0).ToString();
                charHeight2.Text = Math.Round(double.Parse(File.ReadLines("enemy1.txt").Skip(2).Take(1).First()), 0).ToString();
                charMass2.Text = Math.Round(double.Parse(File.ReadLines("enemy1.txt").Skip(4).Take(1).First()), 3).ToString();
                charStrength2.Text = Math.Round(double.Parse(File.ReadLines("enemy1.txt").Skip(5).Take(1).First()), 0).ToString();
                charRes2.Text = Math.Round(double.Parse(File.ReadLines("enemy1.txt").Skip(6).Take(1).First()), 0).ToString();
            }
            if (action == 2)
            {
                string ei = File.ReadLines("enemy2.txt").First();
                charName2.Text = ei;
                ea = Convert.ToDouble(File.ReadLines("enemy2.txt").Skip(1).Take(1).First());
                ewzr = Convert.ToDouble(File.ReadLines("enemy2.txt").Skip(2).Take(1).First());
                emaxhp = Math.Round(Convert.ToDouble(File.ReadLines("enemy2.txt").Skip(3).Take(1).First()), 0);
                em = Convert.ToDouble(File.ReadLines("enemy2.txt").Skip(4).Take(1).First());
                es = Convert.ToDouble(File.ReadLines("enemy2.txt").Skip(5).Take(1).First());
                eres = Convert.ToDouble(File.ReadLines("enemy2.txt").Skip(6).Take(1).First());
                evmax = Convert.ToDouble(File.ReadLines("enemy2.txt").Skip(7).Take(1).First());
                eahp = emaxhp;

                string stremaxhp = emaxhp.ToString();
                string streahp = eahp.ToString();

                string ehpString = streahp + "/" + stremaxhp;
                charHP2.Text = ehpString;

                //Wyświetlenie statystyk przeciwnika w boxach//
                charAge2.Text = Math.Round(double.Parse(File.ReadLines("enemy2.txt").Skip(1).Take(1).First()), 0).ToString();
                charHeight2.Text = Math.Round(double.Parse(File.ReadLines("enemy2.txt").Skip(2).Take(1).First()), 0).ToString();
                charMass2.Text = Math.Round(double.Parse(File.ReadLines("enemy2.txt").Skip(4).Take(1).First()), 3).ToString();
                charStrength2.Text = Math.Round(double.Parse(File.ReadLines("enemy2.txt").Skip(5).Take(1).First()), 0).ToString();
                charRes2.Text = Math.Round(double.Parse(File.ReadLines("enemy2.txt").Skip(6).Take(1).First()), 0).ToString();
            }
            if (action == 3)
            {
                string ei = File.ReadLines("enemy3.txt").First();
                charName2.Text = ei;
                ea = Convert.ToDouble(File.ReadLines("enemy3.txt").Skip(1).Take(1).First());
                ewzr = Convert.ToDouble(File.ReadLines("enemy3.txt").Skip(2).Take(1).First());
                emaxhp = Math.Round(Convert.ToDouble(File.ReadLines("enemy3.txt").Skip(3).Take(1).First()), 0);
                em = Convert.ToDouble(File.ReadLines("enemy3.txt").Skip(4).Take(1).First());
                es = Convert.ToDouble(File.ReadLines("enemy3.txt").Skip(5).Take(1).First());
                eres = Convert.ToDouble(File.ReadLines("enemy3.txt").Skip(6).Take(1).First());
                evmax = Convert.ToDouble(File.ReadLines("enemy3.txt").Skip(7).Take(1).First());
                eahp = emaxhp;

                string stremaxhp = emaxhp.ToString();
                string streahp = eahp.ToString();

                string ehpString = streahp + "/" + stremaxhp;
                charHP2.Text = ehpString;

                //Wyświetlenie statystyk przeciwnika w boxach//
                charAge2.Text = Math.Round(double.Parse(File.ReadLines("enemy3.txt").Skip(1).Take(1).First()), 0).ToString();
                charHeight2.Text = Math.Round(double.Parse(File.ReadLines("enemy3.txt").Skip(2).Take(1).First()), 0).ToString();
                charMass2.Text = Math.Round(double.Parse(File.ReadLines("enemy3.txt").Skip(4).Take(1).First()), 3).ToString();
                charStrength2.Text = Math.Round(double.Parse(File.ReadLines("enemy3.txt").Skip(5).Take(1).First()), 0).ToString();
                charRes2.Text = Math.Round(double.Parse(File.ReadLines("enemy3.txt").Skip(6).Take(1).First()), 0).ToString();
            }
            if (action == 4)
            {
                string ei = File.ReadLines("enemy4.txt").First();
                charName2.Text = ei;
                ea = Convert.ToDouble(File.ReadLines("enemy4.txt").Skip(1).Take(1).First());
                ewzr = Convert.ToDouble(File.ReadLines("enemy4.txt").Skip(2).Take(1).First());
                emaxhp = Math.Round(Convert.ToDouble(File.ReadLines("enemy4.txt").Skip(3).Take(1).First()), 0);
                em = Convert.ToDouble(File.ReadLines("enemy4.txt").Skip(4).Take(1).First());
                es = Convert.ToDouble(File.ReadLines("enemy4.txt").Skip(5).Take(1).First());
                eres = Convert.ToDouble(File.ReadLines("enemy4.txt").Skip(6).Take(1).First());
                evmax = Convert.ToDouble(File.ReadLines("enemy4.txt").Skip(7).Take(1).First());
                eahp = emaxhp;

                string stremaxhp = emaxhp.ToString();
                string streahp = eahp.ToString();

                string ehpString = streahp + "/" + stremaxhp;
                charHP2.Text = ehpString;

                //Wyświetlenie statystyk przeciwnika w boxach//
                charAge2.Text = Math.Round(double.Parse(File.ReadLines("enemy4.txt").Skip(1).Take(1).First()), 0).ToString();
                charHeight2.Text = Math.Round(double.Parse(File.ReadLines("enemy4.txt").Skip(2).Take(1).First()), 0).ToString();
                charMass2.Text = Math.Round(double.Parse(File.ReadLines("enemy4.txt").Skip(4).Take(1).First()), 3).ToString();
                charStrength2.Text = Math.Round(double.Parse(File.ReadLines("enemy4.txt").Skip(5).Take(1).First()), 0).ToString();
                charRes2.Text = Math.Round(double.Parse(File.ReadLines("enemy4.txt").Skip(6).Take(1).First()), 0).ToString();
            }   

            //Odczyt Statystyk Postaci z pliku//
            wzr = Convert.ToDouble(File.ReadLines("data.txt").Skip(1).Take(1).First());
            cnter = Convert.ToDouble(File.ReadLines("data.txt").Skip(2).Take(1).First());
            s = Convert.ToDouble(File.ReadLines("data.txt").Skip(3).Take(1).First());
            maxhp = Math.Round(Convert.ToDouble(File.ReadLines("data.txt").Skip(4).Take(1).First()), 0);
            res = Convert.ToDouble(File.ReadLines("data.txt").Skip(5).Take(1).First());
            run = Convert.ToDouble(File.ReadLines("data.txt").Skip(6).Take(1).First());
            vmax = Convert.ToDouble(File.ReadLines("data.txt").Skip(7).Take(1).First());
            bmi = Convert.ToDouble(File.ReadLines("data.txt").Skip(8).Take(1).First());
            m = Convert.ToDouble(File.ReadLines("data.txt").Skip(9).Take(1).First());
            skeletm = Convert.ToDouble(File.ReadLines("data.txt").Skip(10).Take(1).First());
            skinm = Convert.ToDouble(File.ReadLines("data.txt").Skip(11).Take(1).First());
            musclem = Convert.ToDouble(File.ReadLines("data.txt").Skip(12).Take(1).First());
            fat = Convert.ToDouble(File.ReadLines("data.txt").Skip(13).Take(1).First());
            bfat = Convert.ToDouble(File.ReadLines("data.txt").Skip(14).Take(1).First());
            a = Convert.ToDouble(File.ReadLines("data.txt").Skip(15).Take(1).First());
            ad = Convert.ToDouble(File.ReadLines("data.txt").Skip(16).Take(1).First());
            ahp = Math.Round(Convert.ToDouble(File.ReadLines("data.txt").Skip(17).Take(1).First()), 0);

            string strmaxhp = maxhp.ToString();
            string strahp = ahp.ToString();

            string hpString = strahp + "/" + strmaxhp;

            string i = File.ReadLines("data.txt").First();
            charName.Text = i;

            //Wyświetlenie statystyk postaci w boxach//
            charHeight.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(1).Take(1).First()), 0).ToString();
            charStrength.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(3).Take(1).First()), 0).ToString();
            charHP.Text = hpString;
            charRes.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(5).Take(1).First()), 0).ToString();
            charMass.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(9).Take(1).First()), 3).ToString();
            charAge.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(15).Take(1).First()), 0).ToString();
        }

        public double action;

        private void punch_Click(object sender, RoutedEventArgs e)
        {
            double premultiple;
            double dmg;

            Random random = new Random();
            premultiple = random.Next(50);

            dmg = premultiple+75;

            Random random2 = new Random();
            premultiple = random.Next(50);

            dmg = premultiple + 75;
        }

        private void push_Click(object sender, RoutedEventArgs e)
        {

        }

        private void retreat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
