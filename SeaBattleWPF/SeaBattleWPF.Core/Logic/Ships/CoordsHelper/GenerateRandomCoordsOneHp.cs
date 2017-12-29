using System;
using System.Collections.Generic;

namespace SeaBattleWPF.Core.Logic.Ships.CoordsHelper
{
    public class GenerateRandomCoordsOneHp : BaseRandomCoords
    {
        public GenerateRandomCoordsOneHp(Map map) : base(map)
        {
            
        }

        public override List<Coords> GenerateCoords()
        {
            _random = new Random();

            var coords = new List<Coords>() {new Coords(_random.Next(1, 10), _random.Next(1, 10))};
        

            //_map.MapBlocks[coords, coords.Y].IsEmpty = false;

            return coords;
        }
    }
}
