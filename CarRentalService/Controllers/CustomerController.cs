using CarRentalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace customerRentalService.Controllers
{
    public class CustomerController : ApiController
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Firstname = "Hannah", Surname = "Müller", Title = "Dr.", Age = 35, Notes = "Kindersitz für 4-jährige" },
            new Customer { Id = 2, Firstname = "Otto", Surname = "Bauer", Title = "Dipl. Ing.", Age = 53, Notes = "kein Duftbaum" },
            new Customer { Id = 3, Firstname = "Alexander", Surname = "Huber", Title = "Herr", Age = 18, Notes = "n/a" }
        };

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customers;
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = customers.First((c) => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        // POST api/values
        public HttpResponseMessage Post(Customer value)
        {
            try
            {
                customers.Add(value);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, Customer value)
        {
            try
            {
                var toBeDeleted = customers.First((c) => c.Id == id);
                customers.Remove(toBeDeleted);
                customers.Add(value);
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
                var toBeDeleted = customers.First((c) => c.Id == id);
                customers.Remove(toBeDeleted);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

