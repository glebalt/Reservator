using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Viewmodels;

namespace WpfApp1.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentVM;
        public ViewModelBase CurrentVM { get 
            { return _currentVM; }

            set { 
                _currentVM = value;
                ViewModelChanged();
            }
        }

        public Action? OnViewModelChanged;

        private void ViewModelChanged()
        {
            OnViewModelChanged?.Invoke();
        }
    }
}
