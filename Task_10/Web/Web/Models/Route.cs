using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Models
{
    public class Route
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string DepartureDate { get; set; }
        public string ArrivalDate { get; set; }

        public Route(string departureCity, string arrivalCity, string arrivalDate, string departureDate)
        {
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
        }
    }
}
