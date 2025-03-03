namespace TrophyClassLibrary
{
    public class Trophy
    {
        private string competition;
        private int year;

        public int Id { get; set; }
        public string Competition
        {
            get => competition;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Competition must not be null!");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Competition must be at least 3 charachters long!");
                }
                competition = value;
            }
        }
        public int Year
        {
            get => year;
            set
            {
                if (value < 1970)
                {
                    throw new ArgumentOutOfRangeException("Year must be after 1969!");
                }
                if (value > 2024)
                {
                    throw new ArgumentOutOfRangeException("Year must be before 2025!");
                }
                year = value;
            }
        }
        public override string ToString()
        {
            return $"Id: {Id}, Competition: {Competition}, Year: {Year}";
        }
    }
}
