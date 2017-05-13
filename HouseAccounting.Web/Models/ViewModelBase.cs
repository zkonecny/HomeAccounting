using System;
using System.Configuration;

namespace HouseAccounting.Web.Models
{
    public abstract class ViewModelBase
    {
        static int pageSize;

        protected ViewModelBase()
        {
            IsViewModelLoaded = false;
        }

        public string PageTitle { get; set; }

        public bool IsViewModelLoaded { get; set; }

        public int PageSize
        {
            get
            {
                if (pageSize == 0)
                {
                    pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
                }

                return pageSize;
            }
        }

        public int PageNumber { get; protected set; }

        public int TotalItemCount { get; protected set; }

        public void LoadViewModelData(int page = 1)
        {
            if (IsViewModelLoaded)
            {
                return;
            }

            SetupViewData(page);
            IsViewModelLoaded = true;
        }

        protected virtual void SetupViewData(int page)
        {
        }
    }
}