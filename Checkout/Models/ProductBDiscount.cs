using Checkout.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Models
{
    public class ProductBDiscount : IDiscount
    {
        private const int ItemsRequiredForDiscount = 2;
        private const int DiscountPrice = 45;
        private readonly IEnumerable<IProduct> _products;

        public ProductBDiscount(IEnumerable<IProduct> products)
        {
            _products = products;
        }

        public int GetTotalPriceForProducts(string item)
        {
            throw new NotImplementedException();
        }
    }
}
