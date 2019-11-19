using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.ViewModels
{
    public class MotoViewModel
    {
        public IEnumerable<Moto> AllMoto { get; set; }

        public string CurrCategory { get; set; }

    }
}
