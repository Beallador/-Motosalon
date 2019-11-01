using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Data.Interfaces
{
  public  interface IMotosCategory
    {
        IEnumerable<Category> GetCategories { get; }
    }
}
