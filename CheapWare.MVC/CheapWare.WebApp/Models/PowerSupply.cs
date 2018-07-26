using System;
using System.Collections.Generic;

namespace Cheapware.WebApp.Models
{
    public partial class PowerSupply
    {
        public int PowerSupplyId { get; set; }
        public string Name { get; set; }
        public string Watage { get; set; }
        public string Modular { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }

        public Inventory NameNavigation { get; set; }
    }
}
