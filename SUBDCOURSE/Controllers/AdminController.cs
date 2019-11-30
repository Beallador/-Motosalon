using Microsoft.AspNetCore.Mvc;
using SUBDCOURSE.Data;
using SUBDCOURSE.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUBDCOURSE.Data.Models;
using Microsoft.EntityFrameworkCore;
using SUBDCOURSE.ViewModels;

namespace SUBDCOURSE.Controllers
{
    public class AdminController : Controller
    {

        private readonly IAllMoto _motoRepository;
        private readonly AppDbContext appDbContext;

        public AdminController(AppDbContext appDbContext, IAllMoto motoRepository)
        {
            this.appDbContext = appDbContext;
            _motoRepository = motoRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await appDbContext.Motos.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Moto moto)
        {
            appDbContext.Motos.Add(moto);
            await appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Moto moto = await appDbContext.Motos.FirstOrDefaultAsync(p => p.Id == id);
                if (moto != null)
                    return View(moto);
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Moto moto = await appDbContext.Motos.FirstOrDefaultAsync(p => p.Id == id);
                if (moto != null)
                    return View(moto);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Moto moto)
        {
            appDbContext.Motos.Update(moto);
            await appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Moto moto = await appDbContext.Motos.FirstOrDefaultAsync(p => p.Id == id);
                if (moto != null)
                    return View(moto);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Moto moto = await appDbContext.Motos.FirstOrDefaultAsync(p => p.Id == id);
                if (moto != null)
                {
                    appDbContext.Motos.Remove(moto);
                    await appDbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public IActionResult Order()
        {
            OrderViewModel orderViewModel = new OrderViewModel
            {
                Orders = appDbContext.Orders.ToList()
            };
            return View(orderViewModel);
        }

        public IActionResult Process(int? id)
        {
            if(id!=null)
            {
                Order order = appDbContext.Orders.FirstOrDefault(p => p.Id == id);
                if (order!=null)
                {
                    appDbContext.Orders.Remove(order);
                    appDbContext.SaveChanges();
                    return RedirectToAction("Order");
                }
            }
            return NotFound();
        }
    }
}
