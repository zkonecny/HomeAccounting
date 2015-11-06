using HouseAccounting.DTO.Translators;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Web.Models.Persons
{
    public class PersonEditViewModel : PersonDetailsViewModel
    {
        public PersonEditViewModel()
        {
        }

        public PersonEditViewModel(int personId, IGenericRepository<Person> personRepository, ITranslator translator)
            : base(personId, personRepository, translator)
        {

        }
    }
}