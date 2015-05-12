using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HouseAccounting.Infrastructure.Repositories.DataClasses
{
    [Table("Expenditure")]
    public class ExpenditureEntity : DataEntity
    {
        [Required(ErrorMessage = "Expenditure Created is Required")]
        [Column("Created")]
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Expenditure Amount is Required")]
        [Column("Amount")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Expenditure Category is Required")]
        public CategoryEntity Category { get; set; }

        [Required(ErrorMessage = "Expenditure User is Required")]
        public UserEntity User { get; set; }
    }
}
