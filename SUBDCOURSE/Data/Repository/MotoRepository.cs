using Microsoft.EntityFrameworkCore;
using SUBDCOURSE.Data.Interfaces;
using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Data.Repository
{
    public class MotoRepository : IAllMoto
    {
        private readonly AppDbContext appDbContext;

        public MotoRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Moto> Motos => appDbContext.Motos.Include(c=>c.Category);

        public IEnumerable<Moto> GetFavoriteMotos => appDbContext.Motos.Where(p => p.isFavorite).Include(C => C.Category);

        public Moto GetMoto(int motoId) => appDbContext.Motos.FirstOrDefault(p => p.Id.Equals(motoId));
    
    }
}
