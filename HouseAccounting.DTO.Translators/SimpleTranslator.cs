using AutoMapper;
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
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<Category, CategoryDto>();
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