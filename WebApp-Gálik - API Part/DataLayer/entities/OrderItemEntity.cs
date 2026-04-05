using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.entities
{
    public class OrderItemEntity : BaseEntity
    {
        public int OrderId { get; set; }
      public OrderEntity Order { get; set; } = null!;
        public int ProductId { get; set; }
      public ProductEntity Product { get; set; } = null!;
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
  }
}