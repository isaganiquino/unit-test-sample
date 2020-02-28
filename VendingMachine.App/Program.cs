using System;
using VendingMachine.Core;

namespace VendingMachine.App
{
    class Program
    {
        static void Main(string[] args)
        {
            double bill = 0;
            double coins = 0;
            double money = 0; 
            int productId = 0;
            string ans = string.Empty;

            IOperations op = new Operations();

            Console.WriteLine("=======================VENDING MACHINE=======================\n\n\n\n");

            //Accept Bill
            while (true)
            {
                Console.Write("Please enter bill (100, 50, 20):");
                bill = Convert.ToDouble(Console.ReadLine());

                if (op.ValidateBill(bill) == true) break;
                Console.WriteLine("\nInvalid bill. We accept 100, 50 or 20 bill only!\n\n");
            }

            //Accept Coins
            while (true)
            {               
                Console.Write("Please enter coins (10, 5, 1, 0.50, 0.25):");
                coins = Convert.ToDouble(Console.ReadLine());

                if (op.ValidateCoins(coins) == true) break;
                Console.WriteLine("\nInvalid coins. We accept 10, 5, 1, 0.50 or 0.25 coins only!\n\n");
            } 

            money = bill + coins;

            //Populate Product
            Console.WriteLine("\nList of Products ");
            var products = op.GetProducts();
            foreach(Product product in products)
            {
                Console.WriteLine(string.Format("{0}. {1} ({2})", product.ProductID, product.ProductName, product.Price));
            }

            //Select Product
            while (true)
            {
                Console.Write("\nPlease select product: ");
                productId = Convert.ToInt32(Console.ReadLine());

                var sc = op.ValidateProduct(productId, money);
                if (sc.IsValid == true) break;
                else Console.WriteLine(sc.Message);
            }

            Product selectedProduct = op.GetProduct(productId);
            Console.WriteLine(string.Format("\nYou ordered {0} for the amount of {1}.", selectedProduct.ProductName, selectedProduct.Price));

            while (true)
            {
                Console.Write("Do you wish to proceed? [Y] Proceed  [N] Cancel: ");
                ans = Console.ReadLine();

                if (ans.ToUpper() == "Y")
                {
                    double change = op.CalculateChange(money, selectedProduct.Price);
                    Console.WriteLine(string.Format("\nYou change is {0}.", change));
                    break;
                }
                else if (ans.ToUpper() == "N")
                {
                    Console.WriteLine(string.Format("\nYou cancelled your order. Your total refund is {0}.", money));
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input! ");
                }
            }
            
            Console.WriteLine("\nThank you for using this vending machine.\nPress any key to exit! ");
            Console.ReadLine();
        }
    }
}
