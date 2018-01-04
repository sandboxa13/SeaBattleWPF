using SeaBattle.Engine.Common.CoordsHelper;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Logic.Ships
{
    public class TwoHpShip : BaseShip
    {
        public TwoHpShip(int hp, Map map) : base( hp)
        {
            RandomCoords = new GenerateRandomCoordsTwoHp(map);

            Coords = RandomCoords.GenerateCoords();
        }
    }
}
