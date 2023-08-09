
using edTechSpark.Core.Entities;
using edTechSpark.Services.Interfaces;
using edTechSpark.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using edTechSpark.APIs.Filters;

namespace edTechSpark.APIs.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CustomAuthorize]
    public class PaymentController : ControllerBase
    {
        IPaymentService _paymentService;
        IOrderService _orderService;
        public PaymentController(IPaymentService paymentService, IOrderService orderService)
        {
            _paymentService = paymentService;
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult CreateOrder(RazorPayOrderModel razorPayOrder)
        {
            string orderId = _paymentService.CreateOrder(razorPayOrder.GrandTotal * 100, razorPayOrder.Currency, razorPayOrder.Receipt);
            if (string.IsNullOrEmpty(orderId))
                return StatusCode(StatusCodes.Status500InternalServerError);
            else
                return Ok(new { orderId = orderId });
        }

        [HttpPost]
        public IActionResult SavePaymentDetails(PaymentModel model)
        {
            bool IsSignVerified = _paymentService.VerifySignature(model.Signature, model.OrderId, model.PaymentId);
            var paymentDetails = _paymentService.GetPaymentDetails(model.PaymentId);
            if (IsSignVerified && paymentDetails != null)
            {
                PaymentDetail payment = new PaymentDetail();

                payment.CartId = model.CartId;
                payment.Total = model.Total;
                payment.Tax = model.Tax;
                payment.GrandTotal = model.GrandTotal;
                payment.CreatedDate = DateTime.Now;

                payment.Status = paymentDetails.Attributes["status"]; //captured
                payment.Currency = model.Currency;
                payment.Email = model.Email;
                payment.Id = model.PaymentId;
                payment.UserId = model.UserId;
                
                int status = _paymentService.SavePaymentDetails(payment);
                if (status > 0)
                {
                    _orderService.PlaceOrder(model);
                    ReceiptModel receipt = new ReceiptModel { PaymentId = model.PaymentId, Currency = model.Currency, GrandTotal = model.GrandTotal, Email = model.Email, Status = payment.Status };
                    return Ok(receipt);
                }
                else
                {
                    return Ok();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
