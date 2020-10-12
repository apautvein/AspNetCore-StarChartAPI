using System.Collections.Generic;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using StarChart.Data;
using StarChart.Models;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            CelestialObject celestialObject = new CelestialObject();
            celestialObject.Name = "GetById";
            if (celestialObject.OrbitedObjectId == id)
            {
                celestialObject.Satellites.Add(celestialObject);  
            }
            if (celestialObject.Id != id)
            {
                return NotFound(); 
            } else
            {
                return Ok(); 
            }
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            CelestialObject celestialObject = new CelestialObject();
            if (celestialObject.OrbitedObjectId == celestialObject.Id)
            {
                celestialObject.Satellites.Add(celestialObject);
            }
            if (celestialObject.Name != name)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            CelestialObject celestialObject = new CelestialObject();
            if (celestialObject.OrbitedObjectId == celestialObject.Id)
            {
                celestialObject.Satellites.Add(celestialObject);
            }
                return Ok();
           
        }
    }
}
