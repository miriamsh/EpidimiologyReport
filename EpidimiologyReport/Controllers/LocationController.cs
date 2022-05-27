using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpidimiologyReport.Services;
using EpidimiologyReport.Services.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EpidimiologyReport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase 
    {
        ILocationRepository _locationRepository;
        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
            
        }
        
        // GET: api/<LocationController>
        [HttpGet]
        public async Task<List<Location>> Get([FromQuery] EpidimiologyReport.Services.Models.LocationSearch locationSearch=null)
        {
           return await _locationRepository.Get(locationSearch);
        }

     

      
    }
}
