namespace HouseAccounting.Web.Models
{
    public abstract class ViewModelBase
    {
        protected ViewModelBase()
        {
            IsViewModelLoaded = false;
        }

        public string PageTitle { get; set; }

        public bool IsViewModelLoaded { get; set; }

        public void LoadViewModelData()
        {
            if (IsViewModelLoaded)
            {
                return;
            }

            SetupViewData();
            IsViewModelLoaded = true;
        }

        protected virtual void SetupViewData()
        {
        }
    }
}