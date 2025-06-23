using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErakGiyim
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderType { get; set; }

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        [NotMapped]
        public string CustomerName => Customer?.CustomerName ?? "";

        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [NotMapped]
        public string SupplierName => Supplier?.SupplierName ?? "";

        public List<OrderDetail> OrderDetails { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Paid { get; set; }
    }
}
