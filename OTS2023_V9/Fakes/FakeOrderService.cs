using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTS2023_V9.Models;
using OTS2023_V9.Services;

namespace OTS2023_V9.Fakes
{
    public class FakeOrderService : IOrderService
    {
        public List<Order> Orders { get; set; }
        public double UpdateTotalDifference { get; set; }

        public FakeOrderService()
        {
            Orders = new List<Order>();
        }

        public Order GetOrderById(Guid id)
        {
            return Orders[0];
        }

        public List<Order> GetUserOrdersWithDeadlineBetween(Guid userId, DateTime monthBefore, DateTime now)
        {
            List<Order> deadlineOrders = new List<Order>();

            for (int i = 0; i < Orders.Count; i++)
            {
                var o = Orders[i];
                if (o.CustomerId == userId && o.OrderDeadlineDate >= monthBefore && o.OrderDeadlineDate <= now)
                {
                    deadlineOrders.Add(o);
                }
            }

            return deadlineOrders;
        }

    }
}
