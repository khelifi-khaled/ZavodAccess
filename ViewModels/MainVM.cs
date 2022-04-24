using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZavodAccess.Models;
using ZavodAccess.Utilities.DataAccess;

namespace ZavodAccess.ViewModels
{
    public  class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const string VEHICULES_CSV_FILE = @"C:\Users\Admin\source\repos\ZavodAccess\Automobiles.csv";
        private const string UTILITAIRES_CSV_FILE = @"C:\Users\Admin\source\repos\ZavodAccess\Camionnettes.csv";
        private const string CAMIONS_CSV_FILE = @"C:\Users\Admin\source\repos\ZavodAccess\Camions.csv";
        private CarCollection _checkInList;
        private Car _selCar;


        public MainVM ()
        {
            VehiculesDataAccesse = new DataAccesseCSV(VEHICULES_CSV_FILE, new string[] { "txt", "csv" }) ;
            UtilitairesDataAccesse = new DataAccesseCSV(UTILITAIRES_CSV_FILE, new string[] { "txt", "csv" });
            CamionsDataAccesse = new DataAccesseCSV(CAMIONS_CSV_FILE, new string[] { "txt", "csv" });


            Cars = VehiculesDataAccesse.GetCarsDatas();
            Concate(Cars, UtilitairesDataAccesse.GetCarsDatas(), CamionsDataAccesse.GetCarsDatas());
            CheckOutList = new CarCollection();
            CheckOutList = new CarCollection();
        }


        public Car SelCar
        {
            get => _selCar;
            set
            {
                _selCar = value;
                OnPropertyChanged(nameof(SelCar));

            }
        }

        public CarCollection Cars { get; set; }




        public CarCollection CheckInList 
        {
            get => _checkInList;
            set
            {
               _checkInList = value;
                OnPropertyChanged(nameof(CheckInList));

            }
        }

        public CarCollection CheckOutList { get; set; }


        public DataAccesseCSV VehiculesDataAccesse { get; set; }

        public DataAccesseCSV UtilitairesDataAccesse { get; set; }


        public DataAccesseCSV CamionsDataAccesse { get; set; }




        private void Concate(CarCollection cars, CarCollection utilitaires, CarCollection camions)
        {
            foreach (var p in utilitaires)
            {
                cars.Add(p);
            }

            foreach (var p in camions)
            {
                cars.Add(p);
            }

        }


        public void CheckIn(string carNum)
        {
            if (Cars.CheckExistedCar(carNum))
            {
                SelCar = Cars.GetCar(carNum);
                SelCar.EntreeCar = DateTime.Now;
                CheckInList.Add(SelCar);
            }
            else
            {
                
            }
        }


       

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
