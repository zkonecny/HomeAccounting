using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Web.Models.Categories
{
    public class CategoryDeleteViewModel : ViewModelBase
    {
        private readonly ITranslator translator;
        private readonly int id;
        private readonly IGenericRepository<Category> repository;
        public readonly string Title = "Smazat kategorii";

        public CategoryDto Category { get; private set; }

        public CategoryDeleteViewModel()
        {
            this.Category = new CategoryDto();
        }

        public CategoryDeleteViewModel(int id, IGenericRepository<Category> repository, ITranslator translator)
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