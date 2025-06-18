using System.Linq;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace ErakGiyim
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            TableBox.SelectedIndexChanged += TableBox_SelectedIndexChanged;
        }

        private void LoadProducts()
        {
            using (var context = new DenimContext())
            {
                var products = context.Products.ToList();
                GridView.DataSource = products;
            }
        }

        private void LoadTableNames()
        {
            var tableNames = new List<string>
            {
                "Products"
            };

            TableBox.DataSource = tableNames;

            if (TableBox.Items.Count > 0)
            {
                TableBox.SelectedIndex = 0;
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadTableNames();
        }

        private void TableBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTable = TableBox.SelectedItem.ToString();

            // For now, only handle "Products"
            if (selectedTable == "Products")
            {
                LoadProducts();
            }
            else
            {
                // Optionally, clear the grid or show a message until you add other tables
                GridView.DataSource = null;
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            // Open the CreateProductForm to add a new product
            CreateProductForm createForm = new CreateProductForm();
            createForm.ShowDialog();
            // Reload products after creating a new one
            LoadProducts();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            // Check if a product is selected
            if (GridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Get the selected product
            var selectedProduct = (Product)GridView.SelectedRows[0].DataBoundItem;
            // Open the CreateProductForm with the selected product for editing
            CreateProductForm editForm = new CreateProductForm(selectedProduct);
            editForm.ShowDialog();
            // Reload products after updating
            LoadProducts();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Check if a product is selected
            if (GridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the selected product from the grid
            var selectedProduct = (Product)GridView.SelectedRows[0].DataBoundItem;

            // Confirm deletion
            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete the product '{selectedProduct.ProductName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (var context = new DenimContext())
                    {
                        // Find the product by its unique ID in the DB
                        var productToDelete = context.Products.Find(selectedProduct.ProductId);
                        if (productToDelete != null)
                        {
                            context.Products.Remove(productToDelete);
                            context.SaveChanges();
                            MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The selected product could not be found in the database.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    // Reload products after deletion
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete failed:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            // Reload products from the database
            LoadProducts();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }
    }
}
