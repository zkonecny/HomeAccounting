using System.Collections.Generic;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Web.Models.Persons
{
    public class PersonDeleteViewModel : ViewModelBase
    {
        private readonly ITranslator translator;
        private readonly int personId;
        private readonly IGenericRepository<Person> personRepository;
        public readonly string Title = "Smazat osobu";

        public PersonDto Person { get; private set; }

        public PersonDeleteViewModel()
        {
            this.Person = new PersonDto();
        }

        public PersonDeleteViewModel(int personId, IGenericRepository<Person> personRepository, ITranslator translator)
        {
            this.personId = personId;
            this.personRepository = personRepository;
            this.translator = translator;
        }

        protected override void SetupViewData()
        {
            base.SetupViewData();
            PageTitle = Title;
            var person = this.personRepository.FindById(personId);
            Person = this.translator.TranslateTo<PersonDto>(person);
        }
    }
}