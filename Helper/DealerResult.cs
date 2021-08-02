using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMobileWeb.Helper
{
    public class DealerResult
    {
        public Guid id { get; set; }
        public string dealerName { get; set; }
        public IEnumerable<makes> makes { get; set; }
    }
    public class makes
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public IEnumerable<makeModels> makeModels { get; set; }
        public Guid dealerId { get; set; }
    }
    public class makeModels
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public long mileage { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }
        public int color { get; set; }
        public int status { get; set; }
        public Guid makeId { get; set; }

    }
}
