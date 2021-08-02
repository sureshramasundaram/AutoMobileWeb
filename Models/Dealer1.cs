using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMobileWeb.Models
{
    public class Dealer1 : Dealer
    {
        public override void setDealerCarStatus(List<Car> Cars)
        {
            Cars.Where(x => (int)x.Status == (int)Status.Active).ToList().ForEach(x => x.CarStatus = "For Sale");
            Cars.Where(x => (int)x.Status == (int)Status.InActive).ToList().ForEach(x => x.CarStatus = "InActive");
        }

    }
}
