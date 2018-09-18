using Checkout.Interfaces;
using Checkout.BusinessLogic;
using NUnit.Framework;
using System.Collections.Generic;
using Checkout.Models;

namespace Checkout.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        private ICheckout _checkout { get; set; }

        [SetUp]
        public void SetUp()
        {
            IDiscountCalculator calculator = new DiscountCalculator();
            List<IDiscount> discounts = new List<IDiscount>();

            discounts.Add(new Discount
            {
                Sku = "A",
                HasDiscount = true,
                ItemsRequired = 3,
                DicountedPrice = 130
            });

            discounts.Add(new Discount
            {
                Sku = "B",
                HasDiscount = true,
                ItemsRequired = 2,
                DicountedPrice = 45
            });

            _checkout = new KataCheckout(new ProductFactory(), calculator, discounts);
        }

        [Test]
        public void GetTotalPrice_SingleItemAdded_ReturnsSinglePrice()
        {
            
            _checkout.Scan("A");

            int price = _checkout.GetTotalPrice();

            Assert.AreEqual(50, price);
        }

        [Test]
        public void GetTotalPrice_TwoItemsAdded_ReturnsCombinedPrice()
        {
            _checkout.Scan("A");
            _checkout.Scan("B");

            int price = _checkout.GetTotalPrice();

            Assert.AreEqual(80, price);
        }

        [Test]
        public void GetTotalPrice_AddDiscountedItems_ReturnsDiscountedPrice()
        {
            _checkout.Scan("B");
            _checkout.Scan("B");

            int price = _checkout.GetTotalPrice();

            Assert.AreEqual(45, price);
        }

        [Test]
        public void GetTotalPrice_AddFiveAItems_ReturnsDiscountedPrice()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");

            Assert.AreEqual(230, _checkout.GetTotalPrice());
        }
    }
}
