using Microsoft.AspNetCore.Mvc;
using SUBDCOURSE.Data;
using SUBDCOURSE.Data.Interfaces;
using SUBDCOURSE.Data.Models;
using SUBDCOURSE.ViewModels;
using System.Linq;

namespace SUBDCOURSE.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllMoto _motoRepository;
        private readonly ShopCart _shopCart;
        private readonly AppDbContext appDbContext;
        public ShopCartController(IAllMoto motoRepository, ShopCart shopCart, AppDbContext appDbContext)
        {
            _motoRepository = motoRepository;
            _shopCart = shopCart;
            this.appDbContext = appDbContext;
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

        public RedirectToActionResult RemoveFromCart(int id)
        {
            var item = appDbContext.ShopCartItems.Find(id);
            if (item != null)
            {
                appDbContext.Remove(item);
                appDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
