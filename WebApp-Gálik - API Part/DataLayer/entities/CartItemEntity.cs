using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.entities
{
    public class CartItemEntity : BaseEntity
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }

        public int Amount { get; set; }

        public CartEntity Cart { get; set; } = null!;
        public ProductEntity Product { get; set; } = null!;
    }
}
