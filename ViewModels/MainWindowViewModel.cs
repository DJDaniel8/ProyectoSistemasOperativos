using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSistemasOperativos.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            informacionViewModel = new();
            TiempoRestanteMasCorto = new();
			RondaViewModel = new();
        }

        public InformacionViewModel informacionViewModel { get; set; }
        public TiempoRestanteMasCortoViewModel TiempoRestanteMasCorto { get; set; }
		public RondaViewModel RondaViewModel { get; set; }

		private bool _InformacionChecked = true;
		public bool InformacionChecked
		{
			get
			{
				return _InformacionChecked;
			}
			set
			{
				_InformacionChecked = value;
				if(value) informacionViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else informacionViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(InformacionChecked));
			}
		}

		private bool _TiempoMasCortoChecked;
		public bool TiempoMasCortoCHecked
		{
			get
			{
				return _TiempoMasCortoChecked;
			}
			set
			{
				_TiempoMasCortoChecked = value;
                if (value) TiempoRestanteMasCorto.ControlVisibility = System.Windows.Visibility.Visible;
                else TiempoRestanteMasCorto.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(TiempoMasCortoCHecked));
			}
		}

		private bool _RondaChecked;
		public bool RondaChecked
		{
			get
			{
				return _RondaChecked;
			}
			set
			{
				_RondaChecked = value;
                if (value) RondaViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else RondaViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(RondaChecked));
			}
		}
	}
}
