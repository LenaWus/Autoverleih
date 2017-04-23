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
using System.Windows.Navigation;
using CarRentalClient.Views;

namespace CarRentalClient.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewCustomerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoToRentCarPage(object sender, RoutedEventArgs e)
        {
            RentCarWindow newRentCarWindow = new RentCarWindow();
            newRentCarWindow.ShowDialog();
        }

        private void GoToReturnCar(object sender, RoutedEventArgs e)
        {

        }

        private void GoToPrices(object sender, RoutedEventArgs e)
        {
            PricesWindow newPricesWindow = new PricesWindow();
            newPricesWindow.ShowDialog();
        }

        private void GoToAddNewCar(object sender, RoutedEventArgs e)
        {
            AddNewCarWindow newAddCarWindow = new AddNewCarWindow();
            newAddCarWindow.ShowDialog();
        }

        private void GoToAddNewCustomer(object sender, RoutedEventArgs e)
        {
            AddNewCustomerWindow newAddCustomerWindow = new AddNewCustomerWindow();
            newAddCustomerWindow.ShowDialog();
        }
    }
}
