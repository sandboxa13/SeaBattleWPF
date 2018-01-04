using SeaBattle.Engine.Common.CoordsHelper;

namespace SeaBattle.Engine.Logic.Ships
{
    public class TwoHpShip : BaseShip
    {
        public TwoHpShip(int x, int y, int hp, bool isAlive, string name, Map map) : base(x, y, hp, isAlive, name)
        {
            RandomCoords = new GenerateRandomCoordsTwoHp(map);
        }
    }
}
