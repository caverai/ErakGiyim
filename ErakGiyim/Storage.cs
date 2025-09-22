using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErakGiyim
{
    public class Storage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StorageId { get; set; }
        public string StorageName { get; set; }
        public string Location { get; set; }
        public int? Capacity { get; set; }
        public List<Product> Products { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }


        [NotMapped]
        public int RemainingCapacity
        {
            get
            {
                // If Capacity is null, treat as infinite capacity (or return 0)
                if (Capacity == null)
                    return 0;
                // If Products is null, treat as 0 products
                int used = Products?.Sum(p => p.AmountInStock) ?? 0;
                return Capacity.Value - used;
            }
        }
    }
}
