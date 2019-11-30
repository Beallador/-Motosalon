using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.ViewModels
{
    public class OrderViewModel
    {
        public IEnumerable<Order> Orders { get; set; }

    }
}
