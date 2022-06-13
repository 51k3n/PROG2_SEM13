using ClassLibrary;
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
    /// Lógica de interacción para FrmUsuarios.xaml
    /// </summary>
    public partial class FrmUsuarios : Window
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Random CodAleatorio = new Random();
            TxtCodigo.Text = Convert.ToString(CodAleatorio.Next(1000));

            GbxUsuarios.IsEnabled = true;
            BtnGuardar.IsEnabled = true;
            BtnNuevo.IsEnabled = false;

            CmbCargo.ItemsSource = Enum.GetValues(typeof(Cargo));
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtNombre.Text.Length < 1
                || TxtApellidos.Text.Length < 1
                || CmbCargo.SelectedIndex < 0
                || TxtCorreo.Text.Length < 1
                || TxtDireccion.Text.Length < 1
                || (RbtnHombre.IsChecked == false && RbtnMujer.IsChecked == false))
            {
                MessageBox.Show("Obligatorio Ingresar Placa", "Informacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                CUsuario usuario = new CUsuario();
                usuario.Nombre = TxtNombre.Text.ToUpper().Trim();
                usuario.Apellido = TxtApellidos.Text.ToUpper().Trim();
                usuario.Cargo = (Cargo)CmbCargo.SelectedIndex;
                usuario.Correo = TxtCorreo.Text.ToUpper().Trim();
                usuario.Direccion = TxtDireccion.Text.ToUpper().Trim();

                int numero = 0;
                Int32.TryParse(TxtCodigo.Text, out numero);
                usuario.Codigo = numero;

                Array.Resize(ref usuarios, usuarios.Length + 1);
                usuarios[usuarios.Length - 1] = usuario;
                DgUsuarios.ItemsSource = usuarios;
                DgUsuarios.Items.Refresh();

                TxtCodigo.Clear();
                TxtNombre.Clear();
                TxtApellidos.Clear();
                CmbCargo.SelectedIndex = 0;
                TxtCorreo.Clear();
                TxtDireccion.Clear();
                GbxUsuarios.IsEnabled = false;
                BtnGuardar.IsEnabled = false;
                BtnNuevo.IsEnabled = true;
            }
        }
        CUsuario[] usuarios = new CUsuario[0];
    }
}
