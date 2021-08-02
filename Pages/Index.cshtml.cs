using AutoMobileWeb.Helper;
using AutoMobileWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AutoMobileWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private string server = "https://localhost:51044/";
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetDealerCars(Guid guid, string DealerName, int sorting)
        {
            GetDealer getDealer = new GetDealer(DealerName);
            DealerResult dealerObject = null;
            List<Car> cars = new List<Car>();
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    string url = server + "api/dealers/" + guid;
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            dealerObject = JsonConvert.DeserializeObject<DealerResult>(apiResponse);
                            cars = getDealer.BuildCarObject(dealerObject);
                            getDealer.setDealerCarStatus(cars);
                        }
                    }
                }
            }
            if (sorting == 1) cars= cars.OrderBy(s => s.Price).ToList();
            if (sorting == 2) cars =cars.OrderBy(s => s.Price).ThenBy(s=>s.ModelName).ToList();
            return new JsonResult(cars);
        }
    }
}
