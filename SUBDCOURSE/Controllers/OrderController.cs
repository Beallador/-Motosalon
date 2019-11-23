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
    }
}
