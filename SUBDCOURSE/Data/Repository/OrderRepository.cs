using SUBDCOURSE.Data.Interfaces;
using SUBDCOURSE.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUBDCOURSE.Data.Repository
{
    public class OrderRepository : IAllOrder
    {
        private readonly AppDbContext appDbContext;
        private readonly ShopCart shopCart;

        public OrderRepository(AppDbContext appDbContext, ShopCart shopCart)
        {
            this.appDbContext = appDbContext;
            this.shopCart = shopCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDbContext.Orders.Add(order);

            var items = shopCart.listShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetails
                {
                    MotoId = el.moto.Id,
                    Price = (uint)el.moto.Price,
                    OrderId =  order.Id

                };
                appDbContext.OrderDetails.Add(orderDetail);


            }

            appDbContext.SaveChanges();
        }
    }
}
