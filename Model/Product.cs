using System.Text.Json.Serialization;

namespace CW10B.Model;

public class Product
{
    public Guid SKU { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int Min {get; set;}
    public Product(string name, int quantity,int min)
    {
        SKU = Guid.NewGuid();
        Name = name;
        Quantity = quantity;
        Min = min;
    }
    public Product()
    {
       
    }
    
    public override string ToString()
    {
        return $"name: {Name}, quantity: {Quantity}";
    }
}