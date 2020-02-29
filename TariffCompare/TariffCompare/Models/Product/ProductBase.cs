namespace TariffCompare.Models.Product
{
    public abstract class ProductBase
    {
        public string Name { get; set; }
        public abstract int CalculateCost(int consumption);
    }
}
