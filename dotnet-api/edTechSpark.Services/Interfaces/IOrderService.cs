using edTechSpark.Core.Entities;
using edTechSpark.Models;
using System.Collections.Generic;

namespace edTechSpark.Services.Interfaces
{
    public interface IOrderService: IService<Order>
    {
        OrderModel GetOrderDetails(string OrderId);
        IEnumerable<Order> GetUserOrders(int UserId);
        int PlaceOrder(PaymentModel model);
    }
}
