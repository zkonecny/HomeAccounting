namespace HouseAccounting.DTOS
{
    public class PersonExpenditureDto
    {
        public CategoryDto ExpenditureCategory { get; set; }

        public int PersonId
        {
            get
            {
                if (ExpenditureCategory.Person != null)
                {
                    return ExpenditureCategory.Person.Id;
                }

                return 0;
            }
        }

        public string Text
        {
            get
            {
                var text = string.Empty;
                if (ExpenditureCategory.Person != null)
                {
                    text += ExpenditureCategory.Person.FirstName + " - ";
                }

                text += ExpenditureCategory.Name;
                return text;
            }
        }
    }
}
