using ImageUpload.Repository;
using ImageUpload.view;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IUpload upload;
        public ValuesController(IUpload obj)
        {
            upload = obj;
        }

        [HttpPost]
        [Route("UploadFile")]
        public IActionResult UploadFile([FromForm] FileUploadAPI file)
        {
            var obj = upload.UploadData(file);
            return Ok(obj);

        }


    }
}
