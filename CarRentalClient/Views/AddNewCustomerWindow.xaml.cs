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
    /// Interaction logic for AddNewCustomer.xaml
    /// </summary>
    public partial class AddNewCustomerWindow : Window
    {
        CustomerController customerController = new CustomerController();
        public AddNewCustomerWindow()
        {
            InitializeComponent();
        }

        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox firstnameTextBox = (TextBox)FindName("firstnameTextBox");
            TextBox surnameTextBox = (TextBox)FindName("surnameTextBox");
            TextBox titleTextBox = (TextBox)FindName("titleTextBox");
            TextBox ageTextBox = (TextBox)FindName("ageTextBox");
            TextBox notesTextBox = (TextBox)FindName("notesTextBox");

            Customer newCustomer = new Customer();
            newCustomer.Firstname = firstnameTextBox.Text;
            newCustomer.Surname = surnameTextBox.Text;
            newCustomer.Title = titleTextBox.Text;
            newCustomer.Age = Convert.ToInt32(ageTextBox.Text);
            newCustomer.Notes = notesTextBox.Text;
            customerController.AddCustomer(newCustomer);
        }
    }
}
