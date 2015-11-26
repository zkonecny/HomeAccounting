namespace HouseAccounting.Infrastructure.Repositories.Mapper
{
    public interface IEntityTranslator
    {
        T TranslateTo<T>(object sourceObject);

        T TranslateTo<T>(object sourceObject, object targetObject);
    }
}