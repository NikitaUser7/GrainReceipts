using GrainTWdata.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GrainTWdata.Controllers
{
    [ApiController]
    [Route("Test")]
    public class TestController : ControllerBase
    {
        //    [AllowAnonymous]
        //    [HttpPost("tt")]
        //    public async Task<IActionResult> tt(IFormFile file)
        //    {
        //        GrainTwContext db = new GrainTwContext();
        //        var a = db.TblGrainReceipts?.FirstOrDefault()?.Price.ToString();
        //        return new OkResult();

        //    }

        [AllowAnonymous]
        [HttpPost("tt")]
        public async Task<IActionResult> tt()
        {
            TextReader tr = new StreamReader(Request.Body);
            string json = await tr.ReadToEndAsync();
            tr.Dispose();

            //GrainTwContext db = new GrainTwContext();
            //var a = db.TblGrainReceipts?.FirstOrDefault()?.Price.ToString();
            return new OkResult();

        }

        [AllowAnonymous]
        [HttpGet("ok")]
        public string Ok() => "All ok";
    }
}
