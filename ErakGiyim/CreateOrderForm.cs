using Microsoft.EntityFrameworkCore;
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
    public partial class CreateOrderForm : Form
    {
        private int? editingOrderId = null;
        bool isUpdating = false;
        private Order _editingOrder = null;
        public CreateOrderForm()
        {
            InitializeComponent();
            OrderDetailsGridView.EditingControlShowing += OrderDetailsGridView_EditingControlShowing;
        }

        public CreateOrderForm(Order order) : this()
        {
            _editingOrder = order;
            editingOrderId = order?.OrderId;
            SaveButton.Text = "Update";
            isUpdating = true;
            this.Text = "Update Order";
        }

        private void OrderDetailsGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (OrderDetailsGridView.CurrentCell is DataGridViewComboBoxCell && OrderDetailsGridView.CurrentCell.OwningColumn.Name == "ProductId")
            {
                var combo = e.Control as ComboBox;
                if (combo != null)
                {
                    // Remove handler first, to avoid multiple bindings
                    combo.SelectedIndexChanged -= ProductComboBox_SelectedIndexChanged;
                    combo.SelectedIndexChanged += ProductComboBox_SelectedIndexChanged;
                }
            }
        }

        private void ProductComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;
            if (combo != null)
            {
                // Which row are we editing?
                var cell = OrderDetailsGridView.CurrentCell as DataGridViewComboBoxCell;
                if (cell != null)
                {
                    int rowIndex = cell.RowIndex;
                    if (combo.SelectedValue is int selectedProductId)
                    {
                        // Find the product's price
                        var selectedProduct = products.FirstOrDefault(p => p.ProductId == selectedProductId);
                        if (selectedProduct != null)
                        {
                            // Set the Unit Price cell
                            OrderDetailsGridView.Rows[rowIndex].Cells["UnitPrice"].Value = selectedProduct.Price;
                        }
                    }
                }
            }
        }



        private List<Product> products;

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {
            OrderTypeComboBox.Items.AddRange(new string[] { "Sale", "Purchase" });
            OrderTypeComboBox.SelectedIndex = 0;

            OrderDateTextBox.Text = DateTime.Now.ToString("dd.MM.yyyy");
            if (isUpdating)
            {
                OrderDateTextBox.Text = _editingOrder?.OrderDate.ToString("dd.MM.yyyy") ?? DateTime.Now.ToString("dd.MM.yyyy");
            }

            using (var context = new DenimContext())
            {
                CustomerComboBox.DataSource = context.Customers.ToList();
                CustomerComboBox.DisplayMember = "CustomerName";
                CustomerComboBox.ValueMember = "CustomerId";

                SupplierComboBox.DataSource = context.Suppliers.ToList();
                SupplierComboBox.DisplayMember = "SupplierName";
                SupplierComboBox.ValueMember = "SupplierId";

                products = context.Products.ToList();
            }

            // Setup columns
            if (OrderDetailsGridView.Columns.Count == 0)
            {
                var productCol = new DataGridViewComboBoxColumn
                {
                    DataSource = products,
                    DisplayMember = "ProductName",
                    ValueMember = "ProductId",
                    HeaderText = "Product",
                    Name = "ProductId"
                };
                OrderDetailsGridView.Columns.Add(productCol);
                OrderDetailsGridView.Columns.Add("Quantity", "Quantity");
                OrderDetailsGridView.Columns.Add("UnitPrice", "Unit Price");
                OrderDetailsGridView.Columns.Add("Subtotal", "Subtotal");
                OrderDetailsGridView.Columns["Subtotal"].ReadOnly = true;
            }

            UpdateComboBoxVisibility();

            if (_editingOrder != null)
            {
                OrderTypeComboBox.SelectedItem = _editingOrder.OrderType ?? "Sale";
                if (_editingOrder.OrderType == "Sale" && _editingOrder.CustomerId.HasValue)
                    CustomerComboBox.SelectedValue = _editingOrder.CustomerId.Value;
                else if (_editingOrder.OrderType == "Purchase" && _editingOrder.SupplierId.HasValue)
                    SupplierComboBox.SelectedValue = _editingOrder.SupplierId.Value;

                OrderDetailsGridView.Rows.Clear();
                foreach (var detail in _editingOrder.OrderDetails ?? Enumerable.Empty<OrderDetail>())
                {
                    OrderDetailsGridView.Rows.Add(detail.ProductId, detail.Quantity, detail.UnitPrice, detail.Quantity * detail.UnitPrice);
                }
                TotalAmount.Text = _editingOrder.TotalAmount.ToString("F2");
            }
        }


        private void OrderTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBoxVisibility();
        }

        private void UpdateComboBoxVisibility()
        {
            if (OrderTypeComboBox.SelectedItem.ToString() == "Sale")
            {
                CustomerComboBox.Visible = true;
                SupplierComboBox.Visible = false;
            }
            else
            {
                CustomerComboBox.Visible = false;
                SupplierComboBox.Visible = true;
            }
        }

        private void OrderDetailsGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = OrderDetailsGridView.Rows[e.RowIndex];

            if (row.IsNewRow) return;

            int qty = 0;
            decimal price = 0;
            int.TryParse(row.Cells["Quantity"].Value?.ToString(), out qty);
            decimal.TryParse(row.Cells["UnitPrice"].Value?.ToString(), out price);

            row.Cells["Subtotal"].Value = qty * price;

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in OrderDetailsGridView.Rows)
            {
                if (row.IsNewRow) continue;
                decimal.TryParse(row.Cells["Subtotal"].Value?.ToString(), out decimal subtotal);
                total += subtotal;
            }
            TotalAmount.Text = total.ToString("F2");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            List<OrderDetail> details = new List<OrderDetail>();
            foreach (DataGridViewRow row in OrderDetailsGridView.Rows)
            {
                if (row.IsNewRow) continue;
                int productId = Convert.ToInt32(row.Cells["ProductId"].Value);
                int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                decimal price = Convert.ToDecimal(row.Cells["UnitPrice"].Value);

                details.Add(new OrderDetail
                {
                    ProductId = productId,
                    Quantity = qty,
                    UnitPrice = price
                });
            }

            using (var context = new DenimContext())
            {
                Order order;
                if (editingOrderId.HasValue)
                {
                    // UPDATE
                    order = context.Orders
                        .Include(o => o.OrderDetails)
                        .FirstOrDefault(o => o.OrderId == editingOrderId.Value);

                    if (order == null)
                    {
                        MessageBox.Show("Order not found!");
                        return;
                    }

                    // Update main properties
                    order.OrderType = OrderTypeComboBox.SelectedItem.ToString();
                    order.CustomerId = (OrderTypeComboBox.SelectedItem.ToString() == "Sale") ? (int?)CustomerComboBox.SelectedValue : null;
                    order.SupplierId = (OrderTypeComboBox.SelectedItem.ToString() == "Purchase") ? (int?)SupplierComboBox.SelectedValue : null;
                    order.OrderDate = DateTime.ParseExact(OrderDateTextBox.Text, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    order.Paid = false;
                    order.TotalAmount = details.Sum(d => d.Quantity * d.UnitPrice);

                    // Remove old details
                    context.OrderDetails.RemoveRange(order.OrderDetails);

                    // Add new details
                    order.OrderDetails = details;
                }
                else
                {
                    // CREATE
                    order = new Order
                    {
                        OrderDate = DateTime.ParseExact(OrderDateTextBox.Text, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        OrderType = OrderTypeComboBox.SelectedItem.ToString(),
                        CustomerId = (OrderTypeComboBox.SelectedItem.ToString() == "Sale") ? (int?)CustomerComboBox.SelectedValue : null,
                        SupplierId = (OrderTypeComboBox.SelectedItem.ToString() == "Purchase") ? (int?)SupplierComboBox.SelectedValue : null,
                        Paid = false,
                        OrderDetails = details,
                        TotalAmount = details.Sum(d => d.Quantity * d.UnitPrice)
                    };
                    context.Orders.Add(order);
                }

                context.SaveChanges();
            }
            MessageBox.Show(editingOrderId.HasValue ? "Order updated!" : "Order saved!");
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
