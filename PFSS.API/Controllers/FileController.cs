using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.GridFS;
using PFSS.API.Controllers;
using PFSS.Services.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateFileStorageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : BaseController
    {
        public FileController(ServiceWrapper serviceWrapper): base(serviceWrapper)
        {

        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Ok");
        }
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            return Ok();
        }
        [HttpPost]
        public ActionResult Upload(List<IFormFile> files)
        {
            var id = serviceWrapper.File.Upload(files[0].OpenReadStream()).Result;
            return Ok();
        }
    }
}
