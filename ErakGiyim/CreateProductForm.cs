using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErakGiyim
{
    public partial class CreateProductForm : Form
    {
        private int? editingProductId = null; // ID of the product being edited, if any
        bool isUpdating = false; // Flag to indicate if the form is in update mode
        public CreateProductForm()
        {
            InitializeComponent();
            LoadSizesAndColors();
        }

        public CreateProductForm(Product product) : this()
        {
            editingProductId = product?.ProductId; // Get the ID of the product if it exists
            CreateButton.Text = "Update";
            isUpdating = true;
            this.Text = "Update Product";
            // If a product is passed, populate the form fields with its data
            if (product != null)
            {
                ProductNameTextBox.Text = product.ProductName;
                PriceTextBox.Text = product.Price.ToString("F2");
                AmountInStockTextBox.Text = product.AmountInStock.ToString();
                int sizeIndex = SizeComboBox.FindStringExact(product.Size);
                if (sizeIndex >= 0)
                    SizeComboBox.SelectedIndex = sizeIndex;
                int colorIndex = ColorComboBox.FindStringExact(product.Color);
                if (colorIndex >= 0)
                    ColorComboBox.SelectedIndex = colorIndex;
            }
        }

        private void LoadSizesAndColors()
        {
            // Load sizes and colors into the ComboBoxes
            SizeComboBox.Items.AddRange(new string[] { "S", "M", "L", "XL" });
            ColorComboBox.Items.AddRange(new string[] { "Blue", "Black", "White", "Red", "Green" });
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(ProductNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PriceTextBox.Text) ||
                string.IsNullOrWhiteSpace(AmountInStockTextBox.Text) ||
                SizeComboBox.SelectedItem == null ||
                ColorComboBox.SelectedItem == null )
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(PriceTextBox.Text, out decimal price))
            {
                MessageBox.Show("Invalid price format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(AmountInStockTextBox.Text, out int amountInStock))
            {
                MessageBox.Show("Invalid stock amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isUpdating) {
                // If in update mode, update the existing product
                UpdateProduct(price, amountInStock);
            }
            else
            {
                // Otherwise, create a new product
                CreateNewProduct(price, amountInStock);
            }
            this.Close(); // Close the form after creation
        }

        private void UpdateProduct(decimal price, int amountInStock)
        {
            // Update the existing product in the database
            try
            {
                using (var context = new DenimContext())
                {
                    var product = context.Products.FirstOrDefault(p => p.ProductId == editingProductId);
                    if (product != null)
                    {
                        product.ProductName = ProductNameTextBox.Text;
                        product.Price = price;
                        product.AmountInStock = amountInStock;
                        product.Size = SizeComboBox.SelectedItem.ToString();
                        product.Color = ColorComboBox.SelectedItem.ToString();
                        context.SaveChanges();
                        MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateNewProduct(decimal price, int amountInStock)
        {
            // Create a new product instance
            var newProduct = new Product
            {
                ProductName = ProductNameTextBox.Text,
                Price = price,
                AmountInStock = amountInStock,
                Size = SizeComboBox.SelectedItem.ToString(),
                Color = ColorComboBox.SelectedItem.ToString()
            };
            // Save the product to the database
            try
            {
                using (var context = new DenimContext())
                {
                    context.Products.Add(newProduct);
                    context.SaveChanges();
                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while creating the product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form without saving
        }
    }
}
