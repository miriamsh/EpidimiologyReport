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
    public class PatientController : ControllerBase 
    {
        public readonly ILogger _logger;

        public readonly IPatientRepository _patientRepository;
        public  PatientController(IPatientRepository patientRepository, ILogger<PatientController> logger)
        {
            _patientRepository = patientRepository;
            _logger = logger;

        }
        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public async Task<Patient> Get(string id)
        {
            _logger.LogInformation("enter to Get function in PatientController with id: " + id);
            return await _patientRepository.Get(id);
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task Save([FromBody] Patient patient)
        {
            _logger.LogInformation("enter to Post function in PatientController with patient id: " + patient.PatientId);
           await _patientRepository.Save(patient);
        }


     
    }
}
