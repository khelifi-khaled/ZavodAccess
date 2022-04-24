using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZavodAccess.Models;
using ZavodAccess.Utilities.Interfaces;

namespace ZavodAccess.Utilities.DataAccess
{
    public class DataAccesseCSV : DataAccess , IDataAccesse
    {
        public DataAccesseCSV(string filePath) : base(filePath) { }

        public DataAccesseCSV(string filePath, string[] extensions) : base(filePath, extensions) { }

        /// <summary>
        /// retrieve Cars collection datas from the datasource csv file
        /// </summary>
        public override CarCollection GetCarsDatas()
        {
            CarCollection cars = new CarCollection();

            List<string> listToRead = new List<string>();
            //lecture d'un fichier csv et stockage dans une List de string
            if (IsValidAccessPath)
            {
                listToRead = File.ReadAllLines(AccessPath).ToList();
                foreach (string s in listToRead)
                {
                    Console.WriteLine(s);
                    Car c = GetCar(s);
                    cars.Add(c);
                }
                return cars;
            }
            else
            {
                return null;
            }

        }//end GetCarsDatas

        private Car GetCar(string line)
        {
            string[] fields = line.Split(';');
            switch (fields.Length)
            {
                case 6:
                    return new Vehicule(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5].Equals("TRUE"));
                case 7:
                    return new Utilitaire(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5].Equals("TRUE"),double.Parse(fields[6]));
                case 8:
                    return new Camion(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5].Equals("TRUE"), double.Parse(fields[6]), double.Parse(fields[7]));
                default:
                    return null;
            }//end switch case
        }//end GetCar


    }//end class 
}//end project 
