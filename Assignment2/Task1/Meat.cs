using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Meat : Product
    {
        private MeatCategory _category;
        private MeatType _type;
        public Meat() : this(default, default, default, default, default)
        { }
        public Meat(string title, double price, double weight, MeatCategory category, MeatType type) : base(title, price, weight)
        {
            _category = category;
            _type = type;
        }
        public MeatCategory Category => _category;
        public MeatType Type => _type;
        public override void ChangePrice(double changePercent = 0)
        {
            if (changePercent != 0)
            {
                double changePercentPerType = 0;
                switch (_type)
                {
                    case MeatType.Mutton:
                        changePercentPerType = 20;
                        break;
                    case MeatType.Veal:
                        changePercentPerType = 15;
                        break;
                    case MeatType.Pork:
                        changePercentPerType = 10;
                        break;
                    case MeatType.Chicken:
                        changePercentPerType = 5;
                        break;
                    default:
                        changePercentPerType = 0;
                        break;
                }
                if (changePercent < 0)
                {
                    changePercentPerType = -changePercentPerType;
                }
                base.ChangePrice(changePercent + changePercentPerType);
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"| { _category: 10.} | {_type}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Meat)
            {
                Meat comparedMeat = (Meat)obj;
                if (this.Title == comparedMeat.Title
                    && Math.Abs(this.Price - comparedMeat.Price) < 0.000001
                    && Math.Abs(this.Weight - comparedMeat.Weight) < 0.000001
                    && this._category == comparedMeat._category
                    && this._type == comparedMeat._type)
                {
                    return true;
                }
                else
                {
                   return false;
                }
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
