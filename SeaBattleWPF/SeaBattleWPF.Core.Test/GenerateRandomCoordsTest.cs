using NUnit.Framework;
using SeaBattleWPF.Core.Logic;
using SeaBattleWPF.Core.Logic.Interfaces;

namespace SeaBattleWPF.Core.Test
{
    [TestFixture]
    public class GenerateRandomCoordsTest
    {
        private IGenerateRandomCoords _generateRandom;

        [SetUp] 
        public void Init()
        {
            var map = new Map();
            _generateRandom = new GenerateRandomCoords(map);
        }

        [Test]
        [Repeat(10000)]
        public void Generate_Coord_For_Two_Hp_Ship_Test()
        {           
            var coord = _generateRandom.GenerateCoordForTwoHpShip();

            var x1 = coord[0].X;

            var x2 = coord[1].X;

            Assert.That(x2, Is.InRange(x2, x1 + 1));
            Assert.That(x2, Is.InRange(x2, x1 - 1));
            Assert.That(x2, Is.InRange(x2, x1 + 10));
            Assert.That(x2, Is.InRange(x2, x1 - 10));
        }

        [Test]
        [Repeat(10000)]
        public void Generate_Coord_For_One_Hp_Ship_Test()
        {
            var coord = _generateRandom.GenerateCoordForOneHpShip();

            var x = coord.X;
            var y = coord.Y;

            Assert.That(x, Is.InRange(1, 100));
            Assert.That(y, Is.InRange(1, 100));
        }
    }
}
