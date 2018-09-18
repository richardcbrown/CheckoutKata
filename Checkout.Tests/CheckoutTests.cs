using Checkout.Interfaces;
using Checkout.BusinessLogic;
using NUnit.Framework;

namespace Checkout.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        public void GetTotalPrice_SingleItemAdded_ReturnsSinglePrice()
        {
            ICheckout checkout = new KataCheckout(new ProductFactory());
            checkout.Scan("A");

            int price = checkout.GetTotalPrice();

            Assert.AreEqual(50, price);
        }

        [Test]
        public void GetTotalPrice_TwoItemsAdded_ReturnsCombinedPrice()
        {
            ICheckout checkout = new KataCheckout(new ProductFactory());

            checkout.Scan("A");
            checkout.Scan("B");

            int price = checkout.GetTotalPrice();

            Assert.AreEqual(80, price);
        }

        [Test]
        public void GetTotalPrice_AddDiscountedItems_ReturnsDiscountedPrice()
        {
            ICheckout checkout = new KataCheckout(new ProductFactory());

            checkout.Scan("B");
            checkout.Scan("B");

            int price = checkout.GetTotalPrice();

            Assert.AreEqual(45, price);
        }
    }
}
