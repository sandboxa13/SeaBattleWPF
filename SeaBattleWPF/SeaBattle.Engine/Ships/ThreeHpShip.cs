using SeaBattle.Engine.Common.CoordsHelper;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Ships
{
    public class ThreeHpShip : BaseShip
    {
        public ThreeHpShip(Map map)
        {
            Hp = 3; //set hp

            RandomCoords = new GenerateRandoomCoordsThreeHp(map); //set generator of random coords for 3hp ship

            Coords = RandomCoords.GenerateCoords(); // set random coords

            ShipsEnum = ShipsEnum.ThreeHp;
        }
    }
}
