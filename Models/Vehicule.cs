﻿
namespace ZavodAccess.Models
{
    public  class Vehicule : Car
    {
        public Vehicule() { }

        public Vehicule(string carImmatriculation = "", string carMarque = "Inconnu", string carModele = "Inconnu", string carConducteur = "Inconnu", string carSociete = "Inconnu", bool isVisiteur = false):base(carImmatriculation, carMarque, carModele, carConducteur, carSociete, isVisiteur) 
        {

        }

    }
}
