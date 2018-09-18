using Checkout.Interfaces;

namespace Checkout.Models
{
    public class Product : IProduct
    {
        public string Sku { get; set; }
        public int Price { get; set; }
    }
}
