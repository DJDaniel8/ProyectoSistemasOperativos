using ProyectoSistemasOperativos.Models;
using ProyectoSistemasOperativos.ViewModels;
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
    /// Lógica de interacción para TiempoRestanteMasCortoView.xaml
    /// </summary>
    public partial class TiempoRestanteMasCortoView : UserControl
    {
        public TiempoRestanteMasCortoView()
        {
            InitializeComponent();
            TiempoMasCortoRestante.canvas = MiCanvas;
            TiempoMasCortoRestante.clase = this;
            TiempoMasCortoRestante.miStackPanel = MistackPanel;
            TiempoMasCortoRestante.Titulos = Titulos;
            TiempoMasCortoRestante.ProcesosNombres = NombreProcesos;
            TiempoMasCortoRestante.canvas2 = MiCanvas2;

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
