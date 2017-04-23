using CarRentalClient.Controller;
using CarRentalClient.Models;
using CarRentalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRentalClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RentCarWindow : Window
    {
        CarController carController = new CarController();
        CustomerController customerController = new CustomerController();

        public RentCarWindow()
        {
            InitializeComponent();
            
            var dataBoxCars = (ListBox)FindName("CarDataListBox");
            dataBoxCars.ItemsSource = carController.CarsFromFleet;
            var dataBoxCustomers = (ListBox)FindName("CustomerDataListBox");
            dataBoxCustomers.ItemsSource = customerController.AllCustomers; 
                        
        }

        public void RefreshAllData(object sender, RoutedEventArgs e)
        {
            //Thread t1 = new Thread(new ThreadStart(RunAsync().Wait));
            carController.Refresh();
            customerController.Refresh();
            //task.Wait(5000);
        }

        private void RentButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }






        //customers.ForEach(cus => AllCustomers.Add(cus));
        /*try
        {
            // Create a new car
            Car car = new Car { Id = 3, Make="Honda", Name = "Odyssey", PricePerHour = 1.5M, Colour = "schwarz" };

            var url = await CreateCarAsync(car);
            Console.WriteLine($"Created at {url}");

            // Get the car
            car = await GetCarAsync(url.PathAndQuery);
            //ShowCar(car);

            // Update the car
            Console.WriteLine("Updating price...");
            car.PricePerHour = 1.8M;
            await UpdateCarAsync(car);

            // Get the updated car
            car = await GetCarAsync(url.PathAndQuery);
            //ShowCar(car);

            // Delete the car
            var statusCode = await DeleteCarAsync(car.Id);
            Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadLine(); */
    }
}
