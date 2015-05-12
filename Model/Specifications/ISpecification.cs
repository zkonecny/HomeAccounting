using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HouseAccounting.Model.Interfaces;

namespace HouseAccounting.Model.Specifications
{
    public interface ISpecification<T> where T : IDomainEntity
    {
        bool IsSatisfiedBy(T obj);
    }
}
