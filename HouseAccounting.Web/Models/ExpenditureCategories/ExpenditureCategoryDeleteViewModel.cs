using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.ExpenditureCategories
{
    public class ExpenditureCategoryDeleteViewModel : ViewModelBase
    {
        private readonly ITranslator translator;
        private readonly int id;
        private readonly IExpenditureCategoryRepository repository;
        public readonly string Title = "Smazat kategorii";

        public CategoryDto Category { get; private set; }

        public ExpenditureCategoryDeleteViewModel()
        {
            this.Category = new CategoryDto();
        }

        public ExpenditureCategoryDeleteViewModel(int id, IExpenditureCategoryRepository repository, ITranslator translator)
        {
            this.id = id;
            this.repository = repository;
            this.translator = translator;
        }

        protected override void SetupViewData()
        {
            base.SetupViewData();
            PageTitle = Title;
            var category = repository.FindById(id);
            Category = translator.TranslateTo<CategoryDto>(category);
        }
    }
}