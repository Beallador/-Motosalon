using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Data.Models
{
    public class OrderDetails
    { 
        public int Id { get; set; }
        public int MotoId { get; set; }
        public int OrderId { get; set; }
        public uint Price { get; set; }
        public virtual Moto Moto { get; set; }
        public virtual Order Order { get; set; }
      
    }
}
