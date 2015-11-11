using System.Collections.Generic;
using System.Linq;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Web.Models.Categories
{
    public class CategoryCreateViewModel : ViewModelBase
    {
        private readonly IPersonRepository personRepository;
        private readonly ITranslator translator;
        public readonly string Title = "Nová kategorie";

        public CategoryDto Category { get; set; }

        public IEnumerable<PersonDto> Persons { get; private set; }

        public int SelectedPersonId { get; set; }

        public CategoryCreateViewModel()
        {
            Category = new CategoryDto();
        }

        public CategoryCreateViewModel(IPersonRepository personRepository, ITranslator translator)
        {
            this.personRepository = personRepository;
            this.translator = translator;
            Category = new CategoryDto();
        }

        protected override void SetupViewData()
        {
            base.SetupViewData();
            PageTitle = Title;
            var persons = personRepository.GetAll();
            Persons = persons.Select(person => translator.TranslateTo<PersonDto>(person)).ToList();
        }
    }
}