using SeaBattle.Engine.Common.CoordsHelper;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Ships
{
    /// <summary>
    /// Class for ship with 2hp 
    /// </summary>
    public class TwoHpShip : BaseShip
    {
       
        public TwoHpShip(Map map)
        {
            Hp = 2; //set hp

            RandomCoords = new GenerateRandomCoordsTwoHp(map); //set generator of random coords for 2hp ship

            Coords = RandomCoords.GenerateCoords(); // set random coords
        }
    }
}
