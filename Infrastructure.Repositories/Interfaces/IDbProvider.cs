using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseAccounting.Model.Classes;

namespace HouseAccounting.Infrastructure.Repositories.Interfaces
{
    public interface IDbProvider
    {
        IEnumerable<TDomainEntity> GetAll<TDomainEntity>() where TDomainEntity : DomainEntity, new();

        TDomainEntity FindById<TDomainEntity>(int id) where TDomainEntity : DomainEntity, new();

        void Insert<TDomainEntity>(TDomainEntity entity) where TDomainEntity : DomainEntity, new();

        void Update<TDomainEntity>(TDomainEntity entity) where TDomainEntity : DomainEntity, new();

        void Delete<TDomainEntity>(TDomainEntity entity) where TDomainEntity : DomainEntity, new();
    }
}
