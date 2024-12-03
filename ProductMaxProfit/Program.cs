using ProductMaxProfit.Classes;
using ProductMaxProfit;

var materials = MaterialService.GetMaterials(2);
var products = new List<Product>() {
    new Product(){
        Name = "x1",
        Price = 20m
    },
    new Product(){
        Name = "x2",
        Price = 30m
    }
};
products[0].Materials.Add(new ProductMaterial() {
    MaterialID = materials[0].ID,
    MaterialName = materials[0].Name,
    Quantity = 1
});
products[0].Materials.Add(new ProductMaterial()
{
    MaterialID = materials[1].ID,
    MaterialName = materials[1].Name,
    Quantity = 2
});
products[1].Materials.Add(new ProductMaterial()
{
    MaterialID = materials[0].ID,
    MaterialName = materials[0].Name,
    Quantity = 2
});
products[1].Materials.Add(new ProductMaterial()
{
    MaterialID = materials[1].ID,
    MaterialName = materials[1].Name,
    Quantity = 1
});

materials[0].Quantity = 20;
materials[1].Quantity = 30;

//var products = ProductService.GetProducts();

//max z = 20x1 + 30x2
//x1 + 2x2 <= 20
//2x1 + x2 <= 30

//Modelo de PL
/*
    |z  | x1| x2| s1| s2|
   z|  1|-20|-30|  0|  0|
  x1|  0|  1|  2|  1|  0|
  x2|  0|  2|  1|  0|  1|
*/

var qtdRestrictions = 2;
var lines = qtdRestrictions + 1;
var collumns = products.Count + qtdRestrictions + 2;

var mtz = new decimal[lines, collumns];

for (int l = 0; l < lines; l++)
{
    var material = l > 0 ? materials[l -1] : null;
    for (int c = 0; c < collumns; c++)
    {
        if (c <= 0) //Coluna de de z
        {
            mtz[l, 0] =
                l == 0 ?
                1 : 0;
            continue;
        }
        else if (l == 0 && c == collumns - 1) //valor de z
        {
            mtz[l, c] = 0;
        }
        else if (c <= products.Count) //Colunas dos produtos
        {
            var product = products[c - 1];
            if (l == 0)
            {
                mtz[0, c] = -product.Price;
                continue;
            }
            else if (material is not null)
            {
                var pm = product.Materials.FirstOrDefault(x => x.MaterialID == material.ID);
                mtz[l, c] = pm.Quantity;
                continue;
            }
        }
        //Colunas restrições
        else if (c - products.Count == l) mtz[l, c] = 1;
        //Quantidade de cada recurso
        else if (c == collumns - 1 && l > 0) mtz[l, c] = material.Quantity;
        else mtz[l, c] = 0;
    }
}

mtz.PrintMtz(lines, collumns);

Console.ReadKey();