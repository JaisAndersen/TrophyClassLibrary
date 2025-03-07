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
        public void AddTrophyTest()
        {
            Trophy t = new Trophy() { Competition = "testCompetition", Year = 1994 };
            repo.Add(t);
            Assert.AreEqual(6, repo.Get().Count());
            Assert.ThrowsException<ArgumentNullException>(() => repo.Add(null));
        }
        [TestMethod()]
        public void RemoveTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => repo.Remove(100));
            Assert.AreEqual(1, repo.Remove(1)?.Id);
            Assert.ThrowsException<ArgumentNullException>(() => repo.Remove(1));
            Assert.AreEqual(4, repo.Get().Count());
        }
    }
}