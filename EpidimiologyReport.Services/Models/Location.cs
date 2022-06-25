using System;
namespace EpidimiologyReport.Services.Models
{
    public class Location
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PatientId { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;

        public Location(string city, DateTime start, DateTime end, string address, string patientId)
        {
            this.City = city;
            this.StartDate = start;
            this.EndDate = end;
            this.Address = address;
            this.PatientId = patientId;
        }

        public Location()
        {

        }
    }
}