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
            int eligibleProducts = 0;

            if (discount.HasDiscount)
            {
                ineligibleProducts = matchingProducts.Count() % discount.ItemsRequired;
                eligibleProducts = (matchingProducts.Count() - ineligibleProducts) / discount.ItemsRequired;
            }

            return matchingProducts.Take(ineligibleProducts).Sum(p => p.Price)
                + (eligibleProducts * discount.DicountedPrice);
        }
    }
}
