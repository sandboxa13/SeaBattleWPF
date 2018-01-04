using System.Collections.Generic;
using SeaBattle.Engine.Common.MapLogic;

namespace SeaBattle.Engine.Common.Interfaces
{
    public interface IGenerateRandomCoords
    {   
        List<Coords> GenerateCoords();
    }
}           
