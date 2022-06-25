using System;
namespace EpidimiologyReport.Services.Models
{
    public class Patient
    {
        public string Id { get; set; } = null!;

        public Patient()
        {

        }
        public Patient(string patientId)
        {
            this.Id = patientId;
        }
    }
}