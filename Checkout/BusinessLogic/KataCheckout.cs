using Checkout.Interfaces;
using System;

namespace Checkout.BusinessLogic
{
    public class KataCheckout : ICheckout
    {
        private int _totalPrice { get; set; }

        public int GetTotalPrice()
        {
            return _totalPrice;
        }

        public void Scan(string item)
        {
            _totalPrice = 50;
        }
    }
}
