using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Core
{
    public interface IOperations
    {
        public bool ValidateBill(double bill);
        public bool ValidateCoins(double coins);
        public StatusCode ValidateProduct(int productId, double money);
        public List<Product> GetProducts();
        public Product GetProduct(int productId);
        public double CalculateChange(double money, double price);
    }

    public class Operations : IOperations
    {
        public bool ValidateBill(double bill)
        {
            return bill == 100 || bill == 50 || bill == 20;
        }

        public bool ValidateCoins(double coins)
        {
            return coins == 10 || coins == 5 || coins == 1 || coins == 0.50 || coins == 0.25;
        }

        public StatusCode ValidateProduct(int productId, double money)
        {
            StatusCode sc = new StatusCode() { IsValid = false };
            Product product = GetProduct(productId);

            if (product == null)
            {
                sc.Message = "Product not found!";
            }
            else if (product.Price > money)
            {
                sc.Message = "Money is not sufficient for the selected product!";
            }
            else
            {
                sc.IsValid = true;
            }

            return sc;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product() { ProductID = 1, ProductName = "Coke", Price = 25 });
            products.Add(new Product() { ProductID = 2, ProductName = "Pepsi", Price = 35 });
            products.Add(new Product() { ProductID = 3, ProductName = "Soda", Price = 45 });
            products.Add(new Product() { ProductID = 4, ProductName = "Chocolate bar", Price = 20.25 });
            products.Add(new Product() { ProductID = 5, ProductName = "Chewing gum", Price = 10.50 });
            products.Add(new Product() { ProductID = 6, ProductName = "Bottled water", Price = 15 });

            return products;
        }

        public Product GetProduct(int productId)
        {
            var products = GetProducts();

            return products.Find(x => x.ProductID == productId);
        }

        public double CalculateChange(double money, double price)
        {
            return money - price;
        }
    }
}
