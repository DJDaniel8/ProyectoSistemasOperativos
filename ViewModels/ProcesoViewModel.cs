using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProyectoSistemasOperativos.ViewModels
{
    public class ProcesoViewModel : ViewModelBase
    {
		private string _Nombre = string.Empty;
		public string Nombre
		{
			get
			{
				return _Nombre;
			}
			set
			{
				_Nombre = value;
				OnPropertyChanged(nameof(Nombre));
			}
		}

		private int _TiempoLlegada;
		public int TiempoLlegada
		{
			get
			{
				return _TiempoLlegada;
			}
			set
			{
				if(value >= 0 && value <= 20)
				{
                    _TiempoLlegada = value;
                }
				
				OnPropertyChanged(nameof(TiempoLlegada));
			}
		}

		private int _TiempoCPU = 1;
		public int TiempoCPU
		{
			get
			{
				return _TiempoCPU;
			}
			set
			{
				if(value > 0 && value <= 20)
				{
                    _TiempoCPU = value;
                    TiempoCPURestante = value;
                }
				OnPropertyChanged(nameof(TiempoCPU));
			}
		}

		private int _TiempoFinal;
		public int TiempoFinal
		{
			get
			{
				return _TiempoFinal;
			}
			set
			{
				_TiempoFinal = value;
				TiempoRetorno = value - TiempoLlegada;
				OnPropertyChanged(nameof(TiempoFinal));
			}
		}

		private int _TiempoRetorno;
		public int TiempoRetorno
		{
			get
			{
				return _TiempoRetorno;
			}
			set
			{
				_TiempoRetorno = value;
				TiempoEspera = value - TiempoCPU;
				TiempoPromedio = ((decimal)value)/ ((decimal)TiempoCPU);
				OnPropertyChanged(nameof(TiempoRetorno));
			}
		}

		private int _TiempoEspera;
		public int TiempoEspera
		{
			get
			{
				return _TiempoEspera;
			}
			set
			{
				_TiempoEspera = value;
				OnPropertyChanged(nameof(TiempoEspera));
			}
		}

		private decimal _TiempoPromedio;
		public decimal TiempoPromedio
		{
			get
			{
				return _TiempoPromedio;
			}
			set
			{
				_TiempoPromedio = value;
				OnPropertyChanged(nameof(TiempoPromedio));
			}
		}

		private int _TiempoCPURestante;
		public int TiempoCPURestante
		{
			get
			{
				return _TiempoCPURestante;
			}
			set
			{
				_TiempoCPURestante = value;
				OnPropertyChanged(nameof(TiempoCPURestante));
			}
		}

		private Color _ColorFondo;
		public Color ColorFondo
		{
			get
			{
				return _ColorFondo;
			}
			set
			{
				_ColorFondo = value;
				OnPropertyChanged(nameof(ColorFondo));
			}
		}

		public List<int> TiemposEjecucion { get; set; } = new();
	}
}
