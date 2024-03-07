﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Notatka> Notatki { get; set; }
        public int NumerNotatki { get; set; } = 0;
        public MainWindow()
        {
            InitializeComponent();
            Notatki = new ObservableCollection<Notatka>();
            /*Notatki.Add(new Notatka("Przygotowania", "Muszę się nauczyć apliakcji desktopowych"));
            Notatki.Add(new Notatka("Przygotowania dalej", "Muszę się nauczyć apliakcji mobilnych"));
            Notatki.Add(new Notatka("Przygotowania najważniejsze", "Muszę się nauczyć apliakcji konsolowej!!!!"));
           */
            odczytNotatek();
            WyswietlNotatke(0);
        }
        private void odczytNotatek()
        {
            StreamReader sr = new StreamReader("notatki.txt");
            string tytul = "";
            string tresc = "";
            while (tytul != null)
            {
                tytul = sr.ReadLine();
                tresc = sr.ReadLine();
                if (tytul != null)
                {
                    Notatki.Add(new Notatka(tytul, tresc));
                }
            }
            sr.Close();
        }

        private void WyswietlNotatke(int i)
        {
            tytul_text_block.Text = Notatki[i].Tytul;
            tresc_text_block.Text = Notatki[i].Tresc;
        }

        private void Button_Dalej_Click(object sender, RoutedEventArgs e)
        {
            NumerNotatki++;
            if(NumerNotatki>=Notatki.Count)
            {
                MessageBox.Show("Nie ma kolejnych notatek");
                NumerNotatki=Notatki.Count-1;
            }
            WyswietlNotatke(NumerNotatki);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NumerNotatki--;
            if(NumerNotatki<0)
            {
                MessageBox.Show("Nie ma wczesniejszych notatek");
                NumerNotatki = 0;

            }
            WyswietlNotatke(NumerNotatki);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string tytulNotatki = tytul_text_box.Text;
            string trescNotatki = tresc_text_box.Text;
            Notatki.Add(new Notatka(tytulNotatki, trescNotatki));
            StreamWriter sw = new StreamWriter("notatki.txt",append:true);
            sw.WriteLine(tytulNotatki);
            sw.WriteLine(trescNotatki);
            sw.Close();
        }
    }
}
