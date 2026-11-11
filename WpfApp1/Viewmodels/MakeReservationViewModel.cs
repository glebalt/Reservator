using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Servicies;
using WpfApp1.Stores;

namespace WpfApp1.Viewmodels
{
    public class MakeReservationViewModel : ViewModelBase
    {

        public MakeReservationViewModel(Hotel hotel,NavigationService service)
        {
            SubmitCommand = new MakeReservationCommand(hotel,this,service);
            CancelCommand = new CancelCommand(service);
            TestAsyncCommand = new TestAsyncCommand();
            StartDate = new DateTime(2026, 10, 1);
            EndDate = new DateTime(2026, 10, 1);
        }

        private string _username;
        public string Username
        {
            get{ return _username; }

            set 
            { 
                if(value.Length > 10)
                {
                    return;
                }
                _username = value;
                OnPropertyChanged(nameof(Username));
            } 
        }

        private int _roomNum;
   
        public int RoomNumber{ 
            get { return _roomNum; }
            set {
                _roomNum = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }
        private int _floorNum;
        public int FloorNumber { 
            get {return _floorNum; }
            set { _floorNum = value;
                OnPropertyChanged(nameof(FloorNumber));    
            } 
        }
        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime _endDate;

     
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public ICommand TestAsyncCommand { get; }
        
    }
}
