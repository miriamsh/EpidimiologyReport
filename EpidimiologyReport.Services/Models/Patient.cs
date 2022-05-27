using System;
namespace EpidimiologyReport.Services.Models
{
    public class Patient
    {
        public string PatientId { get; set; }


        public List<Location> Locations { get; set; }

        public Patient()
        {

        }
        public Patient(string patientId, List<Location> locations)
        {
            this.PatientId = patientId;
            this.Locations = locations;
        }
    }
}