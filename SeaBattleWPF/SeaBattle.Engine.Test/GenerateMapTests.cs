﻿using NUnit.Framework;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Test
{
    [TestFixture]
    public class GenerateMapTests
    {
        [Test]
        [Repeat(1000)]
        public void Generate_Map_Test()
        {
            var map = new Map();

            Assert.IsNotNull(map.MapBlocks[0, 0]);
        }
    }
}
