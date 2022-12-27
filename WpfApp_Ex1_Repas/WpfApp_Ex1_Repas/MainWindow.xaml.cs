using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp_Ex1_Repas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static SoundPlayer simpleSound = new SoundPlayer();
        public static List<string> musiques = new List<String>();
        public static List<string> imatges = new List<String>();
        public static int cansoReproduintse = 0;
        public static string path = @"C:\Users\iferr\source\repos\WpfApp_Ex1_Repas\WpfApp_Ex1_Repas\Music";/* @"..\..\Music\"*/
        public string imatgesd = "pack://application:,,,/Images/cargando.png";
        public static bool directoriBuit = true;
        public static bool cambiDirectori;
        public MainWindow()
        {
            busquedaMusica();
            InitializeComponent();
            if (directoriBuit == true)
            {
                contenidorImatge.Source = new BitmapImage(new Uri(imatgesd));
            }
        }
        public static void busquedaMusica()
        {

            if (Directory.Exists(path))
            {
                if (cambiDirectori==true) { imatges.Clear(); musiques.Clear(); cansoReproduintse = 0; cambiDirectori=false; Debug.WriteLine(musiques.Count); }
                imatges = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".png") || s.EndsWith(".jpg")).ToList<string>();
                musiques = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".wav") || s.EndsWith(".mp3")).ToList<string>();
            }
            else{directoriBuit = true;} 

            if (musiques.Count == 0) { directoriBuit = true; }
            else { directoriBuit = false; }
        }
        private void Button_Hover(object sender, RoutedEventArgs e)
        {

            if (simpleSound.IsLoadCompleted == false)
            {
                simpleSound.SoundLocation = musiques[cansoReproduintse];
                textBoxNomCanso.Text = musiques[cansoReproduintse].Split('\\').ToList<string>().Last<string>();
                contenidorImatge.Source = new BitmapImage(new Uri(imatges[cansoReproduintse]));
            }
            simpleSound.Play();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (directoriBuit == false)
            {
                simpleSound.SoundLocation = musiques[cansoReproduintse];
                textBoxNomCanso.Text = musiques[cansoReproduintse].Split('\\').ToList<string>().Last<string>();
                contenidorImatge.Source = new BitmapImage(new Uri(imatges[cansoReproduintse]));

                simpleSound.Play();
            }
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            simpleSound.Play();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            simpleSound.Stop();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            cansoReproduintse++;
            if (cansoReproduintse >= musiques.Count)
            {
                cansoReproduintse = 0;
            }
            textBoxNomCanso.Text = musiques[cansoReproduintse].Split('\\').ToList<string>().Last<string>();
            simpleSound.SoundLocation = musiques[cansoReproduintse];
            contenidorImatge.Source = new BitmapImage(new Uri(imatges[cansoReproduintse]));
            simpleSound.Play();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            cansoReproduintse--;
            textBoxNomCanso.Text = musiques[cansoReproduintse].Split('\\').ToList<string>().Last<string>();
            simpleSound.SoundLocation = musiques[cansoReproduintse];
            contenidorImatge.Source = new BitmapImage(new Uri(imatges[cansoReproduintse]));
            simpleSound.Play();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            WindowAjustes ventanaAjustes = new WindowAjustes();
            ventanaAjustes.TextboxPath.Text = path;
            ventanaAjustes.Show();
        }
    }
}
