using Cheapware.Data.Models;
using System;
using System.Collections.Generic;

namespace Cheapware.WebApp.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            ComputerCase = new HashSet<ComputerCase>();
            Cpu = new HashSet<Cpu>();
            GraphicsCard = new HashSet<GraphicsCard>();
            HardDrive = new HashSet<HardDrive>();
            MotherBoard = new HashSet<MotherBoard>();
            PartsJunction = new HashSet<PartsJunction>();
            PowerSupply = new HashSet<PowerSupply>();
            Ram = new HashSet<Ram>();
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }

        public ICollection<ComputerCase> ComputerCase { get; set; }
        public ICollection<Cpu> Cpu { get; set; }
        public ICollection<GraphicsCard> GraphicsCard { get; set; }
        public ICollection<HardDrive> HardDrive { get; set; }
        public ICollection<MotherBoard> MotherBoard { get; set; }
        public ICollection<PartsJunction> PartsJunction { get; set; }
        public ICollection<PowerSupply> PowerSupply { get; set; }
        public ICollection<Ram> Ram { get; set; }
    }
}
