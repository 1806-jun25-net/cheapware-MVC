using System;
using System.Collections.Generic;

namespace Cheapware.WebApp.Models
{
    public partial class PartsOrder
    {
        public PartsOrder()
        {
            PartsJunction = new HashSet<PartsJunction>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime TimeOfOrder { get; set; }

        public Customers Customer { get; set; }
        public ICollection<PartsJunction> PartsJunction { get; set; }
    }
}
