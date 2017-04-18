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
            new Car { id = 1, make = "Volkswagen", name = "Golf", pricePerHour = 1, colour = "silber" },
            new Car { id = 2, make = "Mazda", name = "MX-5 Miata", pricePerHour = 2, colour = "blau" },
            new Car { id = 3, make = "Honda", name = "Odyssey",pricePerHour = 1.5M, colour = "schwarz" }
        };

        public IEnumerable<Car> GetAllCars()
        {
            return cars;
        }

        public IHttpActionResult GetCar(int id)
        {
            var car = cars.FirstOrDefault((c) => c.id == id);
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
                var toBeDeleted = cars.First((c) => c.id == id);
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
                var toBeDeleted = cars.First((c) => c.id == id);
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
