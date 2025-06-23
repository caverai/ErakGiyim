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
    public partial class CreateSupplierForm : Form
    {
        private int? editingSupplierId = null;
        bool isUpdating = false;
        public CreateSupplierForm()
        {
            InitializeComponent();
        }

        public CreateSupplierForm(Supplier supplier) : this()
        {
            editingSupplierId = supplier?.SupplierId;
            AddButton.Text = "Update";
            isUpdating = true;
            this.Text = "Update Supplier";
            if (supplier != null)
            {
                SupplierNameTextBox.Text = supplier.SupplierName;
                PhoneNumberTextBox.Text = supplier.PhoneNumber;
                EmailTextBox.Text = supplier.Email;
                AddressTextBox.Text = supplier.Address;
                CityTextBox.Text = supplier.City;
                CountryTextBox.Text = supplier.Country;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SupplierNameTextBox.Text))
            {
                MessageBox.Show("Please fill in the supplier name.");
                return;
            }
            using (var context = new DenimContext())
            {
                Supplier supplier = isUpdating ? context.Suppliers.Find(editingSupplierId) : new Supplier();
                if (supplier == null)
                {
                    MessageBox.Show("Supplier not found.");
                    return;
                }
                supplier.SupplierName = SupplierNameTextBox.Text;
                supplier.PhoneNumber = PhoneNumberTextBox.Text;
                supplier.Email = EmailTextBox.Text;
                supplier.Address = AddressTextBox.Text;
                supplier.City = CityTextBox.Text;
                supplier.Country = CountryTextBox.Text;
                if (!isUpdating) context.Suppliers.Add(supplier);
                context.SaveChanges();
            }
            MessageBox.Show(isUpdating ? "Supplier updated successfully." : "Supplier added successfully.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
