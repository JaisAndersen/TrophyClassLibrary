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
    public class TrophyTests
    {
        [TestMethod()]
        public void TrophyTest()
        {
            Trophy trophy = new Trophy();
            trophy.Id = 1;
            trophy.Competition = "Cykling";
            trophy.Year = 1990;

            Assert.AreEqual(1, trophy.Id);
            Assert.AreEqual("Cykling", trophy.Competition);
            Assert.AreEqual(1990, trophy.Year);

            Assert.ThrowsException<ArgumentNullException>(() => trophy.Competition = null);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Competition = "AB");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Year = 1969);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Year = 2025);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Trophy trophy = new Trophy();
            trophy.Id = 1;
            trophy.Competition = "CompetitionName";
            trophy.Year = 2000;
            string result = trophy.ToString();
            Assert.AreEqual("Id: 1, Competition: CompetitionName, Year: 2000", result);
        }
    }
}