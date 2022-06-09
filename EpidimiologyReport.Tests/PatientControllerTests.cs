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
    public class PatientControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Mock<IPatientRepository> _mockRepo;
        private readonly PatientController _controller;
        public PatientControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _mockRepo = new Mock<IPatientRepository>();
            _controller = new  PatientController(_mockRepo.Object, NullLogger<PatientController>.Instance);
        }
        [Fact]
        public async void GetPatient_ById_ReturnPatient()
        {
            string mockID = "212864797";

            _mockRepo.Setup(l => l.Get(mockID)).Returns(Task.FromResult(new Patient() { PatientId=mockID}));
            
            var result = await _controller.Get(mockID);

            Assert.True(result != null);
            Assert.Equal(result.PatientId,mockID);
        }

        [Fact]
        public async void SavePatient_ValidCall()
        {
            Patient  concretePatient = GetPatient();

            _mockRepo.Setup(p => p.Save(concretePatient));

            await _controller.Save(concretePatient);

            _mockRepo.Verify(x => x.Save(concretePatient), Times.Exactly(1));
             
        }

        public Patient GetPatient()
        {
            return new Patient()
            {
                PatientId = "212864797",
                Locations = null
            };
        }
           
      

    }

}
