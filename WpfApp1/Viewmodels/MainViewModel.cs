using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;
using WpfApp1.Servicies;
using WpfApp1.Stores;

namespace WpfApp1.Viewmodels
{
   public class MainViewModel : ViewModelBase
    {
        private readonly NavigationService service;
        public ViewModelBase CurrentVM => service.CurrentViewModel;

        public MainViewModel(NavigationService service)
        {
            this.service = service;
            service.OnViewModelChanged += OnCurrentViewModelChanged;
        }

        public void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentVM));
        }
    }
}
