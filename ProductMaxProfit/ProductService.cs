using ProductMaxProfit.Classes;

namespace ProductMaxProfit
{
    public class ProductService
    {
        public static List<Product> GetProducts()
        {
            var materialQtd = 4;
            var productQtd = 2;
            Random randObj = new Random();

            var materials = MaterialService.GetMaterials(materialQtd);
            List<Product> products = new List<Product>();

            for (int i = 1; i <= productQtd; i++)
            {
                var prod = new Product()
                {
                    Name = "Produto-" + i
                };
                var qtdMaterials = randObj.Next(1, materialQtd);

                for (int j = 0; j < qtdMaterials; j++)
                {
                    int rdmInt = GetRandomNotExists(materialQtd, prod.Materials);
                    var mt = materials[rdmInt-1];
                    prod.Materials.Add(new ProductMaterial()
                    {
                        MaterialID = mt.ID,
                        MaterialName = mt.Name,
                        Quantity = randObj.Next(1, mt.Quantity / 2)
                    });
                }

                products.Add(prod);
            }
            
            return products;
        }

        private static int GetRandomNotExists(int materialQtd, List<ProductMaterial> materials)
        {
            Random randObj = new Random();
            int number = materials.FirstOrDefault()?.MaterialID ?? 1;
            while (materials.Any(x=> x.MaterialID == number))
            {
                number = randObj.Next(1, materialQtd);
            }
            return number;
        }
    }
}
