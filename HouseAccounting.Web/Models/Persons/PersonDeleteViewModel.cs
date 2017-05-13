using System.Collections.Generic;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouseAccounting.Business.Classes;
using HouseAccounting.Business.Repositories;

namespace HouseAccounting.Web.Models.Persons
{
    public class PersonDeleteViewModel : ViewModelBase
    {
        private readonly ITranslator translator;
        private readonly int id;
        private readonly IPersonRepository repository;
        public readonly string Title = "Smazat osobu";

        public PersonDto Person { get; private set; }

        public PersonDeleteViewModel()
        {
            Person = new PersonDto();
        }

        public PersonDeleteViewModel(int id, IPersonRepository repository, ITranslator translator)
        {
            this.id = id;
            this.repository = repository;
            this.translator = translator;
        }

        protected override void SetupViewData(int page)
        {
            base.SetupViewData(page);
            PageTitle = Title;
            var person = repository.FindById(id);
            Person = translator.TranslateTo<PersonDto>(person);
        }
    }
}