using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseAccounting.Infrastructure.Repositories.DataClasses
{
    [Table("Household")]
    public class HouseholdEntity : DataEntity
    {
        [Required(ErrorMessage = "Household Name is Required")]
        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column("Description")]
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
