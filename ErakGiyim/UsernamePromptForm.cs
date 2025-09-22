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
    public partial class UsernamePromptForm : Form
    {
        public UsernamePromptForm()
        {
            InitializeComponent();

            OkButton.DialogResult = DialogResult.OK;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var username = UsernameTextBox.Text.Trim();
            var password = PasswordTextBox.Text; // Use a PasswordChar on the TextBox

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Enter username and password.");
                this.DialogResult = DialogResult.None;
                return;
            }

            using (var ctx = new DenimContext())
            {
                var user = ctx.Users.FirstOrDefault(u => u.Username == username && u.IsActive);
                if (user == null || !PasswordHasher.Verify(password, user.PasswordHash, user.PasswordSalt))
                {
                    MessageBox.Show("Invalid username or password.");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                // success
                Session.CurrentUsername = user.Username;
            }
        }
    }

}
