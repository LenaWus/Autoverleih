using CarRentalService.Models;
using CarRentalService.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace CarRentalService.Controllers
{
    public class RentController :ApiController
    {
        private List<Rent> rents = new List<Rent>();

        //GetAllRents
        public IEnumerable<Rent> GetAllRents()
        {
            using (var conn = new SqlConnection(DBConnectionUtil.GetConnectionString()))
            using (var command = new SqlCommand("dbo.getAllRents", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                using (SqlDataReader rent = command.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rent.Read())
                    {
                        Rent rentForAdd = new Rent() { CustomerID = (int)rent["CustomerID"], CarID = (int)rent["CarID"], beginOfRenting = (DateTime)rent["beginOfRenting"], endOfRenting = (DateTime)rent["endofRenting"] };
                        if (rents.Exists(r => r.CarID==rentForAdd.CarID && r.CustomerID==rentForAdd.CustomerID && r.endOfRenting == rentForAdd.endOfRenting))
                        {
                            continue;
                        }
                            rents.Add(rentForAdd);
                    }
                }
            };
            return rents;
        }

        //PostNewRent
        public HttpResponseMessage Post(Rent value)
        {
            try
            {
                rents.Add(value);
                using (var conn = new SqlConnection(DBConnectionUtil.GetConnectionString()))
                using (var command = new SqlCommand("dbo.addRent", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("CustomerID", value.CustomerID));
                    command.Parameters.Add(new SqlParameter("CarId", value.CarID));
                    command.Parameters.Add(new SqlParameter("beginOfRenting", value.beginOfRenting));
                    command.Parameters.Add(new SqlParameter("endOfRenting", value.endOfRenting));
                    command.ExecuteNonQuery();
                };
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //PutRent


        //DeleteRent
        public HttpResponseMessage Delete(Rent value)
        {
            try
            {
                var foundRent = rents.Find((r) => r.CustomerID==value.CustomerID && r.CarID == value.CarID && r.endOfRenting==value.endOfRenting);
                foundRent.done = true;
                using (var conn = new SqlConnection(DBConnectionUtil.GetConnectionString()))
                using (var command = new SqlCommand("dbo.returnCar", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.Parameters.Add(new SqlParameter("CustomerID", value.CustomerID));
                    command.Parameters.Add(new SqlParameter("CarId", value.CarID));
                    command.Parameters.Add(new SqlParameter("endOfRenting", value.endOfRenting));
                    command.ExecuteNonQuery();
                };
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}