using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Viewmodels;

namespace WpfApp1.Servicies
{
    public class NavigationService
    {
        private Func<ViewModelBase> userListing;
        private Func<ViewModelBase> makeReservation;
        public ViewModelBase CurrentViewModel;
        public Func<ViewModelBase> UserListing { get { return userListing; } }
        public Func<ViewModelBase> MakeReservation { get { return makeReservation; } }

        public Action? OnViewModelChanged;

        private void ViewModelChanged()
        {
            OnViewModelChanged?.Invoke();
        }

        public NavigationService(Func<ViewModelBase> createUL,Func<ViewModelBase> createMR)
        {
          
            userListing = createUL;
            makeReservation = createMR;
        }

        public void UpdateCurrentViewModel(ViewModelBase vm)
        {
            CurrentViewModel = vm;
            ViewModelChanged();
        }
    }
}
