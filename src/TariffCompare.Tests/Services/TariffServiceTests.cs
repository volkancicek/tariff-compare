using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using TariffCompare.Models;
using TariffCompare.Models.Product;
using TariffCompare.Services;
using Xunit;

namespace TariffCompare.Tests.Services
{
    public class TariffServiceTests
    {
        private readonly ITariffService _tariffService;
        private readonly Mock<IProductService> _mockProductService;
        public TariffServiceTests()
        {
            _mockProductService = new Mock<IProductService>();
            _tariffService = new TariffService(_mockProductService.Object);
        }

        [Fact]
        public void Should_get_tariff_results()
        {
            var expected = new List<TariffModel>()
                {
                    new TariffModel(){AnnualCost = 280, TariffName = "basic electricity tariff"},
                    new TariffModel(){AnnualCost = 800, TariffName = "Packaged tariff"}
                };
            var products = new List<ProductBase>() { new ProductA(), new ProductB() };
            _mockProductService.Setup(p => p.GetProducts()).Returns(products);
            var result = _tariffService.GetTariffs(1000);

            Assert.Contains(result, x => x.TariffName == "basic electricity tariff" && x.AnnualCost == 280);
            Assert.Contains(result, x => x.TariffName == "Packaged tariff" && x.AnnualCost == 800);
            _mockProductService.Verify(x => x.GetProducts(), Times.Once);
        }
    }
}
