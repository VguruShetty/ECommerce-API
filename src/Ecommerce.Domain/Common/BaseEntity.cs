using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Common
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; } = default!;
        public DateTime CreatedAtUTC { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAtUTC { get; set; }
    }
}
