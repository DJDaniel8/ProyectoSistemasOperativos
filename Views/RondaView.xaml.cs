using ProyectoSistemasOperativos.Models;
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

namespace ProyectoSistemasOperativos.Views
{
    /// <summary>
    /// Lógica de interacción para RondaView.xaml
    /// </summary>
    public partial class RondaView : UserControl
    {
        public RondaView()
        {
            InitializeComponent();
            Ronda.canvas = MiCanvas;
            Ronda.clase = this;
            Ronda.miStackPanel = MistackPanel;
            Ronda.Titulos = Titulos;
            Ronda.ProcesosNombres = NombreProcesos;
            Ronda.canvas2 = MiCanvas2;
        }

        public void AgregarRectangulo(Rectangle r)
        {
            MiCanvas.Children.Add(r);
        }

        public void AgregarRectangulo2(Rectangle r)
        {
            MiCanvas2.Children.Add(r);
        }
    }
}
