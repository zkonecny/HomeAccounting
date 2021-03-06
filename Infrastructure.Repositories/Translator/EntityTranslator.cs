﻿using HouseAccounting.Infrastructure.Repositories.Entities;
using HouseAccounting.Infrastructure.Repositories.Mapper;
using HouseAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories.Translator
{
    public class EntityTranslator : IEntityTranslator
    {
        static EntityTranslator()
        {
            AutoMapper.Mapper.CreateMap<Person, PersonEntity>();
            AutoMapper.Mapper.CreateMap<PersonEntity, Person>();

            AutoMapper.Mapper.CreateMap<IncomeCategory, IncomeCategoryEntity>().ForMember(x => x.Person, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<IncomeCategoryEntity, IncomeCategory>().ForMember(x => x.Person, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<ExpenditureCategory, ExpenditureCategoryEntity>().ForMember(x => x.Person, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<ExpenditureCategoryEntity, ExpenditureCategory>().ForMember(x => x.Person, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<Income, IncomeEntity>().ForMember(x => x.Person, opt => opt.Ignore())
                .ForMember(x => x.Category, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<IncomeEntity, Income>().ForMember(x => x.Person, opt => opt.Ignore())
                .ForMember(x => x.Category, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<Expenditure, ExpenditureEntity>().ForMember(x => x.Person, opt => opt.Ignore())
                .ForMember(x => x.Category, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<ExpenditureEntity, Expenditure>().ForMember(x => x.Person, opt => opt.Ignore())
                .ForMember(x => x.Category, opt => opt.Ignore());
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