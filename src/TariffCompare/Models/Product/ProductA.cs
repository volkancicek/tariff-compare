namespace TariffCompare.Models.Product
{
    public class ProductA : ProductBase
    {
        private const int BaseCost = 12 * 5;
        public ProductA()
        {
            Name = "basic electricity tariff";
        }

        public override int CalculateCost(int consumption)
        {
            return BaseCost + (consumption * 22 / 100);
        }
    }
}
