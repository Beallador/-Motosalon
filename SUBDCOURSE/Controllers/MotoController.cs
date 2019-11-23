using Microsoft.AspNetCore.Mvc;
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

        public MotoController(AppDbContext context, IAllMoto allMoto,IMotosCategory motosCategory)
        {
            db = context;
            _allMoto = allMoto;
            _motosCategory = motosCategory;
        }

       
        

        public async Task<IActionResult> Index()
        {
            var list = await db.Motos.ToListAsync();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Moto moto)
        {
            db.Motos.Add(moto);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
                motos = _allMoto.Motos.OrderBy(i => i.Id);

            }
            else
            {
                if (string.Equals("Sport",category, StringComparison.OrdinalIgnoreCase ))
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

        

    }
}
