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

namespace PROG2_SEM13
{
    /// <summary>
    /// Lógica de interacción para FrmMenu.xaml
    /// </summary>
    public partial class FrmMenu : Window
    {
        public FrmMenu()
        {
            InitializeComponent();
            LblHoraFecha.Content = DateTime.Now.ToLongDateString();
        }

        private void BtnBoletos_Click(object sender, RoutedEventArgs e)
        {
            FrPantalla.Content = new FrmBoletos();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            FrPantalla.Content = new FrmBDirectorio();
        }

        private void BtnDesconectar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnBuses_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnAyuda_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
