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
        private readonly int id;
        private readonly IGenericRepository<Person> repository;
        public readonly string Title = "Smazat osobu";

        public PersonDto Person { get; private set; }

        public PersonDeleteViewModel()
        {
            Person = new PersonDto();
        }

        public PersonDeleteViewModel(int id, IGenericRepository<Person> repository, ITranslator translator)
        {
            this.id = id;
            this.repository = repository;
            this.translator = translator;
        }

        protected override void SetupViewData()
        {
            base.SetupViewData();
            PageTitle = Title;
            var person = repository.FindById(id);
            Person = translator.TranslateTo<PersonDto>(person);
        }
    }
}