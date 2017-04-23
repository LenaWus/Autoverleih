using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using CarRentalService.Controllers;
using System.Web.Http;
using System.Collections.Generic;
using CarRentalService.Models;
using customerRentalService.Controllers;
using System.Web.Http.Results;
using CarRentalService.Utils;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var conn = new SqlConnection("Data Source=carrentalservice.database.windows.net;Initial Catalog=CarRentalDatabase;Integrated Security=False;User ID=LenaAdmin;Password=Mimigibe4!;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            using (var command = new SqlCommand("dbo.customerDetails", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add(new SqlParameter("CustomerID", 1));
                using (SqlDataReader cust = command.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (cust.Read())
                    {
                        Console.WriteLine("Firstname: {0,-35} Lastname: {1,2}", cust["Firstname"], cust["Lastname"]);
                    }
                }
            }
        }

        [TestMethod]
        public void CarControllerGetAllTest()
        {
            CarController testObjekt = new CarController();
            var result = testObjekt.GetAllCars() as List<Car>;
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void CustomerControllerGetAllTest()
        {
            CustomerController testObjekt = new CustomerController();
            var result = testObjekt.GetAllCustomers() as List<Customer>;
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void GetCarTest()
        {
            CarController carController = new CarController();
            var response = (OkNegotiatedContentResult<Car>)carController.GetCar(1);
            var car = response.Content;
            Assert.AreEqual("Volkswagen", car.Make);
            Assert.AreEqual("Golf", car.Name);
            Assert.AreEqual("silber", car.Colour);
            Assert.AreEqual((decimal)1, car.PricePerHour);
        }
    }
}
