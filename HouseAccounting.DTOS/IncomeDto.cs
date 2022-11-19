using System;
using System.ComponentModel.DataAnnotations;

namespace HouseAccounting.DTOS
{
    public class IncomeDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Datum")]
        public DateTime Created { get; set; }

        [Required]
        [Display(Name = "Popis")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Částka")]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "Kategorie")]
        public CategoryDto Category { get; set; }

        [Display(Name = "Osoba")]
        public PersonDto Person { get; set; }
    }
}
