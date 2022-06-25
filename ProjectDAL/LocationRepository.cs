using EpidimiologyReport.Services;
using EpidimiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using EpidimiologyReport.Dal.Models;

namespace EpidimiologyReport.Dal
{
    public class LocationRepository:ILocationRepository
    {

         ReportingContext _context;


        public LocationRepository(ReportingContext context)
        {
            _context = context;
        }

        public async Task<List<Location>> Get(LocationSearch locationSearch)
        { 
            if(locationSearch.City!="")
               return _context.Locations.Where(l => l.City.Equals(locationSearch.City)).ToList();
            return _context.Locations.ToList();
        }

        public async Task Save(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
        }
    }
}
