using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Data.Interfaces
{
    public interface IAllMoto
    {
        IEnumerable<Moto> Motos { get; }
        IEnumerable<Moto> GetFavoriteMotos { get; }
        Moto GetMoto(int motoId);
    }
}
