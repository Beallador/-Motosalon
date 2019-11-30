using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Moto> Motos { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
