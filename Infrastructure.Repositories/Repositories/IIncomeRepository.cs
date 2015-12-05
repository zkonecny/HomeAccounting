﻿using System.Collections.Generic;
using HouserAccounting.Business.Classes;

namespace HouseAccounting.Infrastructure.Repositories.Repositories
{
    public interface IIncomeRepository
    {
        void Add(Income income);
        Income FindById(int id);
        IEnumerable<Income> GetAll();
        void Remove(Income income);
        void Update(Income income);
    }
}