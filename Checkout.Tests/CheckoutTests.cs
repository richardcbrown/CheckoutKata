using Checkout.Interfaces;
using Checkout.BusinessLogic;
using NUnit.Framework;

namespace Checkout.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        public void Test1()
        {
            ICheckout checkout = new KataCheckout();

            checkout.Scan("A");
        }
    }
}
