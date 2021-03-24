using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("Header")]
    public class HeaderInfoController : Controller
    {
        private HeaderInfoService _service;

        public HeaderInfoController(HeaderInfoService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<string> Get()
        {
            return _service.GetHeaderInfos();
        }
    }
}
