using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseAccounting.Infrastructure.Repositories.DataClasses
{
    [Table("Income")]
    public class IncomeEntity : DataEntity
    {
        [Required(ErrorMessage = "Income Created is Required")]
        [Column("Created")]
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Income Amount is Required")]
        [Column("Amount")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Income Category is Required")]
        public CategoryEntity Category { get; set; }

        [Required(ErrorMessage = "Income User is Required")]
        public UserEntity User { get; set; }
    }
}
