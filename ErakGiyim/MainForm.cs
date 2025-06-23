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
            TotalPurchaseDisplay.Visible = false;
            TotalPurchaseLabel.Visible = false;
            TotalSaleDisplay.Visible = false;
            TotalSaleLabel.Visible = false;
            ViewStorageButton.Visible = false;
        }

        private void LoadProducts()
        {
            using (var context = new DenimContext())
            {
                GridView.AutoGenerateColumns = false;
                var products = context.Products.Include(p => p.Storage).ToList();
                GridView.Columns.Clear();
                GridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ProductId",
                    HeaderText = "Product ID"
                });
                GridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ProductName",
                    HeaderText = "Product Name"
                });
                GridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Price",
                    HeaderText = "Price",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                });
                GridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "AmountInStock",
                    HeaderText = "Amount In Stock"
                });
                GridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Size",
                    HeaderText = "Size"
                });
                GridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Color",
                    HeaderText = "Color"
                });
                GridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "StorageName",
                    HeaderText = "Storage"
                });
                GridView.DataSource = products;
            }
        }

        private void LoadCustomers()
        {
            using (var context = new DenimContext())
            {
                GridView.AutoGenerateColumns = true;
                var customers = context.Customers.ToList();
                GridView.DataSource = customers;
            }
        }

        private void LoadSuppliers()
        {
            using (var context = new DenimContext())
            {
                GridView.AutoGenerateColumns = true;
                var suppliers = context.Suppliers.ToList();
                GridView.DataSource = suppliers;
            }
        }

        private void LoadOrders()
        {
            using (var context = new DenimContext())
            {
                var orders = context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Supplier)
                .ToList();

                GridView.AutoGenerateColumns = false;
                GridView.Columns.Clear();
                GridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "OrderId",
                    HeaderText = "Order ID"
                });
                GridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "OrderType",
                    HeaderText = "Type"
                });
                GridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Customer",
                    DataPropertyName = "CustomerName"
                });
                GridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Supplier",
                    DataPropertyName = "SupplierName"
                });
                GridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "OrderDate",
                    HeaderText = "Order Date",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "d" }
                });
                GridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TotalAmount",
                    HeaderText = "Total Amount",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                });
                GridView.Columns.Add(new DataGridViewCheckBoxColumn
                {
                    DataPropertyName = "Paid",
                    HeaderText = "Paid"
                });
                GridView.DataSource = orders;
            }
            //Compute totals
            using (var context = new DenimContext())
            {
                var totalSales = context.Orders
                    .Where(o => o.OrderType == "Sale")
                    .Sum(o => o.TotalAmount);
                TotalSaleDisplay.Text = totalSales.ToString("C2");
                var totalPurchases = context.Orders
                    .Where(o => o.OrderType == "Purchase")
                    .Sum(o => o.TotalAmount);
                TotalPurchaseDisplay.Text = totalPurchases.ToString("C2");
            }
        }

        private void LoadStorage()
        {
            using (var context = new DenimContext())
            {
                GridView.AutoGenerateColumns = true;
                var storage = context.Storages.Include(s => s.Products).ToList();
                GridView.DataSource = storage;
            }
        }

        private void LoadTableNames()
        {
            var tableNames = new List<string>
            {
                "Products",
                "Customers",
                "Suppliers",
                "Orders",
                "Storage"
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
                ViewStorageButton.Visible = false;
                TotalSaleDisplay.Visible = false;
                TotalSaleLabel.Visible = false;
                TotalPurchaseDisplay.Visible = false;
                TotalPurchaseLabel.Visible = false;
            }
            else if (selectedTable == "Customers")
            {
                LoadCustomers();
                ViewStorageButton.Visible = false;
                TotalSaleDisplay.Visible = false;
                TotalSaleLabel.Visible = false;
                TotalPurchaseDisplay.Visible = false;
                TotalPurchaseLabel.Visible = false;
            }
            else if (selectedTable == "Suppliers")
            {
                LoadSuppliers();
                ViewStorageButton.Visible = false;
                TotalSaleDisplay.Visible = false;
                TotalSaleLabel.Visible = false;
                TotalPurchaseDisplay.Visible = false;
                TotalPurchaseLabel.Visible = false;
            }
            else if (selectedTable == "Orders")
            {
                LoadOrders();
                ViewStorageButton.Visible = false;
                TotalSaleDisplay.Visible = true;
                TotalSaleLabel.Visible = true;
                TotalPurchaseDisplay.Visible = true;
                TotalPurchaseLabel.Visible = true;
            }
            else if (selectedTable == "Storage")
            {
                LoadStorage();
                ViewStorageButton.Visible = true;
                TotalSaleDisplay.Visible = false;
                TotalSaleLabel.Visible = false;
                TotalPurchaseDisplay.Visible = false;
                TotalPurchaseLabel.Visible = false;
            }
            else
            {
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
            else if (TableBox.SelectedItem == "Suppliers")
            {
                CreateSupplierForm createSupplierForm = new CreateSupplierForm();
                if (createSupplierForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSuppliers();
                }
            }
            else if (TableBox.SelectedItem == "Orders")
            {
                var createOrderForm = new CreateOrderForm();
                createOrderForm.ShowDialog();
                LoadOrders();
            }
            else if (TableBox.SelectedItem == "Storage")
            {
                CreateStorageForm createStorageForm = new CreateStorageForm();
                createStorageForm.ShowDialog();
                LoadStorage();
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
            else if (TableBox.SelectedItem == "Suppliers")
            {
                // Get the selected supplier
                var selectedSupplier = (Supplier)GridView.SelectedRows[0].DataBoundItem;
                CreateSupplierForm createSupplierForm = new CreateSupplierForm(selectedSupplier);
                createSupplierForm.ShowDialog();
                LoadSuppliers();
            }
            else if (TableBox.SelectedItem == "Orders")
            {
                var selectedOrder = (Order)GridView.SelectedRows[0].DataBoundItem;

                // Fetch a fresh copy with OrderDetails, Customer, Supplier
                using (var context = new DenimContext())
                {
                    var orderFromDb = context.Orders
                        .Include(o => o.OrderDetails)
                        .Include(o => o.Customer)
                        .Include(o => o.Supplier)
                        .FirstOrDefault(o => o.OrderId == selectedOrder.OrderId);

                    if (orderFromDb == null)
                    {
                        MessageBox.Show("Order not found!");
                        return;
                    }

                    CreateOrderForm createOrderForm = new CreateOrderForm(orderFromDb);
                    createOrderForm.ShowDialog();
                    LoadOrders();
                }
            }
            else if (TableBox.SelectedItem == "Storage")
            {
                if (GridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select a storage to update.");
                    return;
                }
                var selected = (Storage)GridView.SelectedRows[0].DataBoundItem;
                CreateStorageForm form = new CreateStorageForm(selected);
                form.ShowDialog();
                LoadStorage();
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
            else if (TableBox.SelectedItem == "Suppliers")
            {
                var selectedSupplier = (Supplier)GridView.SelectedRows[0].DataBoundItem;
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete the supplier '{selectedSupplier.SupplierName}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (var context = new DenimContext())
                        {
                            // Find the supplier by its unique ID in the DB
                            var supplierToDelete = context.Suppliers.Find(selectedSupplier.SupplierId);
                            if (supplierToDelete != null)
                            {
                                context.Suppliers.Remove(supplierToDelete);
                                context.SaveChanges();
                                MessageBox.Show("Supplier deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("The selected supplier could not be found in the database.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        // Reload suppliers after deletion
                        LoadSuppliers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Delete failed:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (TableBox.SelectedItem == "Orders")
            {
                var selectedOrder = (Order)GridView.SelectedRows[0].DataBoundItem;
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete the order with ID '{selectedOrder.OrderId}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (var context = new DenimContext())
                        {
                            // Find the order by its unique ID in the DB
                            var orderToDelete = context.Orders.Find(selectedOrder.OrderId);
                            if (orderToDelete != null)
                            {
                                context.Orders.Remove(orderToDelete);
                                context.SaveChanges();
                                MessageBox.Show("Order deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("The selected order could not be found in the database.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        // Reload orders after deletion
                        LoadOrders();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Delete failed:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (TableBox.SelectedItem == "Storage")
            {
                var selectedStorage = (Storage)GridView.SelectedRows[0].DataBoundItem;
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete the storage '{selectedStorage.StorageName}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (var context = new DenimContext())
                        {
                            // Find the storage by its unique ID in the DB
                            var storageToDelete = context.Storages.Find(selectedStorage.StorageId);
                            if (storageToDelete != null)
                            {
                                context.Storages.Remove(storageToDelete);
                                context.SaveChanges();
                                MessageBox.Show("Storage deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("The selected storage could not be found in the database.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        // Reload storage after deletion
                        LoadStorage();
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
            if (TableBox.SelectedItem == "Products")
            {
                LoadProducts();
            }
            else if (TableBox.SelectedItem == "Customers")
            {
                LoadCustomers();
            }
            else if (TableBox.SelectedItem == "Suppliers")
            {
                LoadSuppliers();
            }
            else if (TableBox.SelectedItem == "Orders")
            {
                LoadOrders();
            }
            else if (TableBox.SelectedItem == "Storage")
            {
                LoadStorage();
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
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

        private void ViewStorageButton_Click(object sender, EventArgs e)
        {
            if (GridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a storage to view.", "View Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var selectedStorage = (Storage)GridView.SelectedRows[0].DataBoundItem;
            ViewStorageForm viewStorageForm = new ViewStorageForm(selectedStorage.StorageId);
            viewStorageForm.ShowDialog();
        }

        private void TotalSaleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
