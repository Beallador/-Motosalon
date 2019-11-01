using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Desc { get; set; }

        public string CategoryName { get; set; }

        public List<Moto> Motos { get; set; }


    }
}
