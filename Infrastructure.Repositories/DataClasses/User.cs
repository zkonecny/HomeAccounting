using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseAccounting.Infrastructure.Repositories.DataClasses
{
    [Table("User")]
    public class UserEntity : DataEntity
    {
        [Required(ErrorMessage = "User FirstName is Required")]
        [Column("FirstName")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "User LastName is Required")]
        [Column("LastName")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column("BornOn")]
        public DateTime? BornOn { get; set; }

        [Required(ErrorMessage = "User LastName is Required")]
        public HouseholdEntity Household { get; set; }
    }
}
