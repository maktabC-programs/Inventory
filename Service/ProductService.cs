using CW10B.Logger;
using CW10B.Model;
using CW10B.Repository;

namespace CW10B.Service;

    public class ProductService
   { 
        private ILogger _logger;
        private IProductRepository _productRepository;

        public ProductService(ILogger logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }
    

    public void AddProduct( string name, int quantity,int min)
    {
        _productRepository.Create(name, quantity,min);
    }

    public void ReceiveGoods(string name,int quantity)
    {
        try
        {
            var product = _productRepository.GetByName(name);
            _productRepository.Update(name, product.Quantity +  quantity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        
    }


    public IReadOnlyList<Product> GetLowCountProducts()
    {
        var list = new List<Product>();
        foreach (var product in _productRepository.GetAll())
        {
            if (product.Quantity < product.Min)
                list.Add(product);
            
        }
        return list;
        
    }
    

    public void DeleteProduct(string name)
    {
        _productRepository.DeleteByName(name);
    }

    public void DispatchGoods(string name, int quantity)
    {
        try
        {
            var product = _productRepository.GetByName(name);
            if (quantity > product.Quantity)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            _productRepository.Update(name, product.Quantity -  quantity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }

    public void PrintStockReport()
    {
        foreach (var product in _productRepository.GetAll())
        {
            Console.WriteLine(product);
        }
    }
    public IReadOnlyList<Product> GetAll()
    {
        return _productRepository.GetAll();
    }
}