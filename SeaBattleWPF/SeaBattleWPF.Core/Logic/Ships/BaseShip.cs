using SeaBattleWPF.Core.Logic.Interfaces;

namespace SeaBattleWPF.Core.Logic.Ships
{
    public class BaseShip
    {
        public string Name { get; }
        public bool IsAlive { get; }
        public int Hp { get; }

        public Coords Coords;
            
        protected IGenerateRandomCoords RandomCoords;

        public BaseShip(int x, int y, int hp, bool isAlive, string name) 
        {
            Hp = hp;
            IsAlive = isAlive;
            Name = name;
            Coords = new Coords(x, y);
        }
    }
}
