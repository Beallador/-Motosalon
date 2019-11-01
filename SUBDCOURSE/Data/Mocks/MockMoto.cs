using SUBDCOURSE.Data.Interfaces;
using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Data.Mocks
{
    public class MockMoto : IAllMoto
    {
        private readonly IMotosCategory _motosCategory = new MockCategory();
        public IEnumerable<Moto> Motos
        {
            get
            {
                return new List<Moto> {
                    new Moto { Name = "Kawa"}
                };
            }
        }
        public IEnumerable<Moto> GetFavoriteMotos
        {
            get;set;
        }

        public Moto GetMoto(int motoId)
        {
            throw new NotImplementedException();
        }
    }
}
