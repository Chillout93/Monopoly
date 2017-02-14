using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly.Test
{
    [TestClass]
    public class DiceTest
    {
        Dice die;

        [ClassInitialize]
        public void ClassInitialize()
        {
            die = new Dice();
        }
        
        [TestMethod]
        public void Dice_WithRoll_GeneratesRandomNumber(TestContext context)
        {
            IList<int> randomNumbers = new List<int>();
            for (int i = 0; i < 1000; i++)
                randomNumbers.Add(die.RollBoth());

            Assert.AreNotEqual(1, randomNumbers.GroupBy(x => x).Count());
        }

        [TestMethod]
        public static void Dice_WithDoubleRoll_AddsTwoDie(TestContext context)
        {
               
        }

        [TestMethod]
        public static void Dice_IsDoubleRoll_WithSingleRollRaisesException(TestContext context)
        {

        }

        [TestMethod]
        public static void Dice_IsDoubleRoll_ReturnsTrueWhenDouble(TestContext context)
        {

        }

        [TestMethod]
        public static void Dice_GetLastRoll_WithOneRollStillReturns(TestContext context)
        {

        }
    }
}
