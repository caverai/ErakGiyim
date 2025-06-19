using System.Linq;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ErakGiyim
{
    public partial class MainForm : Form
    {
        private static readonly List<string> SizeOrder = new List<string> { "S", "M", "L", "XL" };

        private string lastSortedColumn = null;
        private bool lastSortAscending = true;
        public MainForm()
        {
            InitializeComponent();
            TableBox.SelectedIndexChanged += TableBox_SelectedIndexChanged;
            using (var context = new DenimContext())
            {
                context.Database.Migrate();
            }
        }

        private void LoadProducts()
        {
            using (var context = new DenimContext())
            {
                var products = context.Products.ToList();
                GridView.DataSource = products;
            }
        }

        private void LoadCustomers()
        {
            using (var context = new DenimContext())
            {
                var customers = context.Customers.ToList();
                GridView.DataSource = customers;
            }
        }

        private void LoadTableNames()
        {
            var tableNames = new List<string>
            {
                "Products",
                "Customers",
                "Orders",
                "OrderDetails",
                "Employees"
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

            if (selectedTable == "Products")
            {
                LoadProducts();
            }
            else if (selectedTable == "Customers")
            {
                LoadCustomers();
            }
            else
            {
                // Optionally, clear the grid or show a message until you add other tables
                GridView.DataSource = null;
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            if (TableBox.SelectedItem == "Products")
            {
                CreateProductForm createProductForm = new CreateProductForm();
                createProductForm.ShowDialog();
                LoadProducts();
            }
            else if (TableBox.SelectedItem == "Customers")
            {
                CreateCustomerForm createCustomerForm = new CreateCustomerForm();
                if (createCustomerForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomers();
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            // Check if a product is selected
            if (GridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Open the CreateProductForm with the selected product for editing
            if (TableBox.SelectedItem == "Products")
            {
                // Get the selected product
                var selectedProduct = (Product)GridView.SelectedRows[0].DataBoundItem;
                CreateProductForm createProductForm = new CreateProductForm(selectedProduct);
                createProductForm.ShowDialog();
                LoadProducts();
            }
            else if (TableBox.SelectedItem == "Customers")
            {
                // Get the selected customer
                var selectedCustomer = (Customer)GridView.SelectedRows[0].DataBoundItem;
                CreateCustomerForm createCustomerForm = new CreateCustomerForm(selectedCustomer);
                createCustomerForm.ShowDialog();
                LoadCustomers();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (GridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TableBox.SelectedItem == "Products")
            {
                var selectedProduct = (Product)GridView.SelectedRows[0].DataBoundItem;

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
            else if (TableBox.SelectedItem == "Customers")
            {
                var selectedCustomer = (Customer)GridView.SelectedRows[0].DataBoundItem;
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete the customer '{selectedCustomer.CustomerName}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (var context = new DenimContext())
                        {
                            // Find the customer by its unique ID in the DB
                            var customerToDelete = context.Customers.Find(selectedCustomer.CustomerId);
                            if (customerToDelete != null)
                            {
                                context.Customers.Remove(customerToDelete);
                                context.SaveChanges();
                                MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("The selected customer could not be found in the database.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        // Reload customers after deletion
                        LoadCustomers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Delete failed:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            // Refresh the data in the grid view based on the selected table
            if (TableBox.SelectedItem == "Products")
            {
                LoadProducts();
            }
            else if (TableBox.SelectedItem == "Customers")
            {
                LoadCustomers();
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        private void GridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (TableBox.SelectedItem == "Products")
            {
                if (GridView.DataSource is List<Product> products)
                {
                    var columnName = GridView.Columns[e.ColumnIndex].DataPropertyName;

                    // Determine sort direction
                    bool ascending = true;
                    if (lastSortedColumn == columnName)
                    {
                        ascending = !lastSortAscending; // toggle direction if same column
                    }
                    lastSortedColumn = columnName;
                    lastSortAscending = ascending;

                    var prop = typeof(Product).GetProperty(columnName);

                    if (prop != null)
                    {
                        if (columnName == "Size")
                        {
                            if (ascending)
                            {
                                GridView.DataSource = products.OrderBy(p => SizeOrder.IndexOf(p.Size)).ToList();
                            }
                            else
                            {
                                GridView.DataSource = products.OrderByDescending(p => SizeOrder.IndexOf(p.Size)).ToList();
                            }
                        }
                        else
                        {
                            if (ascending)
                                GridView.DataSource = products.OrderBy(p => prop.GetValue(p, null)).ToList();
                            else
                                GridView.DataSource = products.OrderByDescending(p => prop.GetValue(p, null)).ToList();
                        }
                    }
                }
            }
            else if (GridView.DataSource is List<Customer> customers)
            {
                var columnName = GridView.Columns[e.ColumnIndex].DataPropertyName;
                // Determine sort direction
                bool ascending = true;
                if (lastSortedColumn == columnName)
                {
                    ascending = !lastSortAscending; // toggle direction if same column
                }
                lastSortedColumn = columnName;
                lastSortAscending = ascending;
                var prop = typeof(Customer).GetProperty(columnName);
                if (prop != null)
                {
                    if (ascending)
                        GridView.DataSource = customers.OrderBy(c => prop.GetValue(c, null)).ToList();
                    else
                        GridView.DataSource = customers.OrderByDescending(c => prop.GetValue(c, null)).ToList();
                }
            }
        }
    }
}
