using System.Collections.Generic;
using System.Threading;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Web.Models.Persons
{
    public class PersonDetailsViewModel : ViewModelBase
    {
        private readonly ITranslator translator;
        private readonly int personId;
        private readonly IGenericRepository<Person> personRepository;
        public readonly string Title = "Detail osoby";

        public PersonDto Person { get; private set; }

        public PersonDetailsViewModel()
        {
            Person = new PersonDto();
        }

        public PersonDetailsViewModel(int personId, IGenericRepository<Person> personRepository, ITranslator translator)
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