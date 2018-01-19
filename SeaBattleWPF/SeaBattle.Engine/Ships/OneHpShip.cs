using SeaBattle.Engine.Common.CoordsHelper;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Ships
{
    public class OneHpShip : BaseShip
    {
        public OneHpShip(Map map)
        {
            Hp = 1; // set hp

            RandomCoords = new GenerateRandomCoordsOneHp(map); //set generator of random coords for 1hp ship

            Coords = RandomCoords.GenerateCoords(); //generate and set random coords

            ShipsEnum = ShipsEnum.OneHp;
        }
    }
}
