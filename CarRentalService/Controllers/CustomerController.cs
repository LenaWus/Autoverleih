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
            new Customer { id = 1, firstname = "Hannah", surname = "Müller", title = "Dr.", age = 35, notes = "Kindersitz für 4-jährige" },
            new Customer { id = 2, firstname = "Otto", surname = "Bauer", title = "Dipl. Ing.", age = 53, notes = "kein Duftbaum" },
            new Customer { id = 3, firstname = "Alexander", surname = "Huber", title = "Herr", age = 18, notes = "Gurtschutz" }
        };

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customers;
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = customers.First((c) => c.id == id);
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
                var toBeDeleted = customers.First((c) => c.id == id);
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
                var toBeDeleted = customers.First((c) => c.id == id);
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

