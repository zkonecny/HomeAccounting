﻿using HouseAccounting.Business.Services;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseAccounting.Web.Models.Expenditures
{
    public class ExpenditureMonthlyViewModel : ViewModelBase
    {
        protected readonly ITranslator translator;
        protected readonly IPersonRepository personRepository;
        protected readonly IExpenditureCategoryRepository expenditureCategoryRepository;
        protected readonly IMonthlyStatisticsService monthlyStatisticsService;

        public ExpenditureMonthlyViewModel(IPersonRepository personRepository,
            ITranslator translator,
            IExpenditureCategoryRepository expenditureCategoryRepository,
            IMonthlyStatisticsService monthlyStatisticsService)
        {
            this.personRepository = personRepository;
            this.translator = translator;
            this.expenditureCategoryRepository = expenditureCategoryRepository;
            this.monthlyStatisticsService = monthlyStatisticsService;
        }

        public IEnumerable<MonthlyItemDto> MonthlyItems { get; private set; }

        protected override void SetupViewData()
        {
            base.SetupViewData();
            LoadData();
        }

        private void LoadData()
        {
            LoadMonthlyStatistics();
        }

        private void LoadMonthlyStatistics()
        {
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;

            var monthlyItems = monthlyStatisticsService.GetMonthlyStatistics(year, month);

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