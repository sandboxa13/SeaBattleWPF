using System.Collections.Generic;

namespace SeaBattleWPF.Core.Logic.Interfaces
{
    public interface IGenerateRandomCoords
    {
        Coords GenerateCoordForOneHpShip();

        IList<Coords> GenerateCoordForTwoHpShip();

        IList<Coords> GenerateCoordForThreeHpShip();

        IList<Coords> GenerateCoordForFourHpShip();
    }
}       
