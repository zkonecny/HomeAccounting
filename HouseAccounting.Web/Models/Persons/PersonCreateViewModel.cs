using HouseAccounting.DTOS;

namespace HouseAccounting.Web.Models.Persons
{
    public class PersonCreateViewModel : ViewModelBase
    {
        public readonly string Title = "Nová osoba";

        public PersonDto Person { get; set; }

        public PersonCreateViewModel()
        {
            this.Person = new PersonDto();
        }
    }
}