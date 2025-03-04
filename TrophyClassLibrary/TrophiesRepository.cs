using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TrophyClassLibrary
{
    public class TrophiesRepository
    {
        private List<Trophy> trophies = new();
        private int nextId = 1;

        public TrophiesRepository()
        {
            trophies.Add(new Trophy() { Id = nextId++, Competition = "Cykel VM", Year = 1991 });
            trophies.Add(new Trophy() { Id = nextId++, Competition = "Fodbold VM", Year = 1992 });
            trophies.Add(new Trophy() { Id = nextId++, Competition = "Håndbold VM", Year = 1993 });
            trophies.Add(new Trophy() { Id = nextId++, Competition = "Curling VM", Year = 1994 });
            trophies.Add(new Trophy() { Id = nextId++, Competition = "Skak VM", Year = 1995 });
        }        
        public IEnumerable<Trophy> Get(int? yearFilter = null, string? sortByCompetition = null, int? sortByYear = null)
        {
            IEnumerable<Trophy> result = new List<Trophy>(trophies);
            if (yearFilter != null)
            {
                return result;
            }
            return result;
        }
    }
}
