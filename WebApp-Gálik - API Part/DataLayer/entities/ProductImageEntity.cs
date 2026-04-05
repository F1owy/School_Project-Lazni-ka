using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.entities
{
    public class ProductImageEntity : BaseEntity
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }

        public ProductEntity Product { get; set; } = null!;
    }
}
