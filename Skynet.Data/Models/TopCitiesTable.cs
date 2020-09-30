using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class TopCitiesTable
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longtitude { get; set; }
    }
}
