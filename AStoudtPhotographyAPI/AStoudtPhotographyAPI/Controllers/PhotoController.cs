using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AStoudtPhotographyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {

        private IConfiguration _configuration;
        public PhotoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetPhoto")]
        public IActionResult GetPhoto() 
        {
            var builder = new SqlConnectionStringBuilder
            {
            };
        }

        [HttpPost]
        [Route("AddPhoto")]
        public IActionResult PostPhoto() 
        { 

        }
    }
}
