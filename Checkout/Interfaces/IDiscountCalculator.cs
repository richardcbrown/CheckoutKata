using System.Collections.Generic;

namespace Checkout.Interfaces
{
    public interface IDiscountCalculator
    {
        int GetTotalPriceForProducts(IDiscount discount, IEnumerable<IProduct> products);
    }
}
