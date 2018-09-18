using Checkout.Interfaces;
using Checkout.Models;

namespace Checkout.BusinessLogic
{
    public class ProductFactory : IProductFactory
    {
        public IProduct GetProduct(string sku)
        {
            switch (sku)
            {
                case "A":
                    return new Product { Sku = sku, Price = 50 };
                case "B":
                    return new Product { Sku = sku, Price = 30 };
                default:
                    // TODO - throw exception on invalid SKU?
                    return new Product { Sku = "INVALID_PRODUCT", Price = 0 };
            }
        }
    }
}
