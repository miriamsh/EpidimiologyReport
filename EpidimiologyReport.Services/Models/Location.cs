using System;
namespace EpidimiologyReport.Services.Models
{
    public class Location
    {
        public string City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LocationPlace { get; set; }

        public Location(string city, DateTime start, DateTime end, string place)
        {
            this.City = city;
            this.StartDate = start;
            this.EndDate = end;
            this.LocationPlace = place;
        }

        public Location()
        {

        }
    }
}