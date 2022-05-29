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
        public readonly ILogger _logger;

        public readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository, ILogger<LocationController> logger)
        {
            _locationRepository = locationRepository;
            _logger = logger;
            
        }
        
        // GET: api/<LocationController>
        [HttpGet]
        public async Task<List<Location>> Get([FromQuery] string? locationSearch="")
        {
            LocationSearch locationSearch1 = new LocationSearch();
            locationSearch1.City = locationSearch;
            _logger.LogInformation("enter to Get function in LocatientController");
           return await _locationRepository.Get(locationSearch1);
        }

     

      
    }
}
