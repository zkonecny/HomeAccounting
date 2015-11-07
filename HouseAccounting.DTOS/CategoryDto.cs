using System.ComponentModel.DataAnnotations;

namespace HouseAccounting.DTOS
{
    public class CategoryDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Název")]
        public string Name { get; set; }

        [Display(Name = "Popis")]
        public string Description { get; set; }

        [Display(Name = "Osoba")]
        public PersonDto Person { get; set; }

        //[Display(Name = "Osoba")]
        //public PersonDto Person { get; set; }
    }
}