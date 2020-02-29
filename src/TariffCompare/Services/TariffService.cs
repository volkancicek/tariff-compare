using System.Collections.Generic;
using System.Linq;
using TariffCompare.Models;

namespace TariffCompare.Services
{

    public interface ITariffService
    {
        IEnumerable<TariffModel> GetTariffs(int consumption);
    }
    public class TariffService : ITariffService
    {
        private readonly IProductService _productService;
        public TariffService(IProductService productService)
        {
            _productService = productService;
        }
        public IEnumerable<TariffModel> GetTariffs(int consumption)
        {
            var products = _productService.GetProducts();
            return products.Select(p => new TariffModel()
            {
                TariffName = p.Name,
                AnnualCost = p.CalculateCost(consumption)
            });
        }
    }
}
