using System;
using System.Collections.Generic;
using System.Text;
using Web.Models;

namespace Web.Services
{
    class UserSignIn
    {
        public static User WithAllProperties()
        {
            return new User(TestDataReader.GetData("UserLogin"), TestDataReader.GetData("UserPassword"));
        }
    }
}
