namespace SeaBattle.Engine.Common.MapLogic
{
    public class Block
    {
        public BlockState State;

        public int X { get; set; }


        public int Y { get; set; }

        public Block(int x, int y)  
        {
            X = x;
            Y = y;
            State = BlockState.IsEmpty;
        }
    }
}
