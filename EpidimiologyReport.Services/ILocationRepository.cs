using EpidimiologyReport.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EpidimiologyReport.Services
{
    public interface ILocationRepository
    {
        Task<List<Location>> Get(LocationSearch locationSearch);
    }
}
