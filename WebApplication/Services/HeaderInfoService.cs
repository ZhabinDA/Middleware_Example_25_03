using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Services
{
    public class HeaderInfoService : Controller
    {
        private IHttpContextAccessor _context;

        public HeaderInfoService(IHttpContextAccessor httpContext)
        {
            _context = httpContext;
        }

        public List<string> GetHeaderInfos()
        {
            var headers = _context.HttpContext.Request.Headers.ToList();

            return headers.Select(header => $"{header.Key}:{header.Value}").ToList();
        }
    }
}
