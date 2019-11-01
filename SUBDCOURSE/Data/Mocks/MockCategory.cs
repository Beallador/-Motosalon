using SUBDCOURSE.Data.Interfaces;
using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Data.Mocks
{
    public class MockCategory : IMotosCategory
    {
        public IEnumerable<Category> GetCategories
        {
            get
            {
                return new List<Category>
                {
                    //todo
                };
            }
        }
    }
}
