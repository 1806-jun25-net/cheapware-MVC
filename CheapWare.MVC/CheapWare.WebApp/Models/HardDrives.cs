using System;
using System.Collections.Generic;

namespace Cheapware.WebApp.Models
{
    public partial class HardDrives
    {
        public int HardDriveId { get; set; }
        public string Name { get; set; }
        public string Speed { get; set; }
        public string Size { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public Inventorys NameNavigation { get; set; }
    }
}
