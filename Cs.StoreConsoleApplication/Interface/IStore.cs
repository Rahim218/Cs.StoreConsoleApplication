using Cs.StoreConsoleApplication.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.StoreConsoleApplication.Interface
{
    internal interface IStore
    {
        Product[] Products { get; set; }
        void AddProduct(Product product);
        bool HasProductByNo(int no);
        Product GetProductByNo(int no);
        Product[] RemoveProduct(int no);
    }
}
