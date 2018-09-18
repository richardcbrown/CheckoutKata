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
            ICheckout checkout = new KataCheckout();
            checkout.Scan("A");

            int price = checkout.GetTotalPrice();

            Assert.AreEqual(50, price);
        }
    }
}
