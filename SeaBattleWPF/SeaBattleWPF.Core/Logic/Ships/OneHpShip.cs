using SeaBattleWPF.Core.Logic.Ships.CoordsHelper;

namespace SeaBattleWPF.Core.Logic.Ships
{
    public class OneHpShip : BaseShip
    {
        public OneHpShip(int x, int y, int hp, bool isAlive, string name, Map map) : base(x, y, hp, isAlive, name)
        {
            RandomCoords = new GenerateRandomCoordsOneHp(map);
        }
    }
}
