using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Interfaces
{
    public interface IProductFactory
    {
        IProduct GetProduct(string sku);
    }
}
