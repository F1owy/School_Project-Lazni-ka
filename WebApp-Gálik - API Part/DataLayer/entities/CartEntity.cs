using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.entities
{
    public class CartEntity : BaseEntity
    {
        public int UserId { get; set; }

        public UserEntity User { get; set; } = null!;
        public ICollection<CartItemEntity> Items { get; set; } = new List<CartItemEntity>();
    }
}
