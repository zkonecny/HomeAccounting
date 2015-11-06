using System.ComponentModel.DataAnnotations;

namespace HouseAccounting.DTOS
{
    public class PersonDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Jméno")]
        public string FullName => FirstName + " " + LastName;
    }
}
