using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Moto> favMoto { get; set; }
    }
}
