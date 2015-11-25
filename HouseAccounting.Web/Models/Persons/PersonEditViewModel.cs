using HouseAccounting.DTO.Translators;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.Persons
{
    public class PersonEditViewModel : PersonDetailsViewModel
    {
        public PersonEditViewModel()
        {
        }

        public PersonEditViewModel(int id, IPersonRepository repository, ITranslator translator)
            : base(id, repository, translator)
        {

        }
    }
}