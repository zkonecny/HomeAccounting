using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseAccounting.DTOS
{
    public static class DtoExtensions
    {
        public static string ToCurrencyString(this int value)
        {
            return value.ToString("C0");
        }
    }
}
