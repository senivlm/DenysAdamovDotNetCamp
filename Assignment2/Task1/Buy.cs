using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Buy
    {
        private List<Product> _products;
        public Buy() :this(default)
        { }
        public Buy(params Product[] products)
        { 
            _products = products.ToList();
        }
        public List<Product> Products
        {
            private set { _products = value; }
            get { return _products; }
        }

        public double TotalWeight => _products.Sum(p => p.Weight);
        public double TotalPrice => _products.Sum(p => p.Price);

    }
}
