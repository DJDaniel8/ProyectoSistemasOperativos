using ProyectoSistemasOperativos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemasOperativos.Commands
{
    public class CalcularRondaCommand : CommandBase
    {
        private RondaViewModel _viewModel;
        public CalcularRondaCommand(RondaViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.LimpiarDatos();
            Models.Ronda.Resolver(_viewModel._Procesos.ToList());
            Models.Ronda.Dibujar(_viewModel._Procesos.ToList());
            _viewModel.CalcularPromedios();
        }
    }
}
