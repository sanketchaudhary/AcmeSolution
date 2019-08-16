using Acme.Api.Controllers;
using Acme.Business.Dtos.Investor;
using Acme.Business.Manager;
using Acme.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Acme.UnitTest.Controllers
{
    public class InvestorControllerTest
    {
        #region Private variables
        private readonly Mock<IMapper> mockMapper;
        private readonly Mock<IInvestorManager> mockInvestorManager;
        private readonly InvestorController investorController;
        #endregion

        public InvestorControllerTest()
        {
            mockMapper = new Mock<IMapper>();
            mockInvestorManager = new Mock<IInvestorManager>();

            investorController = new InvestorController(mockMapper.Object, mockInvestorManager.Object);
        }

        /// <summary>
        /// Test case for CreateNewInvestor Success scenario
        /// </summary>
        [Fact]
        public void CreateNewInvestorSuccess()
        {
            // Arrange
            mockInvestorManager.Setup(k => k.AddInvestor(It.IsAny<InvestorDetails>()));
            mockMapper.Setup(m => m.Map<InvestorDetails>(It.IsAny<InvestorDtoForCreate>())).Returns(new InvestorDetails() { Id = 1, CountryId = 1001, FullName = "Sanket Chaudhary", Postcode = "2150", State = "NSW" });

            // Act
            var result = Assert.IsType<OkObjectResult>(investorController.Create(new InvestorDtoForCreate() { FullName = "Sanket Chaudhary", CountryId = 1001, Postcode = "2150", State = "NSW" }));

            // Assert
            Assert.Equal(200, result.StatusCode);
        }
    }
}
