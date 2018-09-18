using Checkout.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.BusinessLogic
{
    public class DiscountCalculator : IDiscountCalculator
    {
        public int GetTotalPriceForProducts(IDiscount discount, IEnumerable<IProduct> products)
        {
            var matchingProducts = products.Where(p => p.Sku.Equals(discount.Sku));
            int ineligibleProducts = matchingProducts.Count();

            if (discount.HasDiscount)
                ineligibleProducts = matchingProducts.Count() % discount.ItemsRequired;

            return matchingProducts.Take(ineligibleProducts).Sum(p => p.Price)
                + ((matchingProducts.Count() - ineligibleProducts) * discount.DicountedPrice);
        }
    }
}
