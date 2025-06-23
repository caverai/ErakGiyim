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
    public partial class CreateStorageForm : Form
    {
        private int? editingStorageId = null;
        private bool isUpdating = false;

        public CreateStorageForm()
        {
            InitializeComponent();
        }

        public CreateStorageForm(Storage storage) : this()
        {
            if (storage != null)
            {
                editingStorageId = storage.StorageId;
                isUpdating = true;
                StorageNameTextBox.Text = storage.StorageName;
                LocationTextBox.Text = storage.Location;
                CapacityTextBox.Text = storage.Capacity?.ToString() ?? "";
                this.Text = "Update Storage";
                AddButton.Text = "Update";
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StorageNameTextBox.Text) || string.IsNullOrWhiteSpace(LocationTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            int? capacity = null;
            if (!string.IsNullOrWhiteSpace(CapacityTextBox.Text))
            {
                if (int.TryParse(CapacityTextBox.Text, out int cap))
                    capacity = cap;
                else
                {
                    MessageBox.Show("Invalid capacity.");
                    return;
                }
            }

            using (var context = new DenimContext())
            {
                Storage storage;
                if (isUpdating && editingStorageId.HasValue)
                {
                    storage = context.Storages.Find(editingStorageId.Value);
                    if (storage == null)
                    {
                        MessageBox.Show("Storage not found!");
                        return;
                    }
                }
                else
                {
                    storage = new Storage();
                    context.Storages.Add(storage);
                }

                storage.StorageName = StorageNameTextBox.Text;
                storage.Location = LocationTextBox.Text;
                storage.Capacity = capacity;

                context.SaveChanges();
            }
            MessageBox.Show(isUpdating ? "Storage updated!" : "Storage added!");
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
