using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.IncomeCategories
{
    public class IncomeCategoryDeleteViewModel : ViewModelBase
    {
        private readonly ITranslator translator;
        private readonly int id;
        private readonly IIncomeCategoryRepository repository;
        public readonly string Title = "Smazat kategorii";

        public CategoryDto Category { get; private set; }

        public IncomeCategoryDeleteViewModel()
        {
            this.Category = new CategoryDto();
        }

        public IncomeCategoryDeleteViewModel(int id, IIncomeCategoryRepository repository, ITranslator translator)
        {
            this.id = id;
            this.repository = repository;
            this.translator = translator;
        }

        protected override void SetupViewData(int page)
        {
            base.SetupViewData(page);
            PageTitle = Title;
            var category = repository.FindById(id);
            Category = translator.TranslateTo<CategoryDto>(category);
        }
    }
}