using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class OrderModel
    {
        public OrderModel(int orderId, string owner)
        {
            OrderId = orderId;
            Owner = owner;
        }

        public int OrderId { get; set; }

        public string Owner { get; set; }
    }
}
