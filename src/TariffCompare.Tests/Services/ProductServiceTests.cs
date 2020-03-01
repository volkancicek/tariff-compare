using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using TariffCompare.Models.Product;
using TariffCompare.Services;
using Xunit;

namespace TariffCompare.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly IProductService _productService;

        public ProductServiceTests()
        {
            _productService = new ProductService();
        }

        [Fact]
        public void Should_get_products()
        {
            var products = new List<ProductBase>() { new ProductA(), new ProductB() };
            var results = _productService.GetProducts();
            Assert.Equal(products[0].Name, results[0].Name);
            Assert.Equal(products[1].Name, results[1].Name);
        }
    }
}
