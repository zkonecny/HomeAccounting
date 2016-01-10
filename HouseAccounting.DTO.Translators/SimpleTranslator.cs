using AutoMapper;
using HouseAccounting.Business.Classes;
using HouseAccounting.DTOS;
using HouserAccounting.Business.Classes;

namespace HouseAccounting.DTO.Translators
{
    public class SimpleTranslator : ITranslator
    {
        static SimpleTranslator()
        {
            Mapper.CreateMap<Person, PersonDto>();
            Mapper.CreateMap<PersonDto, Person>();

            Mapper.CreateMap<CategoryDto, IncomeCategory>();
            Mapper.CreateMap<IncomeCategory, CategoryDto>();

            Mapper.CreateMap<CategoryDto, ExpenditureCategory>();
            Mapper.CreateMap<ExpenditureCategory, CategoryDto>();

            Mapper.CreateMap<IncomeDto, Income>();
            Mapper.CreateMap<Income, IncomeDto>();

            Mapper.CreateMap<ExpenditureDto, Expenditure>();
            Mapper.CreateMap<Expenditure, ExpenditureDto>();

            Mapper.CreateMap<MonthlyItem, MonthlyItemDto>();
        }

        public T TranslateTo<T>(object fromObject)
        {
            //BasicValidations.AssertNotNull(fromObject, "fromObject");
            return (T) Mapper.Map(fromObject, fromObject.GetType(), typeof (T));
        }

        public T TranslateTo<T>(object sourceObject, object targetObject)
        {
            return (T) Mapper.Map(sourceObject, targetObject, sourceObject.GetType(), typeof (T));
        }
    }
}