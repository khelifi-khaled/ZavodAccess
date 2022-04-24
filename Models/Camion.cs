using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavodAccess.Models
{
    public  class Camion : Utilitaire 
    {
        private double _tonnage;

        public Camion()
        {

        }

        public Camion( string carImmatriculation = "", string carMarque = "Inconnu", string carModele = "Inconnu", string carConducteur = "Inconnu", string carSociete = "Inconnu", bool isVisiteur = false, double hauteur = 0.0,double tonnage = 0.0):base(carImmatriculation, carMarque, carModele, carConducteur, carSociete, isVisiteur, hauteur)
        {
            _tonnage = tonnage;
        }

        public double Tonnage
        {
            get => _tonnage;
            set
            {
                _tonnage = value;
            }
        }
    }
}
