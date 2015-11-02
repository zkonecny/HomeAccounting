﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseAccounting.Model.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T obj);
    }
}
