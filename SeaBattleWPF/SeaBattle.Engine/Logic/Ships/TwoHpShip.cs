using SeaBattle.Engine.Common.CoordsHelper;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Logic.Ships
{
    public class TwoHpShip : BaseShip
    {
        public TwoHpShip(Map map)
        {
            Hp = 2;

            RandomCoords = new GenerateRandomCoordsTwoHp(map);

            Coords = RandomCoords.GenerateCoords();
        }
    }
}
