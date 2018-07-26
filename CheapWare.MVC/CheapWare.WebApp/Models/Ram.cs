using Cheapware.WebApp.Models;
using System;
using System.Collections.Generic;

namespace Cheapware.Data.Models
{
    public partial class Ram
    {
        public int Ramid { get; set; }
        public string Name { get; set; }
        public string Speed { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }

        public Inventory NameNavigation { get; set; }
    }
}
