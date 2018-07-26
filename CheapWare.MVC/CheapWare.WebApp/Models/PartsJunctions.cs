using System;
using System.Collections.Generic;

namespace Cheapware.WebApp.Models
{
    public partial class PartsJunctions
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }

        public Inventorys NameNavigation { get; set; }
        public PartsOrders Order { get; set; }
    }
}
