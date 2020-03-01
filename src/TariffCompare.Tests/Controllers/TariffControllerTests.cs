using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TariffCompare.Controllers;
using TariffCompare.Models;
using TariffCompare.Services;
using Xunit;

namespace TariffCompare.Tests.Controllers
{
    public class TariffControllerTests
    {
        private readonly TariffController _controller;
        private readonly Mock<ITariffService> _mockTariffService;
        public TariffControllerTests()
        {
            _mockTariffService = new Mock<ITariffService>();
            _controller = new TariffController(_mockTariffService.Object);
        }

        [Fact]
        public void Should_get_tariff_results()
        {
            var mockResult = new List<TariffModel>()
                {new TariffModel() {AnnualCost = 800, TariffName = "test tariff"}};
            _mockTariffService.Setup(t => t.GetTariffs(It.IsAny<int>())).
                Returns(mockResult);
            var result = _controller.Get(1000);
            Assert.NotNull(result);
            Assert.Equal(mockResult, result);
            _mockTariffService.Verify(x => x.GetTariffs(1000), Times.Once);
        }
    }
}
