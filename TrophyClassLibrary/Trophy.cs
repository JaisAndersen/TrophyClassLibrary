namespace TrophyClassLibrary
{
    public class Trophy
    {
        private string competition;

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
        public int Year { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Competition: {Competition}, Year: {Year}";
        }
    }
}
