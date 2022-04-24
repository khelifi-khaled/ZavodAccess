using System;

namespace ZavodAccess.Models
{
    public abstract class Car
    {

        private string _carImmatriculation;
        private string _carMarque;
        private string _carModele;
        private string _carConducteur;
        private string _carSociete;
        private bool _isVisiteur;
        private DateTime _entreeCar;
        private DateTime _sortieCar;

        public Car() { }
        

        public Car( string carImmatriculation ="" , string carMarque = "Inconnu",string carModele= "Inconnu",string carConducteur= "Inconnu",string carSociete= "Inconnu",bool isVisiteur=false)
        {
            _carImmatriculation = carImmatriculation;
            _carMarque = carMarque;
            _carModele = carModele;
            _carConducteur = carConducteur;
            _carSociete = carSociete;
            _isVisiteur=isVisiteur;

        }

        public DateTime EntreeCar
        {
            get => _entreeCar;
            set
            {
                _entreeCar = value;
            }
        }

        public DateTime SortieCar
        {
            get => _sortieCar;
            set
            {
                _sortieCar=value;
            }
        }

        public string CarImmatriculation
        {
            get => _carImmatriculation;
            set
            {
                _carImmatriculation = value;
            }
        }

        public string CarMarque
        {
            get => _carMarque;
            set
            {
                _carMarque=value;
            }
        }

        public string CarModele
        {
            get => _carModele;
            set
            {
                _carModele=value;
            }
        }


        public string CarConducteur
        {
            get => _carConducteur;
            set
            {
                _carConducteur=value;
            }
        }

        public string CarSociete
        {
            get => _carSociete;
            set
            {
                _carSociete = value;
            }
        }

        public bool IsVisiteur
        {
            get => _isVisiteur;
            set
            {
                _isVisiteur = value;
            }
        }

    }//end class 
}//end priject 
