using Checkout.Interfaces;
using System;

namespace Checkout.BusinessLogic
{
    public class KataCheckout : ICheckout
    {
        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            throw new NotImplementedException();
        }
    }
}
