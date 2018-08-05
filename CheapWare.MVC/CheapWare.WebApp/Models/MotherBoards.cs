using System;
using System.Collections.Generic;

namespace CheapWare.WebApp.Models
{
    public partial class MotherBoards
    {
        public int MotherBoardId { get; set; }
        public string Name { get; set; }
        public string FormFactor { get; set; }
        public int Ramslots { get; set; }
        public int Pcislots { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public Inventorys NameNavigation { get; set; }
    }
}
