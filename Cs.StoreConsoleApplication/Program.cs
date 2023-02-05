using Cs.StoreConsoleApplication.Classes;
using Cs.StoreConsoleApplication.Exceptionn;
using System;

namespace Cs.StoreConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            string option;
            do
            {
                Console.WriteLine();
                Console.WriteLine("===============MENU===============");
                Console.WriteLine();

                Console.WriteLine($"1. Drink product elave et\n2. Dairy product elave et\n3. Butun productlara bax\n4. Verilmis nomreli producta bax\n5. Drink productlara bax\n6.Dairy productlara bax\n7. Ada gorə axtarıs et\n8 Qiymət aralığına görə axtarıs et\n9. Siyahıdan məhsul sil");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        store.AddProduct(CreateDrinkProduct());

                        break;
                    case "2":
                        store.AddProduct(CreateDairyProduct());
                        break;
                    case "3":
                        ShowProducts(store.Products);
                        break;
                    case "4":
                        Console.WriteLine("Axtarmax istediyiniz productin No-sunu daxil edin :");
                        bool chek = false;
                        do
                        {
                            try
                            {
                                int no = int.Parse(Console.ReadLine());
                                var result = store.GetProductByNo(no);
                                Console.WriteLine($"{result.No}\n{result.Name}\n{result.Price}");
                                chek = true;
                            }
                            catch (ProductNotFoundException ex)
                            {

                                Console.WriteLine("Mehsul tapilmadi....");
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("Reqem daxil edin");
                            }
                        } while (chek == false); 
                       
                        
                        break;
                    case "5":
                        ShowProducts(store.GetDrinkProducts());
                        break;
                    case "6":
                        ShowProducts(store.GetDairyProducts());
                        break;
                    case "7":
                        Console.WriteLine("Axtardiginiz mehsulun adini daxil edin :");
                        string searcName = Console.ReadLine();
                        ShowProducts(ProductByName(searcName,store));
                        break;
                    case "8":
                        Console.WriteLine("Axtarmaq istediyiniz mehsulun MINIMUM deyerini daxil edin");
                        int minimumPrice = int.Parse(Console.ReadLine());
                        Console.WriteLine("Axtarmaq istediyiniz mehsulun MAXIMUM deyerini daxil edin");
                        int maximumPrice = int.Parse(Console.ReadLine());
                        ShowProducts(ProductByPrice(minimumPrice, maximumPrice,store));
                        break;
                    case "9":
                        Console.WriteLine("Silmek istediyiniz mehsulun No-sunu daxil edin");

                        int wantedNo = int.Parse(Console.ReadLine());
                        store.RemoveProduct(wantedNo);
                        break;
                    case "0":
                        Console.WriteLine("Cixis olundu.....");
                        break;
                    default:
                        Console.WriteLine("Duzgun deyer daxil edin....");
                        break;

                }
            } while (option != "0");

        }
        static Product CreateDrinkProduct()
        {
            Console.WriteLine("Mehsulun adini daxil edin :");
            string drinkName = Console.ReadLine();

            Console.WriteLine("Mehsulun qiymetini daxil edin : ");
            int drinkPrice = int.Parse(Console.ReadLine());

            Console.WriteLine("Alkoqok faizini daxil edin : ");
            int drinkAlcoholPercent = int.Parse(Console.ReadLine());

            Drink drink = new Drink()
            {
                Name = drinkName,
                Price = drinkPrice,
                AlcoholPercent = drinkAlcoholPercent
            };
            return drink;
        }
        static Product CreateDairyProduct()
        {
            Console.WriteLine("Mehsulun adini daxil edin :");
            string dairyName = Console.ReadLine();

            Console.WriteLine("Mehsulun qiymetini daxil edin : ");
            int dairyPrice = int.Parse(Console.ReadLine());

            Console.WriteLine("Yagliliq faizini daxil edin : ");
            int fatPercent = int.Parse(Console.ReadLine());

            Dairy dairy = new Dairy()
            {
                Name = dairyName,
                Price = dairyPrice,
                FatPercent = fatPercent
            };
            return dairy;
        }
        static void ShowProducts(Product[] products)
        {
            foreach (var item in products)
            {
                Console.WriteLine($"No : {item.No}\nName : {item.Name}\nPrice : {item.Price}");
            }
        }
    
        static Product[] ProductByName(string name,Store store)
        {
            Product[] newArr = new Product[0];
            
            for (int i = 0; i < store.Products.Length; i++)
            {
                for (int j = 0; j < name.Length; j++)
                {
                    if (store.Products[i].Name.Contains(name[j]))
                    {
                        Array.Resize(ref newArr, newArr.Length + 1);
                        newArr[newArr.Length - 1] = store.Products[i];
                    }
                }
            }
            return newArr;


        }
        static Product[] ProductByPrice(int minValue, int maxValue,Store store)
        {
            Product[] products = new Product[0];
            
            for (int i = 0; i < store.Products.Length; i++)
            {
                if (store.Products[i].Price > minValue && store.Products[i].Price < maxValue)
                {
                    Array.Resize(ref products,products.Length + 1);
                    products[products.Length - 1] = store.Products[i];

                }

            }
            return products;
        }
    }

}

