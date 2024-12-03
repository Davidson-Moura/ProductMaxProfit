
using ProductMaxProfit.Classes;

namespace ProductMaxProfit
{
    public class MaterialService
    {
        public static List<Material> GetMaterials(int quantity = 4)
        {
            var materials = new List<Material>();

            Random randObj = new Random();

            for (int i = 1; i <= quantity; i++)
            {
                materials.Add(new Material()
                {
                    ID = i,
                    Name = "Material-" + i,
                    Quantity = randObj.Next(1,20)
                });
            }

            return materials;
        }
    }
}
