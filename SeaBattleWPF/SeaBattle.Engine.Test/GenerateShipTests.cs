using NUnit.Framework;
using SeaBattle.Engine.Common.MapLogic;
using SeaBattle.Engine.Logic.Ships;

namespace SeaBattle.Engine.Test
{
    [TestFixture]
    public class GenerateShipTests
    {
        [Test]
        public void Generate_One_Hp_Ship_Test()
        {
            var ship = new OneHpShip(1, new Map());
                
            Assert.AreEqual(1, ship.Hp);
            Assert.AreEqual(true, ship.IsAlive);    
            Assert.IsNotNull(ship.Coords);
        }

        [Test]
        public void Generate_Two_Hp_Ship_Test()
        {
            var ship = new TwoHpShip(2, new Map());

            Assert.AreEqual(2, ship.Hp);
            Assert.AreEqual(true, ship.IsAlive);
            Assert.IsNotNull(ship.Coords);
        }
    }
}
