using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Storage
    {
        private Product[] _products;
        public Storage() : this(default)
        { }
        public Storage(params Product[] products)
        {
            Fill();
        }
        public Product[] Products
        {
            private set => Fill();
            get => _products;
        }

        public double TotalWeight => _products.Sum(p => p.Weight);
        public double TotalPrice => _products.Sum(p => p.Price);
        public Product this[int index]
        {
            get => _products[index];
            set
            {
                if (value is Product)
                {
                    _products[index] = value;
                }
                else
                {
                    throw new ArgumentException("Can't insert a non-Product");
                }
            }
        }

        public void FillInByHand()
        {
            Console.WriteLine("Set the number of products to add:");
            int numberOfProducts;
            int.TryParse(Console.ReadLine(), out numberOfProducts);
            _products = new Product[numberOfProducts];
            for (int i = 0; i < numberOfProducts; i++)
            {
                Console.WriteLine($"Enter data for the product number {i+1}:");

                Console.WriteLine("Set title:");
                string title = Console.ReadLine();

                Console.WriteLine("Set price:");
                bool successfulInput = double.TryParse(Console.ReadLine(), out double price);
                while (!successfulInput)
                {
                    Console.WriteLine("Wrong input. Try again:");
                    successfulInput = double.TryParse(Console.ReadLine(), out price);
                };

                Console.WriteLine("Set weight:");
                successfulInput = double.TryParse(Console.ReadLine(), out double weight);
                while (!successfulInput)
                {
                    Console.WriteLine("Wrong input. Try again:");
                    successfulInput = double.TryParse(Console.ReadLine(), out weight);
                };

                Console.WriteLine("Enter 'm' for meat, 'dp' for dairy product, otherwise it will be a simple product");
                string productType = Console.ReadLine();
                if (productType == "m")
                {
                    Console.WriteLine("Set category:");
                    string cat = Console.ReadLine();
                    
                    successfulInput = Enum.TryParse(typeof(MeatCategory), cat, out object catObj);
                    while (!successfulInput)
                    {
                        Console.WriteLine("Wrong input. Try again:");
                        cat = Console.ReadLine();
                        successfulInput = Enum.TryParse(typeof(MeatCategory), cat, out catObj);
                    }
                    
                    MeatCategory category = (MeatCategory)catObj;

                    Console.WriteLine("Set type:");
                    string tp = Console.ReadLine();

                    successfulInput = Enum.TryParse(typeof(MeatType), tp, out object typeObj);
                    while (!successfulInput)
                    {
                        Console.WriteLine("Wrong input. Try again:");
                        tp = Console.ReadLine();
                        successfulInput = Enum.TryParse(typeof(MeatType), tp, out typeObj);
                    }

                    MeatType type = (MeatType)typeObj;

                    _products[i] = new Meat(title, price, weight, category, type);
                }
                else if (productType == "dp")
                {
                    Console.WriteLine("Set number of days before spoil:");
                    successfulInput = int.TryParse(Console.ReadLine(), out int daysBeforeSpoil);
                    while (!successfulInput || daysBeforeSpoil <=0)
                    {
                        Console.WriteLine("Wrong input. Try again:");
                        successfulInput = int.TryParse(Console.ReadLine(), out daysBeforeSpoil);
                    }

                    _products[i] = new DairyProduct(title, price, weight, daysBeforeSpoil);
                }
                else
                {
                    _products[i] = new Product(title, price, weight);
                }
            }
        }
        public void Fill(params Product[] products)
        {
            if (products != null)
            {
                _products = products;
            }
        }
        public void PrintDetails()
        {
            Console.WriteLine("Total price = " + TotalPrice + " | Total weight = " + TotalWeight);
            Console.WriteLine("All products:");
            Console.WriteLine($"{"Title",10} | {"Price",10} | {"Weight (g)",10}");
            foreach (Product product in Products)
            {
                Console.WriteLine($"{product.Title,10} | {product.Price,10:C2} | {product.Weight,10}");
            }
        }
        public Product[] GetMeatProducts()
        {
            int numberOfMeatProducts = 0;
            foreach (Product product in _products)
            {
                if (product is Meat)
                {
                    numberOfMeatProducts++;
                }
            }
            Product[] meatProducts = new Product[numberOfMeatProducts];
            int insertedProducts = 0;
            foreach (Product product in _products)
            {
                if (product is Meat)
                {
                    meatProducts[insertedProducts++] = product;
                }
            }
            return meatProducts;
        }

        public void ChangePrice(double changePercent)
        {
            foreach (var product in Products)
            {
                product.ChangePrice(changePercent);
            }
        }

    }
}
