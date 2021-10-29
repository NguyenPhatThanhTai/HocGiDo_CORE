using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HocGiDo_CORE.Pages
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public JsonResult About()
        {
            return new JsonResult(new { 
                status = true,
                code = "200"
            });
        }
    }
}
