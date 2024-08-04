using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.Data;
using dotnet_webapi_ef.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_ef.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public  DestinationController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll(){
            var Destinations = _context.Destinations.Select(d => d.ToDestinationDTO());
            return Ok(Destinations);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            var Destination = _context.Destinations.Find(id);
            if (Destination == null)
            {
                return NotFound();
            }
            return Ok(Destination.ToDestinationDTO());
        }
    }
}