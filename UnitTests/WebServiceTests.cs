using CarRentalService.Controllers;
using CarRentalService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace UnitTests
{   [TestClass]
    class WebServiceTests
    {
        [TestMethod]
        public void GetCarTest()
        {
            CarController carController = new CarController();
            var response = (OkNegotiatedContentResult<Car>) carController.GetCar(1);
            var car = response.Content;
            Assert.AreEqual("Volkswagen", car.Make);
            Assert.AreEqual("Golf", car.Name);
            Assert.AreEqual("silber", car.Colour);
            Assert.AreEqual((decimal)1, car.PricePerHour);
        }
    }
}
