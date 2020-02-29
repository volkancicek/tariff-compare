using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TariffCompare.Models;
using TariffCompare.Services;

namespace TariffCompare.Controllers
{
    [ApiController]
    [Route("api/tariff")]
    public class TariffController : ControllerBase
    {

        private readonly ILogger<TariffController> _logger;
        private readonly ITariffService _tariffService;

        public TariffController(ILogger<TariffController> logger, ITariffService tariffService)
        {
            _logger = logger;
            _tariffService = tariffService;
        }

        [HttpGet]
        [Route("{consumption:int}")]
        public IEnumerable<TariffModel> Get(int consumption)
        {
            var result = _tariffService.GetTariffs(consumption);
            foreach (var product in result.OrderBy(p => p.AnnualCost))
            {
                yield return product;
            }
        }
    }
}
