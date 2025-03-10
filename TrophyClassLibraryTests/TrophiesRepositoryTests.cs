using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrophyClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TrophyClassLibrary.Tests
{
    [TestClass()]
    public class TrophiesRepositoryTests
    {
        TrophiesRepository repo;

        [TestInitialize]
        public void Initialize()
        {
            repo = new TrophiesRepository();            
        }

        [TestMethod()]
        public void GetActorByIdTest()
        {
            Assert.IsNotNull(repo.GetById(1));
            Assert.IsNull(repo.GetById(999));
        }
        [TestMethod()]      
        public void AddTrophyTest()
        {
            Trophy t = new Trophy() { Competition = "testCompetition", Year = 1994 };
            repo.Add(t);
            Assert.AreEqual(6, repo.Get().Count());
            Assert.ThrowsException<ArgumentNullException>(() => repo.Add(null));
        }
        [TestMethod()]
        public void GetTrophyTest()
        {
            IEnumerable<Trophy> trophies = repo.Get();
            Assert.AreEqual(5, trophies.Count());
            Assert.AreEqual(trophies.First().Competition, "Cykel VM");

            IEnumerable<Trophy> filteredTrophies = repo.Get(yearFilter: 1991);
            Assert.AreEqual(1, filteredTrophies.Count());

            IEnumerable<Trophy> sortedTrophiesAsc = repo.Get(sortBy: "competition_asc");
            Assert.AreEqual("Curling VM", sortedTrophiesAsc.First().Competition);
            Assert.AreEqual("Skak VM", sortedTrophiesAsc.Last().Competition);

            IEnumerable<Trophy> sortedTrophiesDsc = repo.Get(sortBy: "competition_dsc");
            Assert.AreEqual("Skak VM", sortedTrophiesDsc.First().Competition);
            Assert.AreEqual("Curling VM", sortedTrophiesDsc.Last().Competition);

            IEnumerable<Trophy> sortedTrophies2Asc = repo.Get(sortBy: "year_asc");
            Assert.AreEqual("Cykel VM", sortedTrophies2Asc.First().Competition);
            Assert.AreEqual("Skak VM", sortedTrophies2Asc.Last().Competition);

            IEnumerable<Trophy> sortedTrophies2Dsc = repo.Get(sortBy: "year_dsc");
            Assert.AreEqual("Skak VM", sortedTrophies2Dsc.First().Competition);
            Assert.AreEqual("Cykel VM", sortedTrophies2Dsc.Last().Competition);
        }
        [TestMethod()]
        public void RemoveTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => repo.Remove(100));
            Assert.AreEqual(1, repo.Remove(1)?.Id);
            Assert.ThrowsException<ArgumentNullException>(() => repo.Remove(1));
            Assert.AreEqual(4, repo.Get().Count());
        }
        [TestMethod()]
        public void UpdateTest()
        {
            Assert.AreEqual(5, repo.Get().Count());
            Trophy t = new() { Competition = "Test", Year = 2020 };
            Assert.ThrowsException<ArgumentNullException>(() => repo.Update(100, t));
            Assert.AreEqual(1, repo.Update(1, t)?.Id);
            Assert.AreEqual(5, repo.Get().Count());
        }
    }
}