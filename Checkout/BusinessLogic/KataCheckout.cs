using Checkout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.BusinessLogic
{
    public class KataCheckout : ICheckout
    {
        private readonly List<IProduct> _products = new List<IProduct>();
        private readonly IProductFactory _productFactory;
        private readonly IDiscountCalculator _discountCalculator;
        private readonly IEnumerable<IDiscount> _discounts;

        public KataCheckout(IProductFactory productFactory, IDiscountCalculator discountCalculator, IEnumerable<IDiscount> discounts)
        {
            _productFactory = productFactory;
            _discountCalculator = discountCalculator;
            _discounts = discounts;
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach (var discount in _discounts)
            {
                totalPrice += _discountCalculator.GetTotalPriceForProducts(discount, _products);
            }

            return totalPrice;
        }

        public void Scan(string item)
        {
            _products.Add(_productFactory.GetProduct(item));
        }
    }
}
