using CarRentalClient.Controller;
using CarRentalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarRentalClient.Views
{
    /// <summary>
    /// Interaction logic for AddNewCarWindow.xaml
    /// </summary>
    public partial class AddNewCarWindow : Window
    {
        CarController carController = new CarController();
        public AddNewCarWindow()
        {
            InitializeComponent();
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox makeTextBox = (TextBox) FindName("makeTextBox");
            TextBox nameTextBox = (TextBox)FindName("nameTextBox");
            TextBox colourTextBox = (TextBox)FindName("colourTextBox");
            TextBox priceTextBox = (TextBox)FindName("priceTextBox");

            Car newCar = new Car();
            newCar.Make = makeTextBox.Text;
            newCar.Name = nameTextBox.Text;
            newCar.Colour = colourTextBox.Text;
            newCar.PricePerHour = Convert.ToDecimal(priceTextBox.Text);
            carController.AddCar(newCar);
        }
    }
}
