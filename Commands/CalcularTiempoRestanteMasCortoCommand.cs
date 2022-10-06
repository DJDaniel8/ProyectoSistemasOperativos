using ProyectoSistemasOperativos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemasOperativos.Commands
{
    public class CalcularTiempoRestanteMasCortoCommand : CommandBase
    {
        private TiempoRestanteMasCortoViewModel _viewModel;
        public CalcularTiempoRestanteMasCortoCommand(TiempoRestanteMasCortoViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.LimpiarDatos();
            Models.TiempoMasCortoRestante.Resolver(_viewModel._Procesos.ToList());
            Models.TiempoMasCortoRestante.Dibujar(_viewModel._Procesos.ToList());
            _viewModel.CalcularPromedios();
        }
    }
}
