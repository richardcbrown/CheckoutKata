using Checkout.Interfaces;
using System;

namespace Checkout.BusinessLogic
{
    public class KataCheckout : ICheckout
    {
        private int _totalPrice { get; set; } = 0;

        public int GetTotalPrice()
        {
            return _totalPrice;
        }

        public void Scan(string item)
        {
            if (string.IsNullOrWhiteSpace(item))
                return;

            if (item.Equals("A"))
            {
                _totalPrice += 50;
            }

            if (item.Equals("B"))
            {
                _totalPrice += 30;
            }
        }
    }
}
