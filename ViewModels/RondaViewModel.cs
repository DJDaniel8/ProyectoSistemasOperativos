using ProyectoSistemasOperativos.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace ProyectoSistemasOperativos.ViewModels
{
    public class RondaViewModel : ViewModelBase
    {
        public RondaViewModel()
        {
            _Procesos = new();
            CalcularRondaCommand = new CalcularRondaCommand(this);
            Canvas = new Canvas();
        }

        public Canvas Canvas { get; set; }

        public ObservableCollection<ProcesoViewModel> _Procesos { get; set; }
        public IEnumerable<ProcesoViewModel> Procesos => _Procesos;

        public ICommand CalcularRondaCommand { get; set; }

        private Visibility _ControlVisibility = Visibility.Collapsed;
        public Visibility ControlVisibility
        {
            get
            {
                return _ControlVisibility;
            }
            set
            {
                _ControlVisibility = value;
                OnPropertyChanged(nameof(ControlVisibility));
            }
        }

        private int _NumeroProcesos;
        public int NumeroProcesos
        {
            get
            {
                return _NumeroProcesos;
            }
            set
            {
                if (value > 10)
                {
                    MessageBox.Show("No se permite Mas de 10 Procesos");
                }
                else _NumeroProcesos = value;
                AgregarProcesos();
                OnPropertyChanged(nameof(NumeroProcesos));
            }
        }

        private decimal _RetornoPromedio;
        public decimal RetornoPromedio
        {
            get
            {
                return _RetornoPromedio;
            }
            set
            {
                _RetornoPromedio = value;
                OnPropertyChanged(nameof(RetornoPromedio));
            }
        }

        private decimal _EsperaPromedio;
        public decimal EsperaPromedio
        {
            get
            {
                return _EsperaPromedio;
            }
            set
            {
                _EsperaPromedio = value;
                OnPropertyChanged(nameof(EsperaPromedio));
            }
        }

        private decimal _PromedioPromedio;
        public decimal PromedioPromedio
        {
            get
            {
                return _PromedioPromedio;
            }
            set
            {
                _PromedioPromedio = value;
                OnPropertyChanged(nameof(PromedioPromedio));
            }
        }

        public void AgregarProcesos()
        {
            char letra = 'A';
            _Procesos.Clear();
            for (int i = 0; i < NumeroProcesos; i++)
            {
                ProcesoViewModel p = new();
                p.Nombre = letra.ToString();
                _Procesos.Add(p);
                letra++;
            }
        }

        public void CalcularPromedios()
        {
            decimal retorno = 0;
            decimal Espera = 0;
            decimal promedio = 0;
            foreach (var item in _Procesos)
            {
                retorno += item.TiempoRetorno;
                Espera += item.TiempoEspera;
                promedio += item.TiempoPromedio;
            }

            RetornoPromedio = retorno / _Procesos.Count;
            EsperaPromedio = Espera / _Procesos.Count;
            PromedioPromedio = promedio / _Procesos.Count;
        }

        public void LimpiarDatos()
        {
            foreach (var item in _Procesos)
            {
                item.TiempoFinal = 0;
                item.TiempoRetorno = 0;
                item.TiempoEspera = 0;
                item.TiempoPromedio = 0;
                item.TiempoCPU = item.TiempoCPU;
                item.TiemposEjecucion.Clear();
            }
        }
    }
}
