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
        private AppDbContent db;

        public MotoController(AppDbContent context)
        {
            db = context;
        }

        //public MotoController(IMotosCategory iMotoCategory, IAllMoto iAllMoto)
        //{
        //    _allMoto = iAllMoto;
        //    _motosCategory = iMotoCategory;
        //}

        public ViewResult ViewMoto()
        {
            MotoViewModel obj = new MotoViewModel();
            obj.allMoto = _allMoto.Motos;
            obj.currCategory = "";
            return View(obj);
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Motos.ToListAsync());
        }
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
