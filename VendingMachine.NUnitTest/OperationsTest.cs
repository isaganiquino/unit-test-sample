using NUnit.Framework;
using VendingMachine.Core;
namespace VendingMachine.NUnitTest
{
    public class OperationsTest
    {
        IOperations operations;

        [SetUp]
        public void Setup()
        {
           operations = new Operations();
        }

        [Test]
        [TestCase("100", true)]
        [TestCase("50", true)]
        [TestCase("20", true)]
        [TestCase("10", false)]
        [TestCase("5", false)]
        public void Should_Return_Valid_Bill(string bill, bool expected)
        {
            Assert.AreEqual(expected, operations.ValidateBill(bill));
        }

        [Test]
        [TestCase("10", true)]
        [TestCase("5", true)]
        [TestCase("1", true)]
        [TestCase("0.50", true)]
        [TestCase("0.25", true)]
        [TestCase("2", false)]
        [TestCase("0.10", false)]
        public void Should_Return_Valid_Coins(string coins, bool expected)
        {
            Assert.AreEqual(expected, operations.ValidateCoins(coins));
        }

        [TestCase(50, 25, 25)]
        [TestCase(100, 35, 65)]
        public void Should_Return_Valid_Change(double money, double price, double expected)
        {            
            Assert.AreEqual(expected, operations.CalculateChange(money, price));
        }

        [Test]
        public void Test()
        {
            Assert.Pass();
        }
    }
}