using NUnit.Framework;
using SeaBattle.Engine.Common.CoordsHelper;
using SeaBattle.Engine.Common.Interfaces;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Test
{
    [TestFixture]
    public class CoordsGeneratorTests
    {
        private IGenerateRandomCoords _generateRandom;
        private Map _map;

        [Test]
        [Repeat(50000)]
        public void One_Hp_Generator_Coords_Test()
        {
            _map = new Map();
            _generateRandom = new GenerateRandomCoordsOneHp(_map);
            var coord = _generateRandom.GenerateCoords();

            var x = coord[0].X;
            var y = coord[0].Y;

            Assert.AreEqual(1, coord.Count);
            Assert.That(x, Is.InRange(0, 9));
            Assert.That(y, Is.InRange(0, 9));
        }
            
        [Test]
        [Repeat(50000)]
        public void Two_Hp_Generator_Coords_Test()
        {
            _map = new Map();
            _generateRandom = new GenerateRandomCoordsTwoHp(_map);
            var coord = _generateRandom.GenerateCoords();

            var x1 = coord[0].X;
            var y1 = coord[0].Y;

            var x2 = coord[1].X;
            var y2 = coord[1].Y;

            Assert.AreEqual(2, coord.Count);

            Assert.That(x1, Is.InRange(0, 9));
            Assert.That(y1, Is.InRange(0, 9));
            Assert.That(x2, Is.InRange(0, 9));
            Assert.That(y2, Is.InRange(0, 9));
        }


        public void Three_Hp_Generator_Coords_Test()
        {
            _map = new Map();
            _generateRandom = new GenerateRandoomCoordsThreeHp(_map);
            var coord = _generateRandom.GenerateCoords();

            var x1 = coord[0].X;
            var y1 = coord[0].Y;

            var x2 = coord[1].X;
            var y2 = coord[1].Y;

            var x3 = coord[2].X;
            var y3 = coord[2].Y;

            Assert.AreEqual(3, coord.Count);

            Assert.That(x1, Is.InRange(0, 9));
            Assert.That(y1, Is.InRange(0, 9));
            Assert.That(x2, Is.InRange(0, 9));
            Assert.That(y2, Is.InRange(0, 9));
            Assert.That(x3, Is.InRange(0, 9));
            Assert.That(y3, Is.InRange(0, 9));
        }
    }
}
