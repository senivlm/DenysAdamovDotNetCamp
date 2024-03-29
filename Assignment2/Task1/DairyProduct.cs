﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class DairyProduct : Product
    {
        private int _daysBeforeSpoil;

        public DairyProduct() : this(default, default, default, default)
        { }
        public DairyProduct(string name, double price, double weight, int daysBeforeSpoil) : base(name, price, weight)
        {
            _daysBeforeSpoil = daysBeforeSpoil;
        }
        public int DaysBeforeSpoil => _daysBeforeSpoil;
        public override void ChangePrice(double changePercent = 0)
        {
            if (changePercent >= 0)
            {
                double changePercentPerDayBeforeSpoil = 0;
                if (_daysBeforeSpoil == 1)
                {
                    changePercentPerDayBeforeSpoil = 50;
                }
                else if (_daysBeforeSpoil == 2)
                {
                    changePercentPerDayBeforeSpoil = 40;
                }
                else if (_daysBeforeSpoil == 3)
                {
                    changePercentPerDayBeforeSpoil = 20;
                }
                else if (_daysBeforeSpoil > 3)
                {
                    changePercentPerDayBeforeSpoil = 10;
                }
                else if (_daysBeforeSpoil > 6)
                {
                    changePercentPerDayBeforeSpoil = 5;
                }
                else if (_daysBeforeSpoil > 9)
                {
                    changePercentPerDayBeforeSpoil = 0;
                }
                base.ChangePrice(changePercent + changePercentPerDayBeforeSpoil);
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"| { _daysBeforeSpoil: 10.}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is DairyProduct)
            {
                DairyProduct comparedDp = (DairyProduct)obj;
                if (this.Title == comparedDp.Title
                    && Math.Abs(this.Price - comparedDp.Price) < 0.000001
                    && Math.Abs(this.Weight - comparedDp.Weight) < 0.000001
                    && this._daysBeforeSpoil == comparedDp._daysBeforeSpoil)
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
