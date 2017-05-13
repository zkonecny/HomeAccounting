using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.Incomes
{
    public class IncomeDeleteViewModel : ViewModelBase
    {
        private readonly ITranslator translator;
        private readonly int id;
        private readonly IIncomeRepository incomeRepository;
        public readonly string Title = "Smazat příjem";

        public IncomeDto Income { get; private set; }

        public IncomeDeleteViewModel()
        {
            this.Income = new IncomeDto();
        }

        public IncomeDeleteViewModel(int id, IIncomeRepository incomeRepository, ITranslator translator)
        {
            this.id = id;
            this.incomeRepository = incomeRepository;
            this.translator = translator;
        }

        protected override void SetupViewData(int page)
        {
            base.SetupViewData(page);
            PageTitle = Title;
            var category = incomeRepository.FindById(id);
            Income = translator.TranslateTo<IncomeDto>(category);
        }
    }
}