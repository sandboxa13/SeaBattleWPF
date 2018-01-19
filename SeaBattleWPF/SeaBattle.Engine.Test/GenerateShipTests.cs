using NUnit.Framework;
using SeaBattle.Engine.Common.MapLogic;
using SeaBattle.Engine.Ships;

namespace SeaBattle.Engine.Test
{
    [TestFixture]
    public class GenerateShipTests
    {
        [Test]
        [Repeat(100)]
        public void Generate_One_Hp_Ship_Test()
        {
            var ship = new OneHpShip(new Map());
                
            Assert.AreEqual(1, ship.Hp);
            Assert.AreEqual(true, ship.IsAlive);    
            Assert.IsNotNull(ship.Coords);
        }

        [Test]
        [Repeat(100)]
        public void Generate_Two_Hp_Ship_Test()
        {
            var ship = new TwoHpShip(new Map());

            Assert.AreEqual(2, ship.Hp);
            Assert.AreEqual(true, ship.IsAlive);
            Assert.IsNotNull(ship.Coords);
        }
    }
}
