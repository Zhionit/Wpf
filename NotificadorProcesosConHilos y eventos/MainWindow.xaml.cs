using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace NotificadorProcesosConHilos_y_eventos
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Work work = new Work();
            work.working += new Work.work(notificar);

            Thread hilo = new Thread(work.trabajando);
            hilo.Start();
        }

        public void notificar(String notificarion)
        {
            // El CheckAccess Debería retornar verdadero, pero retorna un false
            if (!CheckAccess())
            {
                this.listBox1.Dispatcher.Invoke(new Action(() => listBox1.Items.Add(notificarion)));
                this.listBox1.Dispatcher.Invoke(new Action(() => listBox1.SelectedIndex = listBox1.Items.Count -1));
                this.listBox1.Dispatcher.Invoke(new Action(() => listBox1.SelectedItem = listBox1.Items.Count - 1));
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
