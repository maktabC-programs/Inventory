using CW10B.Model;

namespace CW10B.Repository;

public interface IProductRepository
{
    public void Create(string name , int quantity,int min);
    public void Update(string name, int quantity);
    public void DeleteByName(string name);
    public IReadOnlyList<Product> GetAll();
    public Product GetByName(string name);
    public bool ContainsName(string name);
}