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