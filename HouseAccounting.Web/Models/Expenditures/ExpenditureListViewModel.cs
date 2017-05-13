using System.Linq;
using System.Collections.Generic;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouseAccounting.Web.Models.Home;
using HouseAccounting.Business.Services;

namespace HouseAccounting.Web.Models.Expenditures
{
    public class ExpenditureListViewModel : HomeIndexViewModel
    {
        private readonly IExpenditureRepository expenditureRepository;
        public readonly string Title = "Seznam výdajů";

        public IEnumerable<ExpenditureDto> Expenditures { get; private set; }

        public int SelectedMonth { get; set; }

        public ExpenditureListViewModel(
            IPersonRepository personRepository, 
            ITranslator translator,
            IExpenditureRepository expenditureRepository,
            IExpenditureCategoryRepository expenditureCategoryRepository,
            IMonthlyStatisticsService monthlyStatisticsService)
             : base(personRepository, translator, expenditureCategoryRepository, monthlyStatisticsService)
        {
            this.expenditureRepository = expenditureRepository;
        }
       

        protected override void SetupViewData(int page)
        {
            base.SetupViewData(page);
            LoadData(page);
        }

        private void LoadData(int page)
        {
            PageTitle = Title;

            var expenditures = expenditureRepository.GetAll().OrderByDescending(expenditure => expenditure.Created);
            TotalItemCount = expenditures.Count();
            PageNumber = page;
            var skip = (page - 1) * PageSize;
            var pagedExpenditures = expenditures.Skip(skip).Take(PageSize).ToList();
            Expenditures = translator.TranslateTo<IEnumerable<ExpenditureDto>>(pagedExpenditures);
        }
    }
}