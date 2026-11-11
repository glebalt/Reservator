using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp1.DbContextss;
using WpfApp1.Models;
using WpfApp1.Servicies;
using WpfApp1.Servicies.ReservationConflictValidators;
using WpfApp1.Servicies.ReservationCreators;
using WpfApp1.Servicies.ReservationsProviders;
using WpfApp1.Stores;
using WpfApp1.Viewmodels;
using WpfApp1.Views;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;
        private HotelContainer HotelContainer;
        private NavigationService service;
        private const string CONNECTION_STRING = "Data Source=reservator.db";
        ReservatorDbContextFactory factory;
        public App()
        {
            factory = new(CONNECTION_STRING);

            IReservationCreator reservationCreator = new ReservationCreator(factory);
            IReservationProvider reservationProvider = new DatabaseReservationProvider(factory);
            IReservationConflictValidator reservationValidator = new DatabaseReservationConflictValidator(factory);


            service = new NavigationService(CreateReservationListing,CreateMakeReservation);
            ReservationBook book = new ReservationBook(reservationCreator, reservationProvider, reservationValidator);
            _hotel = new Hotel("Glebob",book);
            HotelContainer = new(_hotel);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            
            using (ReservatorDbContext dbContext = factory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }
          
        

            _navigationStore.CurrentVM = service.MakeReservation();
            MainViewModel md = new(service);
          
           MainWindow = new MainWindow { DataContext = md};

            //ReservationListingViewModel mdd = (ReservationListingViewModel)md.CurrentVM;
            MakeReservationViewModel mdd = (MakeReservationViewModel)md.CurrentVM;
            //  mdd.FloorNumber = 1231; 
            // mdd.RoomNumber = 2;
            MainWindow.Show();
            base.OnStartup(e);

            float sex = 12f;

        }

        public async Task CreateButton()
        {
           await Task.Delay(1000);
        }

        private ReservationListingViewModel CreateReservationListing()
        {
            ReservationListingViewModel vm = new ReservationListingViewModel(_hotel,service);
            service.UpdateCurrentViewModel(vm);
            return vm;
        }

        private MakeReservationViewModel CreateMakeReservation()
        {
            MakeReservationViewModel vm = new MakeReservationViewModel(_hotel, service);
            service.UpdateCurrentViewModel(vm);
            return vm;
        }
    }

}
