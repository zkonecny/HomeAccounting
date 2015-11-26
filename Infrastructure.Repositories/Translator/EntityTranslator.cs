using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouserAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories.Translator
{
    public class EntityTranslator : IEntityTranslator
    {
        static EntityTranslator()
        {
            AutoMapper.Mapper.CreateMap<Person, PersonEntity>();
            AutoMapper.Mapper.CreateMap<PersonEntity, Person>();
            
            AutoMapper.Mapper.CreateMap<IncomeCategory, IncomeCategoryEntity>();
            AutoMapper.Mapper.CreateMap<IncomeCategoryEntity, IncomeCategory>();
            
            AutoMapper.Mapper.CreateMap<ExpenditureCategory, ExpenditureCategoryEntity>();
            AutoMapper.Mapper.CreateMap<ExpenditureCategoryEntity, ExpenditureCategory>();
            
            AutoMapper.Mapper.CreateMap<Income, IncomeEntity>();
            AutoMapper.Mapper.CreateMap<IncomeEntity, Income>();
            
            AutoMapper.Mapper.CreateMap<Expenditure, ExpenditureEntity>();
            AutoMapper.Mapper.CreateMap<ExpenditureEntity, Expenditure>();
        }

        public T TranslateTo<T>(object fromObject)
        {
            return (T)AutoMapper.Mapper.Map(fromObject, fromObject.GetType(), typeof(T));
        }

        public T TranslateTo<T>(object sourceObject, object targetObject)
        {
            return (T)AutoMapper.Mapper.Map(sourceObject, targetObject, sourceObject.GetType(), typeof(T));
        }
    }
}