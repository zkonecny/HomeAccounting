using System.Collections.Generic;

namespace HouseAccounting.DTOS
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public PersonDto Person { get; set; }
    }
}