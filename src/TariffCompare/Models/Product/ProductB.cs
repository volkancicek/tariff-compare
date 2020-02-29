namespace TariffCompare.Models.Product
{
    public class ProductB : ProductBase
    {
        public ProductB()
        {
            this.Name = "“Packaged tariff";
        }
        public override int CalculateCost(int consumption)
        {
            if (consumption <= 4000)
                return 800;

            return 800 + ((consumption - 4000) * 30 / 100);
        }
    }
}
