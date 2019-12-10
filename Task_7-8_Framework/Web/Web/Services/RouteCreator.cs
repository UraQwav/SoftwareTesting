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
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"), TestDataReader.GetData("FutureDate"), TestDataReader.GetData("PastDate"));
        }
    }
}
