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
        
         public IEnumerable<Trophy> Get(int? yearFilter = null, string? sortBy = null)
        {
            IEnumerable<Trophy> result = new List<Trophy>(trophies);
            if (yearFilter != null)
            {
                return trophies.Where(t => t.Year == yearFilter.Value);
            }

            if (sortBy != null)
            {
                sortBy = sortBy.ToLower();
                switch (sortBy)
                {
                    case "Competition":
                    case "title_asc":
                        result = result.OrderBy(t => t.Competition);
                        break;
                    case "title_desc":
                        result = result.OrderByDescending(t => t.Competition);
                        break;
                    case "year":
                    case "year_asc":
                        result = result.OrderBy(t => t.Year);
                        break;
                    case "year_desc":
                        result = result.OrderByDescending(t => t.Year);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public Trophy? GetById(int id)
        {
            return trophies.Find(trophy => trophy.Id == id);
        }

        public Trophy Add(Trophy trophy)
        {
            if (trophy == null)
                throw new ArgumentNullException("Trophy must not be null");
            trophy.Id = nextId++;
            trophies.Add(trophy);
            return trophy;
        }

        public Trophy? Remove(int id)
        {
            Trophy? trophy = GetById(id);
            if (trophy == null)
            {
                throw new ArgumentNullException("Thophy must not be null");
            }
            trophies.Remove(trophy);
            return trophy;
        }

        public Trophy? Update(int id, Trophy trophy)
        {
            Trophy? trophyToUpdate = GetById(id);
            if (trophyToUpdate == null)
            {
                return null;
            }
            trophyToUpdate.Competition = trophy.Competition;
            trophyToUpdate.Year = trophy.Year;
            return trophyToUpdate;
        }
    }
}
