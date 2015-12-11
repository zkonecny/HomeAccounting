using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.Incomes
{
    public class IncomeDetailsViewModel : ViewModelBase
    {
        protected readonly ITranslator translator;
        protected readonly int id;
        protected readonly IIncomeRepository incomeRepository;
        public readonly string Title = "Detail příjmu";

        public IncomeDto Income { get; private set; }

        public IncomeDetailsViewModel()
        {
            Income = new IncomeDto();
        }

        public IncomeDetailsViewModel(int id, IIncomeRepository incomeRepository, ITranslator translator)
        {
            this.id = id;
            this.incomeRepository = incomeRepository;
            this.translator = translator;
        }

        protected override void SetupViewData()
        {
            base.SetupViewData();
            PageTitle = Title;
            var income = incomeRepository.FindById(id);
            Income = this.translator.TranslateTo<IncomeDto>(income);
        }
    }
}