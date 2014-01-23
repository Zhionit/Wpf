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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;

namespace Ajuste_de_brillo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MiModel myModel = new MiModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = myModel;
            //myModel.ValorSlider = MSMonitorClass
        }

        private void cambioBrillo()
        {
            System.Management.ManagementClass mclass = new ManagementClass("WmiMonitorBrightnessMethods");
            mclass.Scope = new ManagementScope(@"\\.\root\wmi");
            ManagementObjectCollection instances = mclass.GetInstances();
 
            foreach (ManagementObject instance in instances)
            {
                ulong timeout = 1; // en segundos
                ushort brightness = (ushort) myModel.ValorSlider; // en porcentaje
                object[] args = new object[] { timeout, brightness };
                instance.InvokeMethod("WmiSetBrightness", args);
            }            
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            cambioBrillo();
        }
    }
}
