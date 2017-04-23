using CarRentalService.Models;
using CarRentalService.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace CarRentalService.Controllers
{
    public class CarController : ApiController
    {
        private List<Car> cars = new List<Car>();

        public IEnumerable<Car> GetAllCars()
        {
            using (var conn = new SqlConnection(DBConnectionUtil.GetConnectionString()))
            using (var command = new SqlCommand("dbo.getAllCars", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                using (SqlDataReader car = command.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (car.Read())
                    {
                        cars.Add(new Car() {Id = (int)car["CarID"], Make = (string)car["make"], Name = (string)car["name"], PricePerHour = (decimal)car["pricePerHour"], Colour = (string)car["colour"]});
                    }
                }
            };
            return cars;
        }

        public IHttpActionResult GetCar(int id)
        {
            using (var conn = new SqlConnection(DBConnectionUtil.GetConnectionString()))
            using (var command = new SqlCommand("dbo.carDetails", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add(new SqlParameter("CarID", id));
                using (SqlDataReader car = command.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    if (!car.HasRows)
                    {
                        return NotFound();
                    }
                    car.Read();
                    Car foundCar = new Car() { Id = (int)car["CarID"], Make = (string)car["make"], Name = (string)car["name"], PricePerHour = (decimal)car["pricePerHour"], Colour = (string)car["colour"] };
                    return Ok(foundCar);
                }
            };
        }
        // POST api/values
        public HttpResponseMessage Post(Car value)
        {
            try
            {
                cars.Add(value);
                using (var conn = new SqlConnection(DBConnectionUtil.GetConnectionString()))
                using (var command = new SqlCommand("dbo.addCar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("CarID", value.Id));
                    command.Parameters.Add(new SqlParameter("make", value.Make));
                    command.Parameters.Add(new SqlParameter("name", value.Name));
                    command.Parameters.Add(new SqlParameter("pricePerHour", value.PricePerHour));
                    command.Parameters.Add(new SqlParameter("colour", value.Colour));
                    command.ExecuteNonQuery();
                };
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
                using (var conn = new SqlConnection(DBConnectionUtil.GetConnectionString()))
                using (var command = new SqlCommand("dbo.alterCar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("CarID", value.Id));
                    command.ExecuteNonQuery();
                };
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
