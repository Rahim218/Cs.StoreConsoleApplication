using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.StoreConsoleApplication.Classes
{
    internal class Dairy:Product
    {
         
        public Dairy()
        {
            _count++;
        }
        private static int _count;
        public double FatPercent;
        public int Count { get { return _count; } }
    }
}
