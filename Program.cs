using CW10B.Logger;
using CW10B.Model;
using CW10B.Repository;
using CW10B.Service;
class Program
{
    static void Main()
    {

        Console.WriteLine("name");
        var name = Console.ReadLine();
        var student = new StudentInfo(name);
        Console.WriteLine(student.PrintMyName);

        var productService = new ProductService(new FileLogger(), new ProductRepository());

        string errorMessage = "";

        while (true)
        {
            Console.WriteLine(@"
1: Add product
2: Receive goods
3: Dispatch goods
4: Display stock
5: Delete product
6: Get low quantity products
7: Exit
");

            Console.Write("Enter your choice: ");
            var input = Console.ReadLine();

            if (input == "1")
            {
                AddProduct(productService, ref errorMessage);
            }
            else if (input == "2")
            {
                ReceiveGoods(productService, ref errorMessage);
            }
            else if (input == "3")
            {
                DispatchGoods(productService, ref errorMessage);
            }
            else if (input == "4")
            {
                PrintStockReport(productService);
            }
            else if (input == "5")
            {
                DeleteProduct(productService, ref errorMessage);
            }
            else if (input == "6")
            {
                foreach (var product in productService.GetLowCountProducts())
                    Console.WriteLine(product);
            }
            else if (input == "7")
            {
                break;
            }
            else
            {
                Console.WriteLine("please enter a number bein 1 and 7.");
            }
        }

        static void AddProduct(ProductService service, ref string errorMessage)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage))
                Console.WriteLine(errorMessage);

            while (true)
            {
                try
                {
                    Console.WriteLine("Adding product ");
                    Console.Write("Name: ");
                    var name = Console.ReadLine();

                    Console.Write("Quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantity))
                        throw new Exception("Invalid quantity");

                    Console.Write("Min: ");
                    if (!int.TryParse(Console.ReadLine(), out int min))
                        throw new Exception("Invalid min value");

                    service.AddProduct(name, quantity, min);
                    errorMessage = "";
                    break;
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }
            }
        }
        ////

        static void ReceiveGoods(ProductService service, ref string errorMessage)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage))
                Console.WriteLine(errorMessage);

            while (true)
            {
                try
                {
                    Console.WriteLine("Receive product");
                    Console.Write("Name: ");
                    var name = Console.ReadLine();

                    Console.Write("Quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantity))
                        throw new Exception("Invalid quantity");

                    service.ReceiveGoods(name, quantity);
                    errorMessage = "";
                    break;
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                }
            }
        }

        static void DispatchGoods(ProductService service, ref string errorMessage)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage))
                Console.WriteLine(errorMessage);

            while (true)
            {
                try
                {
                    Console.WriteLine("Dispatch product");
                    Console.Write("Name: ");
                    var name = Console.ReadLine();

                    Console.Write("Quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantity))
                        throw new Exception("Invalid quantity");

                    service.DispatchGoods(name, quantity);
                    errorMessage = "";
                    break;
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }
            }
        }

        static void DeleteProduct(ProductService service, ref string errorMessage)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage))
                Console.WriteLine(errorMessage);

            while (true)
            {
                try
                {
                    Console.WriteLine("Deleting product");
                    Console.Write("Name: ");
                    var name = Console.ReadLine();

                    service.DeleteProduct(name);
                    errorMessage = "";
                    break;
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }
            }
        }

        static void PrintStockReport(ProductService service)
        {
            foreach (var product in service.GetAll())
            {
                Console.WriteLine(product);
            }
        }
    }
}