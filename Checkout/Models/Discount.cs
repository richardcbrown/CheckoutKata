using Checkout.Interfaces;

namespace Checkout.Models
{
    public class Discount : IDiscount
    {
        public string Sku { get; set; }
        public bool HasDiscount { get; set; }
        public int ItemsRequired { get; set; }
        public int DicountedPrice { get; set; }
    }
}
