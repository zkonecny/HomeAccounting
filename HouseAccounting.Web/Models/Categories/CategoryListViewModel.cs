using System.Collections.Generic;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Web.Models.Categories
{
    public class CategoryListViewModel : ViewModelBase
    {
        private readonly ITranslator translator;
        private readonly ICategoryRepository repository;
        public readonly string Title = "Seznam kategorií";

        public IEnumerable<CategoryDto> Categories { get; private set; }

        public CategoryListViewModel(ICategoryRepository repository, ITranslator translator)
        {
            this.repository = repository;
            this.translator = translator;
        }

        protected override void SetupViewData()
        {
            base.SetupViewData();
            LoadData();
        }

        private void LoadData()
        {
            PageTitle = Title;

            var categories = this.repository.GetAll();

            Categories = this.translator.TranslateTo<IEnumerable<CategoryDto>>(categories);
        }
    }
}