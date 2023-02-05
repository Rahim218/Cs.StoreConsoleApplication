using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.StoreConsoleApplication.Classes
{
    internal class Product
    {
        static int _totalcount;
        int _no;
        double _price;
        public Product()
        {
            _totalcount++;
            _no = _totalcount;
        }
        public int No { get => _no; }

        public string Name;
        public double Price
        {
            set
            {
                if ( value > 0)
                {
                    _price = value;
                }
            }
            get => _price;
        }


    }
}
