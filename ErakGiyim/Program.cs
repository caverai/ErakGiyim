using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ErakGiyim
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var ctx = new DenimContext())
            {
                var pending = ctx.Database.GetPendingMigrations().ToList();
                if (pending.Any()) ctx.Database.Migrate();

                if (!ctx.Users.Any())
                {
                    var (hash, salt) = PasswordHasher.Hash("admin123");
                    ctx.Users.Add(new AppUser
                    {
                        Username = "admin",
                        PasswordHash = hash,
                        PasswordSalt = salt,
                        Role = "Admin",
                        IsActive = true
                    });
                    ctx.SaveChanges();
                }
            }

            Session.CurrentUsername = PromptForUsername();

            Application.Run(new MainForm());
        }

        public static string PromptForUsername()
        {
            using (var prompt = new UsernamePromptForm())
            {
                return prompt.ShowDialog() == DialogResult.OK
                    ? prompt.UsernameTextBox.Text
                    : "Unknown";
            }
        }
    }

    public static class Session
    {
        public static string CurrentUsername { get; set; } = "Unknown";
    }

    public interface IAuditable
    {
        DateTime CreatedAt { get; set; }
        string? CreatedBy { get; set; }
        DateTime? UpdatedAt { get; set; }
        string? UpdatedBy { get; set; }
    }
}
