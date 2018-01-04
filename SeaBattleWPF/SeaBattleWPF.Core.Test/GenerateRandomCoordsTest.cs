using NUnit.Framework;
using SeaBattleWPF.Core.Logic;
using SeaBattleWPF.Core.Logic.Interfaces;
using SeaBattleWPF.Core.Logic.Ships.CoordsHelper;

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
            _generateRandom = new GenerateRandomCoordsOneHp(map);
        }

        [Test]
        [Repeat(10000)]
        public void Generate_Coord_For_Two_Hp_Ship_Test()
        {           
            
        }

        [Test]
        [Repeat(10000)]
        public void Generate_Coord_For_One_Hp_Ship_Test()
        {
            var coord = _generateRandom.GenerateCoords();

            //var x = coord.X;
            //var y = coord.Y;

            //Assert.That(x, Is.InRange(1, 10));
            //Assert.That(y, Is.InRange(1, 10));
        }
    }
}
