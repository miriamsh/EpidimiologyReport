using EpidimiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EpidimiologyReport.Services
{
    public interface IPatientRepository
    {
       Task<Patient> Get(string id);

        Task Save(Patient patient);
    }
}
