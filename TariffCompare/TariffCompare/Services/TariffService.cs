using System.Collections.Generic;
using TariffCompare.Models;

namespace TariffCompare.Services
{
    public interface ITariffService
    {
        IEnumerable<TariffModel> CompareTariffs(int consumption);
    }
    public class TariffService : ITariffService
    {
        public IEnumerable<TariffModel> CompareTariffs(int consumption)
        {
            return null;
        }
    }
}
