
namespace ZavodAccess.Models
{
    public  class Utilitaire : Car 
    {
        private double _hauteur;



        public Utilitaire() { }

        public Utilitaire(string carImmatriculation = "", string carMarque = "Inconnu", string carModele = "Inconnu", string carConducteur = "Inconnu", string carSociete = "Inconnu", bool isVisiteur = false,double hauteur = 0.0) : base(carImmatriculation, carMarque, carModele, carConducteur, carSociete, isVisiteur)
        {
            _hauteur = hauteur;
        }

        public double Hauteur
        {
            get => _hauteur;
            set
            {
                _hauteur = value;
            }
        }
    }
}
