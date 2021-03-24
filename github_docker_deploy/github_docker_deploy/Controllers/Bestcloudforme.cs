using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace github_docker_deploy.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class Bestcloudforme : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Bestcloudforme(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult welcome()
        {
            return Ok(new { firstname = "Hasan", lastname = "Sahin" });
        }
        [HttpGet]
        public IActionResult whoami(string firstname, string lastname)
        {
            return Ok(new { firstname, lastname });
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult alert([FromBody] object obj)
        {
            using (var client = _httpClientFactory.CreateClient("api"))
            {
                client.PostAsync("56eae293-8a60-4555-9601-b559e7593409", obj.ToHttpContent());
            }
            return Ok(obj);
        }



    }

    public static class Helper{
        public static string ToJson(this object obj) => JsonSerializer.Serialize(obj);
        public static StringContent ToHttpContent(this object obj) => new StringContent(obj.ToJson(), Encoding.UTF8, "application/json");
    }
}
