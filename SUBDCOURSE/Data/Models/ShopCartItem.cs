using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Data.Models
{
    public class ShopCartItem
    {

        public int Id { get; set; }
        public decimal price { get; set; }

        public Moto moto { get; set; }

        public string ShopCartId { get; set; }
    }
}
