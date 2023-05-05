using Data.Models;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace URLShorter.Controllers
{
    [Route("api/url")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        private readonly IUrlService _urlService;
        public UrlsController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet("get")]
        public ActionResult Get()
        {
            return new JsonResult(_urlService.Get());
        }

        [HttpGet("{link}")]
        public ActionResult Get(string link)
        {
            var test = new JsonResult(_urlService.Get(link));
            return test;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<ActionResult> Create(Url url)
        {
            return new JsonResult(await _urlService.CreateAsync(url));
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _urlService.Delete(id);
        }
    }
}
