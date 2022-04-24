using System;
using System.ComponentModel;
using System.Windows;
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
            CheckInList = new CarCollection();
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
            if (!string.IsNullOrEmpty(carNum))
            {
                if (!CheckInList.CheckExistedCar(carNum))
                {
                    if (Cars.CheckExistedCar(carNum))
                    {
                        SelCar = Cars.GetCar(carNum);
                        SelCar.EntreeCar = DateTime.Now;
                        CheckInList.Add(SelCar);
                    }
                    else
                    {
                        SelCar = new Vehicule(carNum);
                        SelCar.EntreeCar = DateTime.Now;
                        CheckInList.Add(SelCar);
                    }
                }
                else
                {
                    MessageBox.Show($"Véhicule {carNum} existe deja dans le checkIn List", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            else
            {
                MessageBox.Show("vous devez remplire le chemp de l'Immatriculation avent le check in svp", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }




        public void CheckOut(string carNum)
        {
            if (!string.IsNullOrEmpty(carNum))
            {
                if (CheckInList.CheckExistedCar(carNum))
                {
                    SelCar = CheckInList.GetCar(carNum);
                    CheckInList.Remove(SelCar);
                    CheckOutList.Add(SelCar);
                }
                else
                {
                    MessageBox.Show($"la voiture {carNum} n'a pas fais son check in  ", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("vous devez remplire le chemp de l'Immatriculation avent le check out svp", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }



            protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


 

    }
}
