using edTechSpark.APIs.Filters;
using edTechSpark.Core.Entities;
using edTechSpark.Models;
using edTechSpark.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace edTechSpark.APIs.Controllers;

[EnableCors("AllowAll")]
[Route("api/[controller]/[action]")]
[ApiController]
[CustomAuthorize]
public class OrderController : ControllerBase
{
    IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{UserId}")]
    public IEnumerable<Order> GetUserOrders(int UserId)
    {
        return _orderService.GetUserOrders(UserId);
    }

    [HttpGet("{OrderId}")]
    public OrderModel GetOrderDetails(string OrderId)
    {
        return _orderService.GetOrderDetails(OrderId);
    }
}
