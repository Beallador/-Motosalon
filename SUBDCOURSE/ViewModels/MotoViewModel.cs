using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.ViewModels
{
    public class MotoViewModel
    {
        public IEnumerable<Moto> allMoto { get; set; }

        public string currCategory { get; set; }

    }
}
