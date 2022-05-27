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

        IPatientRepository _patientRepository;
        public  PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;

        }
        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public async Task<Patient> Get(string id)
        {
            return await _patientRepository.Get(id);
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task Save([FromBody] Patient patient)
        {
           await _patientRepository.Save(patient);
        }


     
    }
}
