using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Data.Models
{
    public class Moto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Img { get; set; }
        public decimal Price { get; set; }
        public bool isFavorite { get; set; }
        public int CategoryId { get; set; }
        public int Available { get; set; }
        public virtual Category Category { get; set; }

    }
}
