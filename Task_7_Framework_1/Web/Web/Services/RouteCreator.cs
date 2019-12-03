using System;
using System.Collections.Generic;
using System.Text;
using Web.Models;
namespace Web.Services
{
    class RouteCreator
    {
        public static Route WithAllProperties()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"));
        }

        public static Route WithEqualCities()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("DepartureCity"));
        }
    }
}
