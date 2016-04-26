using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseAccounting.Web
{
    public static class ViewExtensions
    {
        public static string ToCurrencyString(this int value)
        {
            return value.ToString("C0");
        }

        public static string ToDate(this DateTime value)
        {
            return value.ToShortDateString();
        }
    }
}