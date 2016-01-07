using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseAccounting.Web.Models.Home
{
    public class HomeIndexViewModel : ViewModelBase
    {
        protected readonly ITranslator translator;
        protected readonly IPersonRepository personRepository;
        protected readonly IExpenditureCategoryRepository expenditureCategoryRepository;

        public HomeIndexViewModel(IPersonRepository personRepository, ITranslator translator, IExpenditureCategoryRepository expenditureCategoryRepository)
        {
            this.personRepository = personRepository;
            this.translator = translator;
            this.expenditureCategoryRepository = expenditureCategoryRepository;
        }

        public IEnumerable<PersonExpenditureDto> PersonExpenditures { get; private set; }

        protected override void SetupViewData()
        {
            base.SetupViewData();
            LoadData();
        }

        private void LoadData()
        {
            var personExpenditures = new List<PersonExpenditureDto>();

            var expendituresCategories = expenditureCategoryRepository.GetAll();

            foreach (var expenditureCategory in expenditureCategoryRepository.GetAll())
            {
                var personExpenditureDto = new PersonExpenditureDto();
                personExpenditureDto.ExpenditureCategory = translator.TranslateTo<CategoryDto>(expenditureCategory);

                personExpenditures.Add(personExpenditureDto);
            }

            PersonExpenditures = personExpenditures;
        }
    }
}