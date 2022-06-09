using Newtonsoft.Json;
using EpidimiologyReport.Services;
using EpidimiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidimiologyReport.Dal
{
    public class PatientRepository : IPatientRepository
    {
        public List<Patient> Patients { get; set; }
        private const string DataPath = "C:/Users/מירי/source/repos/EpidimiologyReport/ProjectDAL/Data/users.json";

        public PatientRepository()
        {
            using (StreamReader reader = System.IO.File.OpenText(DataPath))
            {
                Patients = JsonConvert.DeserializeObject<List<Patient>>(reader.ReadToEnd());
            }
        }
        public async Task<Patient> Get(string id)
        {
            List<Patient> users = Patients;

            Patient patient = users.First(user => user.PatientId.Equals(id));

            return patient;
        }

        public async Task Save(Patient patient)
        {
            List<Patient> users = Patients;
           
            users.Add(patient);
           
            string json = JsonConvert.SerializeObject(users);

            System.IO.File.WriteAllText(DataPath, json);
            
        }
    }
}
