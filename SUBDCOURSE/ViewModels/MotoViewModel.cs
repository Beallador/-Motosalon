using Microsoft.AspNetCore.Mvc.Rendering;
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

        public SelectList Categories { get; set; }

        public string Name { get; set; }

        public IEnumerable<Moto> Motos { get; set; }
        public SortViewModel SortViewModel { get; set; }

    }
}
