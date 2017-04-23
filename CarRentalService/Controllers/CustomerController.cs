using CarRentalService.Models;
using CarRentalService.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace customerRentalService.Controllers
{
    public class CustomerController : ApiController
    {
        private List<Customer> customers = new List<Customer>();

        public IEnumerable<Customer> GetAllCustomers()
        {
            using (var conn = new SqlConnection(DBConnectionUtil.GetConnectionString()))
            using (var command = new SqlCommand("dbo.getAllCustomers", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                using (SqlDataReader customer = command.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (customer.Read())
                    {
                        Customer customerForAdd = new Customer(){ Id = (int)customer["CustomerID"], Firstname = (string)customer["firstname"], Surname = (string)customer["lastname"], Title = (string)customer["title"], Age = (int)customer["age"], Notes = (string)customer["notes"] };
                        if (customers.Exists(cus => cus.Id == customerForAdd.Id))
                        {
                            continue;
                        }
                        customers.Add(customerForAdd);
                    }
                }
            };
            return customers;
        }

        public IHttpActionResult GetCustomer(int id)
        {
            using (var conn = new SqlConnection(DBConnectionUtil.GetConnectionString()))
            using (var command = new SqlCommand("dbo.customerDetails", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add(new SqlParameter("CustomerID", id));
                using (SqlDataReader customer = command.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    if (!customer.HasRows)
                    {
                        return NotFound();
                    }
                    customer.Read();
                    Customer foundCar = new Customer() { Id = (int)customer["CustomerID"], Firstname = (string)customer["firstname"], Surname = (string)customer["surname"], Age = (int)customer["age"], Title = (string)customer["title"], Notes = (string)customer["notes"] };
                    return Ok(foundCar);
                }
            };
        }
        // POST api/values
        public HttpResponseMessage Post(Customer value)
        {
            try
            {
                customers.Add(value);
                using (var conn = new SqlConnection(DBConnectionUtil.GetConnectionString()))
                using (var command = new SqlCommand("dbo.addCustomer", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("CustomerID", value.Id));
                    command.Parameters.Add(new SqlParameter("firstname", value.Firstname));
                    command.Parameters.Add(new SqlParameter("lastname", value.Surname));
                    command.Parameters.Add(new SqlParameter("title", value.Title));
                    command.Parameters.Add(new SqlParameter("age", value.Age));
                    command.Parameters.Add(new SqlParameter("notes", value.Notes));
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

