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

        public KataCheckout(IProductFactory productFactory)
        {
            _productFactory = productFactory;
        }

        public int GetTotalPrice()
        {
            return _products.Sum(p => p.Price);
        }

        public void Scan(string item)
        {
            _products.Add(_productFactory.GetProduct(item));
        }
    }
}
