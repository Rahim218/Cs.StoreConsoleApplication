using Cs.StoreConsoleApplication.Interface;
using Cs.StoreConsoleApplication.Exceptionn;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.StoreConsoleApplication.Classes
{
    internal class Store : IStore
    {
        private Product[] _products = new Product[0];
        public Product[] Products { get => _products; set => _products = value; }
        private int _dairyproductcountlimit = 3;
        public int DairyProductCountLimit { get => _dairyproductcountlimit;}
        private double _alcoholPercentLimit = 45;
        public double AlcoholPercentLimit { get => _alcoholPercentLimit; }

        public Drink[] GetDrinkProducts()
        {
            Drink[] drinks = new Drink[0];
            foreach (var item in _products)
            {
                if (item is Drink)
                {
                    Drink drink = (Drink)item;
                    Array.Resize(ref drinks, drinks.Length + 1);
                    drinks[drinks.Length - 1] = drink;
                }
            }
            return drinks;
        }
        public Dairy[] GetDairyProducts()
        {
            Dairy[] dairys = new Dairy[0];
            foreach (var item in _products)
            {
                if (item is Dairy)
                {
                    Dairy dairy = (Dairy)item;
                    Array.Resize(ref dairys, dairys.Length + 1);
                    dairys[dairys.Length - 1] = dairy;
                    

                }
            }
            return dairys;
        }

        public void AddProduct(Product product)
        {
            
            if (product is Drink)
            {
                Drink drink = (Drink)product;
                if (AlcoholPercentLimit>drink.AlcoholPercent)
                {
                    Array.Resize(ref _products, _products.Length + 1);
                    _products[_products.Length - 1] = drink;
                }
            }
            else if(product is Dairy)
            {
                
                Dairy dairy = (Dairy)product;
                if (_dairyproductcountlimit >=dairy.Count)
                {
                    Array.Resize(ref _products, _products.Length + 1);
                    _products[_products.Length - 1] = dairy;
                    
                }

            }
            
        }

        public Product GetProductByNo(int no)
        {
            foreach (Product product in _products)
            {
                if (product.No == no)
                {
                    return product;
                }
                
            }
            throw new ProductNotFoundException();
        }

        public bool HasProductByNo(int no)
        {
            foreach (Product product in _products )
            {
                if (product.No == no)
                {
                    return true;
                }
            }
            return false;
        }

        public Product[] RemoveProduct(int no)
        {
            Product[] newArr = new Product[0];
            foreach (var item in _products)
            {
                if (item.No != no)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[newArr.Length-1] = item;
                }
            }
            return _products = newArr;
        }
    }
}
