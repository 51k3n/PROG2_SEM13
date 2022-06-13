using System;
using System.Collections.Generic;
using ClassLibrary;
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

namespace PROG2_SEM13
{
    /// <summary>
    /// Lógica de interacción para FrmBoletos.xaml
    /// </summary>
    public partial class FrmBoletos : Page
    {
        public FrmBoletos()
        {
            InitializeComponent();
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Random CodAleatorio = new Random();
            TxtCodigo.Text = Convert.ToString(CodAleatorio.Next(1000));

            GbxBoletos.IsEnabled = true;
            BtnRegistrar.IsEnabled = true;
            BtnNuevo.IsEnabled = false;
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtPlaca.Text.Length < 1)
            {
                MessageBox.Show("Obligatorio Ingresar Placa", "Informacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (CmbDestino.SelectedIndex < 0)
            {
                MessageBox.Show("Obligatorio Destino", "Informacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (CmbOrigen.SelectedIndex < 0)
            {
                MessageBox.Show("Obligatorio Origen", "Informacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                CBoletos boleto = new CBoletos();
                boleto.Femision = DpFEmision.SelectedDate.Value.ToShortDateString();
                boleto.Fviaje = DpFViaje.SelectedDate.Value.ToShortDateString();
                boleto.Placa = TxtPlaca.Text.ToUpper().Trim();
                boleto.Origen = (CParametros.Lugares) CmbOrigen.SelectedIndex;
                boleto.Destino = (CParametros.Lugares) CmbDestino.SelectedIndex;
                boleto.Conductor = TxtConductor.Text.ToUpper().Trim();
                boleto.Hviaje = TxtHora.Text.ToUpper().Trim();
                boleto.Asientos = TxtAsiento.Text.ToUpper().Trim();

                int numero = 0;
                Int32.TryParse(TxtCodigo.Text, out numero);
                boleto.Codigo = numero;

                Array.Resize(ref boletos, boletos.Length + 1);
                boletos[boletos.Length - 1] = boleto;
                DgBoletos.ItemsSource = boletos;
                DgBoletos.Items.Refresh();

                TxtCodigo.Clear();
                TxtPlaca.Clear();
                CmbDestino.SelectedIndex = 0;
                CmbOrigen.SelectedIndex = 0;
                DpFViaje.Text = DateTime.Now.ToShortDateString();
                DpFEmision.Text = DateTime.Now.ToShortDateString();
                TxtConductor.Clear();
                TxtHora.Clear();
                TxtAsiento.Clear();
                GbxBoletos.IsEnabled = false;
                BtnRegistrar.IsEnabled = false;
                BtnNuevo.IsEnabled = true;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CmbOrigen.ItemsSource = Enum.GetValues(typeof(CParametros.Lugares));
            CmbDestino.ItemsSource = Enum.GetValues(typeof(CParametros.Lugares));
        }

        CBoletos[] boletos = new CBoletos[0];
    }
}
