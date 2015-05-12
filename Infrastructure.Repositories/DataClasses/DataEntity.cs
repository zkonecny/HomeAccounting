using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseAccounting.Infrastructure.Repositories.DataClasses
{
    public class DataEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
