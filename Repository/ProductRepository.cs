using System.Text.Json;
using CW10B.Model;

namespace CW10B.Repository;

public class ProductRepository : IProductRepository
{
    public static readonly string ProductPath = "Product.json";
    private List<Product> _products;

    public ProductRepository()
    {
        Load();
    }

    public void Create(string name, int quantity, int min)
    {
        bool exists = false;
        foreach (var pro in _products)
        {
            if (pro.Name == name)
            {
                exists = true;
                break;
            }
        }

        if (!exists)
        {
            _products.Add(new Product { Name = name, Quantity = quantity, Min = min });
            File.WriteAllText(ProductPath, JsonSerializer.Serialize(_products));
            return;
        }

        throw new Exception("Product already exists");
    }

    public void Update(string name, int quantity)
    {
        Product found = null;
        foreach (var pro in _products)
        {
            if (pro.Name == name)
            {
                found = pro;
                break;
            }
        }

        if (found != null)
        {
            found.Quantity = quantity;
            Save();
            return;
        }

        throw new Exception("Product does not exist");
    }

    public void DeleteByName(string name)
    {
        var newList = new List<Product>();
        bool removed = false;

        foreach (var pro in _products)
        {
            if (pro.Name == name)
                removed = true;
            else
                newList.Add(pro);
        }

        if (!removed)
            throw new Exception("Product does not exist");

        _products = newList;
        Save();
    }

    public IReadOnlyList<Product> GetAll()
    {
        return _products;
    }

    public Product GetByName(string name)
    {
        foreach (var pro in _products)
        {
            if (pro.Name == name)
                return pro;
        }

        throw new Exception("Product does not exist");
    }

    public bool ContainsName(string name)
    {
        foreach (var pro in _products)
        {
            if (pro.Name == name)
                return true;
        }
        return false;
    }

    private void Save()
    {
        string listJson = JsonSerializer.Serialize(_products);
        File.WriteAllText(ProductPath, listJson);
    }

    private void Load()
    {
        if (File.Exists(ProductPath))
        {
            string listJson = File.ReadAllText(ProductPath);
            try
            {
                var products = JsonSerializer.Deserialize<List<Product>>(listJson);
                if (products != null)
                    _products = products;
                else
                {
                    _products = new List<Product>();
                }
            }
            catch
            {
                _products = new List<Product>();
            }
        }
        else
        {
            _products = new List<Product>();
            Save();
        }
    }
}