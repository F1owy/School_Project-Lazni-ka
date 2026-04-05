using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public Enums.CategoryEnum Category { get; set; }

        public int StockAmount { get; set; }
        public string Description { get; set; }

        public long? ImageId { get; set; }

        public ICollection<ProductImageEntity> Images { get; set; }
        public ICollection<CartItemEntity> CartItems { get; set; }
        public ICollection<ReviewEntity> Reviews { get; set; }
    }
}
