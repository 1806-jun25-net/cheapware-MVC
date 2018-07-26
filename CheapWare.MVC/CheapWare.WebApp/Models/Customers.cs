using System;
using System.Collections.Generic;

namespace Cheapware.Data.Models
{
    public partial class Customers
    {
        public Customers()
        {
            PartsOrder = new HashSet<PartsOrder>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }

        public ICollection<PartsOrder> PartsOrder { get; set; }
    }
}
