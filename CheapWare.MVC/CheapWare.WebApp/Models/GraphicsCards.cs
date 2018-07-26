using System;
using System.Collections.Generic;

namespace Cheapware.WebApp.Models
{
    public partial class GraphicsCards
    {
        public int GraphicsCardId { get; set; }
        public string Name { get; set; }
        public string Speed { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }

        public Inventorys NameNavigation { get; set; }
    }
}
