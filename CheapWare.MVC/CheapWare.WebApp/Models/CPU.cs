using System;
using System.Collections.Generic;

namespace Cheapware.WebApp.Models
{
    public partial class Cpu
    {
        public int Cpuid { get; set; }
        public string Name { get; set; }
        public string Speed { get; set; }
        public int Cores { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
    }
}
