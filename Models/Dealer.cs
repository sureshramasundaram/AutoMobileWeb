using AutoMobileWeb.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMobileWeb.Models
{
    public abstract class Dealer 
    {
        public string DealerName { get; set; }
        public virtual List<Car> GetCars(DealerResult dealerResult)
        {
            List<Car> carList  = new List<Car>();
            foreach(makes make in dealerResult.makes)
            {
                if(make.makeModels.ToList().Count > 0)
                {
                    foreach(makeModels makeModel in make.makeModels)
                    {
                        Car car = new Car();
                        car.MakeName = make.name;
                        car.ModelName = makeModel.name;
                        car.Mileage = makeModel.mileage;
                        car.Price = makeModel.price;
                        car.Color = (Color)Enum.Parse(typeof(Color), makeModel.color.ToString());
                        car.CarColor = Enum.GetName(typeof(Color), makeModel.color);
                        car.Status = (Status)Enum.Parse(typeof(Status), makeModel.status.ToString());
                        carList.Add(car);
                    }

                }
            }
            return carList;
        }
        public abstract void setDealerCarStatus(List<Car> Cars);

    }
}
