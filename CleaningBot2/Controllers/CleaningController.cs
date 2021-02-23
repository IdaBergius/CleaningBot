using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CleaningBot.Core.Services;
using CleaningBot.Core.Models;
using CleaningBot.Infra;
using CleaningBot.Infra.Data.Repositories;

namespace CleaningBot2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CleaningController : ControllerBase
    {
        protected const string BaseUrl = "http://tibber-developer-test/enter-path";
        private readonly CleaningRepository cleaningRepository = new CleaningRepository(""); 

        [HttpGet("/{id}")]
        public ActionResult<string> GetById(int id)
        {
           return cleaningRepository.GetById(id);
             
        }

        [HttpPost("instructions")]
        public void Post([FromBody]Instruction instructions) 
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
            };
           cleaningRepository.Save(instructions);
        }

        private StringContent JsonBody<T>(T body)
        {
            var json = JsonConvert.SerializeObject(body);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
