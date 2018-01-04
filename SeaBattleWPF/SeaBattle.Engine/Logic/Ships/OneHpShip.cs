using SeaBattle.Engine.Common.CoordsHelper;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Logic.Ships
{
    public class OneHpShip : BaseShip
    {
        public OneHpShip(Map map)
        {
            Hp = 1;

            RandomCoords = new GenerateRandomCoordsOneHp(map);

            Coords = RandomCoords.GenerateCoords();
        }
    }
}
