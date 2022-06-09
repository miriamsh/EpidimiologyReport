using Autofac.Extras.Moq;
using EpidimiologyReport.Api.Controllers;
using EpidimiologyReport.Services;
using EpidimiologyReport.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EpidimiologyReport.Tests
{
    public class LocationControllerTests :IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Mock<ILocationRepository> _mockRepo;
        private readonly LocationController _controller;
        public LocationControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _mockRepo = new Mock<ILocationRepository>();
            _controller = new LocationController(_mockRepo.Object, NullLogger<LocationController>.Instance);
        }
        [Fact]
        public async void GetLocation_ByCity_ReturnLoactionList()
        {

            //_mockRepo.Setup(l => l.Get(GetSearchObject())).Returns(Task.FromResult(GetFilteredList()));

            //var result = await _controller.Get(GetSearchObject());

            //var expected = GetFilteredList();

            //Assert.True(result != null);
            //Assert.Equal(result.Count, expected.Count );

            
            using (var mock=AutoMock.GetLoose())
            {
                LocationSearch location = GetSearchObject();

                mock.Mock<ILocationRepository>()
                    .Setup(x => x.Get(location))
                    .Returns(Task.FromResult(GetFilteredList()));

                var cls = mock.Create<LocationController>();

                var result = await cls.Get(location);

                var expected = GetFilteredList();

                Assert.True(result != null);
                Assert.Equal(expected.Count, result.Count);
            }

        }

        private LocationSearch GetSearchObject()
        {
            return new LocationSearch() { City = "" };
        }

        private List<Location> GetFilteredList()
        {
            return new  List<Location>();
        }
    }
}
