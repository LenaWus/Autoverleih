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
    class CarController
    {
        private static HttpClient client;
        static Carfleet carsFromFleet = new Carfleet();
        internal Carfleet CarsFromFleet { get => carsFromFleet; set => carsFromFleet = value; }

        public CarController()
        {
            HttpClientHandler hch = new HttpClientHandler();
            hch.Proxy = null;
            hch.UseProxy = false;
            client = new HttpClient(hch);
            client.BaseAddress = new Uri("http://localhost:52929");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<Car> GetCarAsync(string path)
        {
            Car car = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                car = await response.Content.ReadAsAsync<Car>();
            }
            return car;
        }
        private async Task<List<Car>> GetCars()
        {
            List<Car> cars = null;
            HttpResponseMessage response = await client.GetAsync("api/Car");
            if (response.IsSuccessStatusCode)
            {
                cars = await response.Content.ReadAsAsync<List<Car>>();
            }
            return cars;
        }

        internal async void AddCar(Car newCar)
        {
            carsFromFleet.Add(newCar);
            var newId = carsFromFleet.Max(c => c.Id)+1;
            newCar.Id = newId;
            await CreateCarAsync(newCar);
        }

        private async Task<Uri> CreateCarAsync(Car car)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Car", car);
            response.EnsureSuccessStatusCode();

            // Return the URI of the created resource.
            return response.Headers.Location;
        }
        private async Task<Car> UpdateCarAsync(Car car)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/Car/{car.Id}", car);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated car from the response body.
            car = await response.Content.ReadAsAsync<Car>();
            return car;
        }

        internal async void Refresh()
        {
            List<Car> cars = await GetCars();
            var newCars = cars.Where(c => !CarsFromFleet.Contains(c));
            newCars.ToList().ForEach(c => CarsFromFleet.Add(c));
        }

        private async Task<HttpStatusCode> DeleteCarAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Car/{id}");
            return response.StatusCode;
        }
    }
}
