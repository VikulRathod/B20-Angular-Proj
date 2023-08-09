using edTechSpark.APIs.Filters;
using edTechSpark.Core.Entities;
using edTechSpark.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace edTechSpark.APIs.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CustomAuthorize]
    public class MentorController : ControllerBase
    {
        IMentorService _mentorService;
        public MentorController(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        [HttpGet]
        public IEnumerable<Mentor> GetAll()
        {
            return _mentorService.GetAllMentors();
        }

        [HttpGet("{id}")]
        public Mentor Get(int id)
        {
            return _mentorService.Find(id);
        }

        [HttpPost]
        public IActionResult Add(Mentor model)
        {
            try
            {
                _mentorService.Add(model);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Mentor model)
        {
            try
            {
                if (id != model.Id)
                    return BadRequest();

                _mentorService.Update(model);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _mentorService.Delete(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
