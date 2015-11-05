namespace HouseAccounting.DTO.Translators
{
    public interface ITranslator
    {
        T TranslateTo<T>(object sourceObject);

        T TranslateTo<T>(object sourceObject, object targetObject);
    }
}