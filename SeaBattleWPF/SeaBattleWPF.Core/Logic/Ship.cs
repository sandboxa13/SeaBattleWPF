namespace SeaBattleWPF.Core.Logic
{
    public class Ship
    {
        public string Name { get; }
        public bool IsAlive { get; }
        public int Hp { get; }

        public Coords Coords;

        public Ship(int x, int y, int hp, bool isAlive, string name) 
        {
            Hp = hp;
            IsAlive = isAlive;
            Name = name;
            Coords = new Coords(x, y);
        }
    }
}
