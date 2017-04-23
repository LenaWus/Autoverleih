using CarRentalClient.Models;
using CarRentalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalClient.Controller
{
    class CustomerController
    {
        private static HttpClient client;
        static AllCustomers allCustomers = new AllCustomers();
        internal AllCustomers AllCustomers { get => allCustomers; set => allCustomers = value; }

        public CustomerController()
        {
            HttpClientHandler hch = new HttpClientHandler();
            hch.Proxy = null;
            hch.UseProxy = false;
            client = new HttpClient(hch);
            client.BaseAddress = new Uri("http://localhost:52929");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<Customer> GetCustomersAsync(string path)
        {
            Customer customer = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadAsAsync<Customer>();
            }
            return customer;
        }
        private async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = null;
            HttpResponseMessage response = await client.GetAsync("api/Customer");
            if (response.IsSuccessStatusCode)
            {
                customers = await response.Content.ReadAsAsync<List<Customer>>();
            }
            return customers;
        }

        internal async void AddCustomer(Customer newCustomer)
        {
            allCustomers.Add(newCustomer);
            var newId = allCustomers.Max(c => c.Id) + 1;
            newCustomer.Id = newId;
            await CreateCustomerAsync(newCustomer);
        }

        internal async void Refresh()
        {
            List<Customer> customers = await GetCustomers();
            var newCustomers = customers.Where(c => !AllCustomers.Contains(c));
            newCustomers.ToList().ForEach(c => AllCustomers.Add(c));
        }

        private async Task<Uri> CreateCustomerAsync(Customer customer)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Customer", customer);
            response.EnsureSuccessStatusCode();

            // Return the URI of the created resource.
            return response.Headers.Location;
        }
        private async Task<Car> UpdateCustomerAsync(Car customer)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/Customer/{customer.Id}", customer);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated car from the response body.
            customer = await response.Content.ReadAsAsync<Car>();
            return customer;
        }
        private async Task<HttpStatusCode> DeleteCustomerrAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Customer/{id}");
            return response.StatusCode;
        }
    }
}
