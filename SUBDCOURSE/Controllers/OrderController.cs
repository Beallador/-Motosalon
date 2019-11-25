using Microsoft.AspNetCore.Mvc;
using SUBDCOURSE.Data.Interfaces;
using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrder allOrder;
        private readonly ShopCart shopCart;
        public OrderController(IAllOrder allOrder, ShopCart shopCart)
        {
            this.allOrder = allOrder;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.listShopItems = shopCart.GetShopCartItems();

            if (shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Корзина пуста");
            }

            if (ModelState.IsValid)
            {
                allOrder.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {

            ViewBag.Message = "Заявка успешно отправлена\nНаши специалисты вам перезвонят";
            return View();
        }
    }
}
