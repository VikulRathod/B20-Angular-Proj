using edTechSpark.Services.Interfaces;
using edTechSpark.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using edTechSpark.Core.Entities;

namespace edTechSpark.APIs.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult CreateUser(UserSignUpModel model)
        {
            User user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                CreatedDate = DateTime.Now
            };
            bool result = _authService.CreateUser(user, model.Role);
            if (result)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        public UserModel ValidateUser(LoginModel model)
        {
            return _authService.ValidateUser(model.Username, model.Password);
        }
    }
}
