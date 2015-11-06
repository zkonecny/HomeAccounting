using System.Collections.Generic;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Web.Models.Persons
{
    public class PersonCreateViewModel : ViewModelBase
    {
        public readonly string Title = "Nová osoba";

        public PersonDto Person { get; set; }

        public PersonCreateViewModel()
        {
            this.Person = new PersonDto();
        }
    }
}