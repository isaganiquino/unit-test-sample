using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Core
{
    public interface IOperations
    {
        public bool ValidateBill(string bill);
        public bool ValidateCoins(string coins);
        public StatusCode ValidateProduct(string productId, double money);
        public List<Product> GetProducts();
        public Product GetProduct(int productId);
        public double CalculateChange(double money, double price);
    }

    public class Operations : IOperations
    {
        public bool ValidateBill(string bill)
        {
            double amount = 0;

            try
            {
                amount = Convert.ToDouble(bill);
                if (amount == 100 || amount == 50 || amount == 20)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidateCoins(string coins)
        {
            double amount = 0;

            try
            {
                amount = Convert.ToDouble(coins);
                if (amount == 10 || amount == 5 || amount == 1 || amount == 0.50 || amount == 0.25)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public StatusCode ValidateProduct(string productId, double money)
        {            
            StatusCode sc = new StatusCode() { IsValid = false };
            int id = 0;
            Product product = new Product();

            try
            {
                id = Convert.ToInt32(productId);
                product = GetProduct(id);

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

            }
            catch
            {
                sc.IsValid = false;
                sc.Message = "Invalid input!";
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
