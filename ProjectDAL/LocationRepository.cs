using EpidimiologyReport.Services;
using EpidimiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace EpidimiologyReport.Dal
{
    public class LocationRepository:ILocationRepository
    {

        public List<Patient> Patients { get; set; }
        private const string DataPath="C:/Users/מירי/source/repos/EpidimiologyReport/ProjectDAL/Data/users.json";

        public LocationRepository()
        {

            using (StreamReader reader = System.IO.File.OpenText(DataPath))
            {
                Patients = JsonConvert.DeserializeObject<List<Patient>>(reader.ReadToEnd());
            }


        }

        public async Task<List<Location>> Get(LocationSearch locationSearch)
        {
            List<Location> locations = new List<Location>();
            List<Patient> users = this.Patients;

            foreach (Patient _user in users)
            {
                locations.AddRange(_user.Locations);
            }
            if(locationSearch.City!="")
               return locations.Where(l => l.City.Equals(locationSearch.City)).ToList();
            return locations;
        }
    }
}
