using System;
using System.Collections.Generic;

namespace Cheapware.WebApp.Models
{
    public partial class ComputerCase
    {
        public int ComputerCaseId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }

        public Inventory NameNavigation { get; set; }
    }
}
