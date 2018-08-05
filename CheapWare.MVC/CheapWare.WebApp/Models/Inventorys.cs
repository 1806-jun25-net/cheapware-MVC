using System;
using System.Collections.Generic;

namespace CheapWare.WebApp.Models
{
    public partial class Inventorys
    {
        public Inventorys()
        {
            ComputerCases = new HashSet<ComputerCases>();
            Cpus = new HashSet<Cpus>();
            GraphicsCards = new HashSet<GraphicsCards>();
            HardDrives = new HashSet<HardDrives>();
            MotherBoards = new HashSet<MotherBoards>();
            PartsJunctions = new HashSet<PartsJunctions>();
            PowerSupplys = new HashSet<PowerSupplys>();
            Rams = new HashSet<Rams>();
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public ICollection<ComputerCases> ComputerCases { get; set; }
        public ICollection<Cpus> Cpus { get; set; }
        public ICollection<GraphicsCards> GraphicsCards { get; set; }
        public ICollection<HardDrives> HardDrives { get; set; }
        public ICollection<MotherBoards> MotherBoards { get; set; }
        public ICollection<PartsJunctions> PartsJunctions { get; set; }
        public ICollection<PowerSupplys> PowerSupplys { get; set; }
        public ICollection<Rams> Rams { get; set; }
    }
}
