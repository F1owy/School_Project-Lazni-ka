using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.entities
{
    public class ReviewEntity : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public int Stars { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public UserEntity User { get; set; } = null!;
        public ProductEntity Product { get; set; } = null!;
    }
}
