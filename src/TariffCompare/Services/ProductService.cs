using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffCompare.Models.Product;

namespace TariffCompare.Services
{

    public interface IProductService
    {
        public List<ProductBase> GetProducts();
    }

    public class ProductService : IProductService
    {
        public List<ProductBase> GetProducts()
        {
            return new List<ProductBase>() { new ProductA(), new ProductB() };
        }
    }
}
