using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapWare.WebApp.Models
{
    public class InventoryCartView
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public int CartId { get; set; }
        public string ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
