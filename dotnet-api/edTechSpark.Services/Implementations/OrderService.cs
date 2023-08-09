using edTechSpark.Core.Entities;
using edTechSpark.Repositories.Interfaces;
using edTechSpark.Models;
using edTechSpark.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace edTechSpark.Services.Implementations
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IRepository<Subscription> _subsRepo;
        private readonly IConfiguration _config;
        public OrderService(IOrderRepository orderRepo, IRepository<Subscription> subsRepo, IConfiguration config): base(orderRepo)
        {
            _orderRepo = orderRepo;
            _config = config;
            _subsRepo = subsRepo;
        }

        public OrderModel GetOrderDetails(string OrderId)
        {
            var model = _orderRepo.GetOrderDetails(OrderId);
            if (model != null && model.Items.Count > 0)
            {
                decimal subTotal = 0;
                foreach (var item in model.Items)
                {
                    item.Total = item.UnitPrice * item.Quantity;
                    subTotal += item.Total;
                }
                model.Total = subTotal;
                //tax calculation
                decimal TaxRate = Convert.ToInt32(_config["Tax:TaxRate"]);
                model.Tax = Math.Round((model.Total * TaxRate) / 100, 2);
                model.GrandTotal = model.Tax + model.Total;
            }
            return model;
        }

        public IEnumerable<Order> GetUserOrders(int UserId)
        {
            return _orderRepo.GetUserOrders(UserId);
        }

        public int PlaceOrder(PaymentModel model)
        {
            Order order = new Order
            {
                PaymentId = model.PaymentId,
                UserId = model.UserId,
                CreatedDate = DateTime.Now,
                Id = model.OrderId
            };
            List<Subscription> subscriptions = new List<Subscription>();
            foreach (var item in model.Items)
            {
                OrderItem orderItem = new OrderItem { ItemId = item.ItemId, UnitPrice = item.UnitPrice, Quantity = item.Quantity, Total = item.Total };
                order.OrderItems.Add(orderItem);

                //assign subscription
                Subscription subscription = new Subscription
                {
                    UserId = model.UserId,
                    CourseId = item.ItemId,
                    SubscribedOn = DateTime.Now
                };
                subscriptions.Add(subscription);
            }
            _subsRepo.AddRange(subscriptions);
            _orderRepo.Add(order);
            return _orderRepo.SaveChanges();
        }
    }
}
