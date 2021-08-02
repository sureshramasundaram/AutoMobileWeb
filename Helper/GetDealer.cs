using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMobileWeb.Models;

namespace AutoMobileWeb.Helper
{
    public class GetDealer
    {
        private readonly Dealer _dealer;
        String DealerName = string.Empty;
        public GetDealer(string dealerName)
        {
            DealerName = dealerName;
            if (dealerName == "Dealer1") _dealer = new Dealer1();
            if (dealerName == "Dealer2") _dealer = new Dealer2();
        }
        public List<Car> BuildCarObject(DealerResult dealerResult)
        {
            return _dealer.GetCars(dealerResult);
        }
        public void setDealerCarStatus(List<Car> Cars)
        {
            _dealer.setDealerCarStatus(Cars);
        }


    }
}
