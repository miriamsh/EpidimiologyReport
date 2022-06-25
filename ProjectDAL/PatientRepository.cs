using Newtonsoft.Json;
using EpidimiologyReport.Services;
using EpidimiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpidimiologyReport.Dal.Models;

namespace EpidimiologyReport.Dal
{
    public class PatientRepository : IPatientRepository
    {
         ReportingContext _context;

        public PatientRepository(ReportingContext context)
        {
            _context = context;
        }
        public async Task<Patient> Get(string id)
        {
            Patient patient = _context.Patients.First(user => user.Id.Equals(id));
            return patient;
        }

        public async Task Save(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }
    }
}
