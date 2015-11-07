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
        private readonly int id;
        private readonly IGenericRepository<Person> repository;
        public readonly string Title = "Detail osoby";

        public PersonDto Person { get; private set; }

        public PersonDetailsViewModel()
        {
            Person = new PersonDto();
        }

        public PersonDetailsViewModel(int id, IGenericRepository<Person> repository, ITranslator translator)
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