using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAPI.Controllers
{
    [Route("api/v1/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private AnimalsService _animalsService;

        public AnimalController(AnimalsService animalsService)
        {
            _animalsService = animalsService;
        }

        [Route("random")]
        [HttpGet]
        public ActionResult GetRandomAnimal()
        {
            return Ok(_animalsService.Random());
        }
    }
}
