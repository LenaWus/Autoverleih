using CarRentalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRentalService.Controllers
{
    public class CarController : ApiController
    {
        List<Car> cars = new List<Car>
        {
            new Car { Id = 1, Make = "Volkswagen", Name = "Golf", PricePerHour = 1, Colour = "silber" },
            new Car { Id = 2, Make = "Mazda", Name = "MX-5 Miata", PricePerHour = 2, Colour = "blau" },
            new Car { Id = 3, Make = "Honda", Name = "Odyssey",PricePerHour = 1.5M, Colour = "schwarz" }
        };

        public IEnumerable<Car> GetAllCars()
        {
            return cars;
        }

        public IHttpActionResult GetCar(int id)
        {
            var car = cars.FirstOrDefault((c) => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
        // POST api/values
        public HttpResponseMessage Post(Car value)
        {
            try
            {
                cars.Add(value);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, Car value)
        {
            try
            {
                var toBeDeleted = cars.First((c) => c.Id == id);
                cars.Remove(toBeDeleted);
                cars.Add(value);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var toBeDeleted = cars.First((c) => c.Id == id);
                cars.Remove(toBeDeleted);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
