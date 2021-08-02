using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMobileWeb.Models
{
    public class Dealer2 : Dealer
    {
        public override void setDealerCarStatus(List<Car> Cars)
        {
            Cars.Where(x => (int)x.Status == (int)Status.Active).ToList().ForEach(x => x.CarStatus="Active");
            Cars.Where(x => (int)x.Status == (int)Status.InActive).ToList().ForEach(x => x.CarStatus = "InActive");
        }
    }
}
