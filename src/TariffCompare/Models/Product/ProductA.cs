namespace TariffCompare.Models.Product
{
    public class ProductA : ProductBase
    {
        public ProductA()
        {
            this.Name = "basic electricity tariff";
        }

        public override int CalculateCost(int consumption)
        {
            var baseCost = 12 * 5;
            return baseCost + (consumption * 22 / 100);
        }
    }
}
