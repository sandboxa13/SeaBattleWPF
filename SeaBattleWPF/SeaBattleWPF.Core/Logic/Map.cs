using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleWPF.Core.Logic
{   
    public class Map
    {
        public Block[,] MapBlocks;

        public Map()
        {
            MapBlocks = new Block[10, 10];          
        }
    }
}
    