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

        public MotoController(AppDbContext context)
        {
            db = context;
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
    }
}
