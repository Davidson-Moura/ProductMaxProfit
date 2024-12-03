namespace ProductMaxProfit.Classes
{
    public class Product
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public List<ProductMaterial> Materials { get; set; } = new List<ProductMaterial>();
    }
    public class ProductMaterial
    {
        public int MaterialID { get; set; }
        public int Quantity { get; set; }
        public string? MaterialName { get; set; }
    }
}
