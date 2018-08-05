using System;
using System.Collections.Generic;

namespace CheapWare.WebApp.Models
{
    public partial class PartsOrders
    {
        public PartsOrders()
        {
            PartsJunctions = new HashSet<PartsJunctions>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime TimeOfOrder { get; set; }

        public Customers Customer { get; set; }
        public ICollection<PartsJunctions> PartsJunctions { get; set; }
    }
}
