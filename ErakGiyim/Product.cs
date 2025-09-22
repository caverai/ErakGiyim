using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErakGiyim
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int AmountInStock { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }

        public int? StorageId { get; set; }
        public Storage? Storage { get; set; }

        [NotMapped]
        public string StorageName => Storage?.StorageName ?? "";

        public List<OrderDetail> OrderDetails { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
