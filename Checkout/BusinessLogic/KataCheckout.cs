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
            List<List<IProduct>> discountedProducts = new List<List<IProduct>>();
            List<IProduct> nonDiscountedProducts = new List<IProduct>();
            List<IProduct> discountCandidates = new List<IProduct>();

            foreach (var product in _products)
            {
                if (product.Sku.Equals("B"))
                {
                    discountCandidates.Add(product);

                    if (discountCandidates.Count == 2)
                    {
                        discountedProducts.Add(discountCandidates);
                        discountCandidates = new List<IProduct>();
                    }
                }
                else
                {
                    nonDiscountedProducts.Add(product);
                }
            }

            // not a full set of discount products, price normally
            nonDiscountedProducts.AddRange(discountCandidates);

            return (discountedProducts.Count * 45) + nonDiscountedProducts.Sum(p => p.Price);
        }

        public void Scan(string item)
        {
            _products.Add(_productFactory.GetProduct(item));
        }
    }
}
