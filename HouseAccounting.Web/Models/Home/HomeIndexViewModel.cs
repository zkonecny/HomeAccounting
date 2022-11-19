using HouseAccounting.Business.Services;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using System.Collections.Generic;

namespace HouseAccounting.Web.Models.Home
{
    public class HomeIndexViewModel : ViewModelBase
    {
        protected readonly ITranslator translator;
        protected readonly IPersonRepository personRepository;
        protected readonly IExpenditureCategoryRepository expenditureCategoryRepository;
        protected readonly IMonthlyStatisticsService monthlyStatisticsService;

        public HomeIndexViewModel(IPersonRepository personRepository,
            ITranslator translator,
            IExpenditureCategoryRepository expenditureCategoryRepository,
            IMonthlyStatisticsService monthlyStatisticsService)
        {
            this.personRepository = personRepository;
            this.translator = translator;
            this.expenditureCategoryRepository = expenditureCategoryRepository;
            this.monthlyStatisticsService = monthlyStatisticsService;
        }

        public IEnumerable<PersonExpenditureDto> PersonExpenditures { get; private set; }

        public IEnumerable<MonthlyItemDto> MonthlyItems { get; private set; }

        protected override void SetupViewData(int page)
        {
            base.SetupViewData(page);
            LoadData();
        }

        private void LoadData()
        {
            LoadQuickPersonExpenditures();
            LoadMonthlyStatistics();
        }

        private void LoadQuickPersonExpenditures()
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

        private void LoadMonthlyStatistics()
        {
            var monthlyItems = monthlyStatisticsService.GetAllMonthlyStatistics();
            var monthlyItemsDto = new List<MonthlyItemDto>();
            foreach (var item in monthlyItems)
            {
                var monthlyItemDto = translator.TranslateTo<MonthlyItemDto>(item);
                monthlyItemsDto.Add(monthlyItemDto);
            }

            MonthlyItems = monthlyItemsDto;
        }
    }
}