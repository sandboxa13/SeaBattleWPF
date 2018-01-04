using SeaBattle.Engine.Common.CoordsHelper;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Logic.Ships
{
    public class OneHpShip : BaseShip
    {
        public OneHpShip(int hp, Map map) : base(hp)
        {
            RandomCoords = new GenerateRandomCoordsOneHp(map);

            Coords = RandomCoords.GenerateCoords();
        }
    }
}
