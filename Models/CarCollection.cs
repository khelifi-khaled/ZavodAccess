using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZavodAccess.Models
{
    public class CarCollection : ObservableCollection<Car>
    {


        public Car GetCar(string numCar )
        {
            List<Car> Cars = this.ToList();
            return Cars.Find(c=>c.CarImmatriculation.Equals(numCar));
        }


        public bool CheckExistedCar(string numCar)
        {
            bool flag = false;

            foreach (Car car in this)
            {
                if (car.CarImmatriculation.Equals(numCar))
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}
