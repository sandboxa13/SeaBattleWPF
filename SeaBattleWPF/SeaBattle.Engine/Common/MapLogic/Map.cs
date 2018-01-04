namespace SeaBattle.Engine.Common.MapLogic
{   
    public class Map
    {
        public Block[,] MapBlocks;

        public Map()
        {
            MapBlocks = new Block[10, 10];

            for (var j = 0; j < 10; j++)
            {
                for (var i = 0; i < 10; i++)
                {
                    MapBlocks[j, i] = new Block();
                }
            }
        }
    }
}
    