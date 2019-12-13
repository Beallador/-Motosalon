using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SUBDCOURSE.Data;
using SUBDCOURSE.Data.Interfaces;
using SUBDCOURSE.Data.Models;
using SUBDCOURSE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Controllers
{
    public class MotoController : Controller
    {
        private readonly IAllMoto _allMoto;
        private readonly IMotosCategory _motosCategory;
        private AppDbContext db;

        public MotoController(AppDbContext context, IAllMoto allMoto, IMotosCategory motosCategory)
        {
            db = context;
            _allMoto = allMoto;
            _motosCategory = motosCategory;
        }


        public async Task<IActionResult> Index(SortKey sortKey = SortKey.OrderBy)
        {
            IQueryable<Moto> motos = db.Motos.Include(x => x.Category);

            ViewData["PriceSort"] = sortKey == SortKey.OrderBy ? SortKey.OrderBy : SortKey.OrderByDesc;
            

            switch (sortKey)
            {
                case SortKey.OrderByDesc:
                    motos = motos.OrderByDescending(s => s.Price);
                    break;
                default:
                    motos = motos.OrderBy(s => s.Price);
                    break;
            }

            MotoViewModel viewModel = new MotoViewModel
            {
                Motos = await motos.AsNoTracking().ToListAsync(),
                SortViewModel = new SortViewModel(sortKey)
            };
            return View(viewModel);
        }
    


        [Route("Moto/Moto")]
        [Route("Moto/Moto/{category}")]
        public ViewResult Moto(string category)
        {
            string _category = category;

            IEnumerable<Moto> motos = null;

            string currCategoru = "";

            if (string.IsNullOrEmpty(category))
            {
                motos = _allMoto.Motos.OrderBy(i => i.Price);

            }
            else
            {
                if (string.Equals("Sport", category, StringComparison.OrdinalIgnoreCase))
                {
                    motos = _allMoto.Motos.Where(i => i.Category.CategoryName.Equals("Спортивный")).OrderBy(i => i.Id);
                }
                else if (string.Equals("Turist", category, StringComparison.OrdinalIgnoreCase))
                {
                    motos = _allMoto.Motos.Where(i => i.Category.CategoryName.Equals("Туристический")).OrderBy(i => i.Id);
                }
                else if (string.Equals("Classic", category, StringComparison.OrdinalIgnoreCase))
                {
                    motos = _allMoto.Motos.Where(i => i.Category.CategoryName.Equals("Классический")).OrderBy(i => i.Id);
                }

                currCategoru = _category;
            }

            var motoObj = new MotoViewModel
            {
                AllMoto = motos,
                CurrCategory = currCategoru
            };

            
            return View(motoObj);


        }


        public ActionResult Filter(int? category, string name)
        {
            IQueryable<Moto> motos = db.Motos.Include(p => p.Category);
            if (category != null && category != 0)
            {
                motos = motos.Where(p => p.CategoryId == category);
            }
            if (!String.IsNullOrEmpty(name))
            {
                motos = motos.Where(p => p.Name.Contains(name));
            }

            List<Category> categories = db.Categories.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            categories.Insert(0, new Category { CategoryName = "Все", Id = 0 });

           MotoViewModel viewModel = new MotoViewModel
            {
               AllMoto = motos.ToList(),
                Categories = new SelectList(categories, "Id", "Name"),
                Name = name
            };
            return View(viewModel);
        }
    }
}
