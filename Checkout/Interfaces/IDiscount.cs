using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Interfaces
{
    public interface IDiscount
    {
        string Sku { get; set; }
        bool HasDiscount { get; set; }
        int ItemsRequired { get; set; }
        int DicountedPrice { get; set; }
    }
}
