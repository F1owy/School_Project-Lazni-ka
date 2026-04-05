using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Enums.RoleEnum Role { get; set; }

        public CartEntity Cart { get; set; }
        public ICollection<ReviewEntity> Reviews { get; set; }
    }
}
