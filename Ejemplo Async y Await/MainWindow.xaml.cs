using System;
using System.Collections;
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

namespace Ejemplo_Async_y_Await
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            btnArchivos.IsEnabled = false;
            listaDeArchivos.ItemsSource = await ObtenerArchivosAsync();
            btnArchivos.IsEnabled = true;
        }

        private Task<IEnumerable<String>> ObtenerArchivosAsync()
        {
            return Task.Run(() =>
            {
                var archivos = from archivo in System.IO.Directory.GetFiles(@"C:\Windows\System32") select archivo;
                System.Threading.Thread.Sleep(5000);
                return archivos;
            });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("La hora es: " + DateTime.Now.ToLongDateString());
        }
    }
}
