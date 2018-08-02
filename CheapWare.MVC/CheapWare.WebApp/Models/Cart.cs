using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapWare.WebApp.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public string ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
