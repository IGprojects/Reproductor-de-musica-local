using System.Windows;

namespace WpfApp_Ex1_Repas
{
    /// <summary>
    /// Lógica de interacción para WindowAjustes.xaml
    /// </summary>
    public partial class WindowAjustes : Window
    {
        public WindowAjustes()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.path = TextboxPath.Text;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.musiques.Clear();
            MainWindow.imatges.Clear();
            MainWindow.simpleSound.Stop();
            MainWindow.simpleSound.Dispose();
            MainWindow.cambiDirectori = true;
            MainWindow.busquedaMusica();
            this.Close();
        }
    }
}
