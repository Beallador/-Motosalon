using Microsoft.AspNetCore.Mvc;
using SUBDCOURSE.Data.Interfaces;
using SUBDCOURSE.Data.Models;
using SUBDCOURSE.Data.Repository;
using SUBDCOURSE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllMoto _motoRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllMoto motoRepository, ShopCart shopCart)
        {
            _motoRepository = motoRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopCartItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _motoRepository.Motos.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
