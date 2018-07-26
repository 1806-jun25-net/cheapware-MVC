using System;
using System.Collections.Generic;

namespace Cheapware.WebApp.Models
{
    public partial class PartsJunction
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }

        public Inventory NameNavigation { get; set; }
        public PartsOrder Order { get; set; }
    }
}
