using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Data.Models
{
    public class ShopCart
    {

        private readonly AppDbContext appDbContext;

        public ShopCart(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }


        public void AddToCart(Moto moto)
        {
            appDbContext.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId=ShopCartId,
                moto=moto,
                price=moto.Price

            });

            appDbContext.SaveChanges();

        }

        public List<ShopCartItem> GetShopCartItems()
        {
            return appDbContext.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.moto ).ToList();
        }
        
    }
}
