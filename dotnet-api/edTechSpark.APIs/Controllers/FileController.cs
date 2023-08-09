using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using edTechSpark.APIs.Helpers;
using edTechSpark.APIs.Filters;

namespace edTechSpark.APIs.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CustomAuthorize]
    public class FileController : ControllerBase
    {
        IFileHelper _fileHelper;
        public FileController(IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var formCollection = Request.ReadFormAsync().Result;
                var file = formCollection.Files.First();

                var dbPath = _fileHelper.UploadFile(file);
                return Ok(new { dbPath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpDelete]
        public IActionResult DeleteFile(string imageUrl)
        {
            _fileHelper.DeleteFile(imageUrl);
            return Ok();
        }
    }
}
