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
using System.IO;

namespace PROG2_SEM13
{
    /// <summary>
    /// Lógica de interacción para FrmBDirectorio.xaml
    /// </summary>
    public partial class FrmBDirectorio : Page
    {
        public FrmBDirectorio()
        {
            InitializeComponent();

        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                string nombreArchivo;
                nombreArchivo = TxtBuscar.Text;

                if (File.Exists(nombreArchivo))
                {
                    TxtMostrar.Text = ObtenerInformacion(nombreArchivo);

                    try
                    {
                        StreamReader flujo = new StreamReader(nombreArchivo);
                        TxtMostrar.Text += flujo.ReadToEnd();
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error al leer del archivo", "Error de archivo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (Directory.Exists(nombreArchivo))
                {
                    string[] listaDirectorios;

                    TxtMostrar.Text = ObtenerInformacion(nombreArchivo);
                    listaDirectorios = Directory.GetDirectories(nombreArchivo);
                    TxtMostrar.Text += "\r\n\r\nContenido del directorio:\r\n";
                    for (int i = 0; i < listaDirectorios.Length; i++)
                    {
                        TxtMostrar.Text += listaDirectorios[i] + "\r\n";
                    }
                }
                else
                {
                    MessageBox.Show(TxtBuscar.Text + " No existe", "Error de archivo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private string ObtenerInformacion( string nombreArchivo )
        {
            return nombreArchivo + " existe\r\n\r\nCreacion: " + File.GetCreationTime(nombreArchivo)
                + "\r\nUltima modificacion: " + File.GetLastWriteTime(nombreArchivo) +
                "\r\nUltimo acceso: " + File.GetLastAccessTime(nombreArchivo) + "\r\n\r\n";
        }
    }
}
