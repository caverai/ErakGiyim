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
    public partial class ViewStorageForm : Form
    {
        int _storageId;
        public ViewStorageForm(int storageId)
        {
            InitializeComponent();
            _storageId = storageId;
            LoadStorageData();
        }

        private void LoadStorageData()
        {
            using (var context = new DenimContext())
            {
                // Get the storage info
                var storage = context.Storages.FirstOrDefault(s => s.StorageId == _storageId);

                // Set form title
                if (storage != null)
                    this.Text = $"Storage: {storage.StorageName} ({storage.Location})";

                // Get all products in this storage
                var products = context.Products
                                      .Where(p => p.StorageId == _storageId)
                                      .ToList();

                StorageGridView.AutoGenerateColumns = false;
                StorageGridView.Columns.Clear();
                StorageGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ProductName",
                    HeaderText = "Product Name"
                });
                StorageGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Price",
                    HeaderText = "Price",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                });
                StorageGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "AmountInStock",
                    HeaderText = "Amount in Stock"
                });
                StorageGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Size",
                    HeaderText = "Size"
                });
                StorageGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Color",
                    HeaderText = "Color"
                });

                StorageGridView.DataSource = products;
            }
        }
    }
}
