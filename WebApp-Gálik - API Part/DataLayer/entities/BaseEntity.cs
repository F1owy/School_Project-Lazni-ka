using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.entities
{
    public abstract class BaseEntity
    {
        public int id { get; set; }

        public Guid PublicId { get; set; }
    }
}
