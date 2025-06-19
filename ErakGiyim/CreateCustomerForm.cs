using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErakGiyim
{
    public partial class CreateCustomerForm : Form
    {
        private int? editingCustomerId = null; // ID of the customer being edited, if any
        bool isUpdating = false; // Flag to indicate if the form is in update mode
        public CreateCustomerForm()
        {
            InitializeComponent();
        }

        public CreateCustomerForm(Customer customer) : this()
        {
            editingCustomerId = customer?.CustomerId; // Get the ID of the customer if it exists
            AddButton.Text = "Update";
            isUpdating = true;
            this.Text = "Update Customer";
            // If a customer is passed, populate the form fields with its data
            if (customer != null)
            {
                CustomerNameTextBox.Text = customer.CustomerName;
                EmailTextBox.Text = customer.Email;
                PhoneNumberTextBox.Text = customer.PhoneNumber;
                AddressTextBox.Text = customer.Address;
                CityTextBox.Text = customer.City;
                CountryTextBox.Text = customer.Country;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(CustomerNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(AddressTextBox.Text) ||
                string.IsNullOrWhiteSpace(CityTextBox.Text) ||
                string.IsNullOrWhiteSpace(CountryTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            // Create or update customer
            using (var context = new DenimContext())
            {
                Customer customer;
                if (isUpdating)
                {
                    customer = context.Customers.Find(editingCustomerId);
                    if (customer == null)
                    {
                        MessageBox.Show("Customer not found for updating.");
                        return;
                    }
                }
                else
                {
                    customer = new Customer();
                    context.Customers.Add(customer);
                }
                customer.CustomerName = CustomerNameTextBox.Text;
                customer.Email = EmailTextBox.Text;
                customer.PhoneNumber = PhoneNumberTextBox.Text;
                customer.Address = AddressTextBox.Text;
                customer.City = CityTextBox.Text;
                customer.Country = CountryTextBox.Text;
                context.SaveChanges();
            }
            MessageBox.Show(isUpdating ? "Customer updated successfully." : "Customer added successfully.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Close the form without saving changes
            this.Close();
        }
    }
}
