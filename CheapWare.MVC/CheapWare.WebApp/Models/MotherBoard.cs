using System;
using System.Collections.Generic;

namespace Cheapware.WebApp.Models
{
    public partial class MotherBoard
    {
        public int MotherBoardId { get; set; }
        public string Name { get; set; }
        public string FormFactor { get; set; }
        public int Ramslots { get; set; }
        public int Pcislots { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }

        public Inventory NameNavigation { get; set; }
    }
}
