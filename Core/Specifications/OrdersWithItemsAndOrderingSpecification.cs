
using Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class OrdersWithItemsAndOrderingSpecification: BaseSpecification<Order>
    {
        public OrdersWithItemsAndOrderingSpecification(string email) :base(x=>x.BuyerEmail== email)
        {
            AddInclude(x => x.OrderItems);
            AddInclude(x => x.DeliveryMethod);
            AddOrderByDescending(x => x.OrderDate);


        }

        public OrdersWithItemsAndOrderingSpecification(int id, string email)
            :base(x=>x.ID==id && x.BuyerEmail==email)
        {
            AddInclude(x => x.OrderItems);
            AddInclude(x => x.DeliveryMethod);
        }
    }
}
