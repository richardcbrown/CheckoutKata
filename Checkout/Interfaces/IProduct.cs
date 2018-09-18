using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Interfaces
{
    public interface IProduct
    {
        string Sku { get; set; }
        int Price { get; set; }
    }
}
