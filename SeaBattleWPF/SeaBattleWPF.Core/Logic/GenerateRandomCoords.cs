using System;
using System.Collections.Generic;
using System.Linq;
using SeaBattleWPF.Core.Logic.Interfaces;

namespace SeaBattleWPF.Core.Logic
{
    public class GenerateRandomCoords : IGenerateRandomCoords
    {
        private Map _map;   
            
        private readonly int[] _topValues = {2, 3, 4, 5, 6, 7, 8, 9};
        private readonly int[] _bottomValues = { 92, 93, 94, 95, 96, 97, 98, 99 };
        private readonly int[] _leftValues = { 11, 22, 33, 44, 55, 66, 77, 88 };
        private readonly int[] _rightValues = { 20, 30, 40, 50, 60, 70, 80, 90 };

        private Random _random; 

        public GenerateRandomCoords(Map map)
        {
            _map = map;
        }

        public Coords GenerateCoordForOneHpShip()
        {
            _random = new Random();

            var coords = new Coords(_random.Next(1, 100), _random.Next(1, 100));

            _map.MapBlocks[coords.X, coords.Y].IsEmpty = false;

            return coords;
        }

        public IList<Coords> GenerateCoordForTwoHpShip()
        {
            _random = new Random();

            var listCoords = new List<Coords>
            {
                new Coords(_random.Next(1, 10), _random.Next(1, 10))
            };

            _map.MapBlocks[listCoords[0].X, listCoords[0].Y].IsEmpty = false;

            var newList = CheckOnExtremeValues(listCoords);

            if (newList.Equals(listCoords))
            {
                newList = CheckOnSideCoords(listCoords);

                if (newList.Equals(listCoords))
                {
                    if (_map.MapBlocks[newList[0].X + 1, newList[0].Y + 1].IsEmpty)
                    {
                        listCoords.Add(new Coords(newList[1].X + 1, newList[1].Y + 1));

                        _map.MapBlocks[newList[1].X + 1, newList[1].Y + 1].IsEmpty = false;
                    }


                    else if (_map.MapBlocks[newList[0].X + 10, newList[0].Y + 10].IsEmpty)
                    {
                        listCoords.Add(new Coords(newList[1].X + 10, newList[1].Y + 10));

                        _map.MapBlocks[newList[1].X + 10, newList[1].Y + 10].IsEmpty = false;
                    }


                    else if (_map.MapBlocks[newList[0].X - 10, newList[0].Y - 10].IsEmpty)
                    {
                        listCoords.Add(new Coords(newList[1].X - 10, newList[1].Y - 10));

                        _map.MapBlocks[newList[1].X - 10, newList[1].Y - 10].IsEmpty = false;
                    }


                    else if (_map.MapBlocks[newList[0].X - 1, newList[0].Y - 1].IsEmpty)
                    {
                        listCoords.Add(new Coords(newList[1].X - 1, newList[1].Y - 1));

                        _map.MapBlocks[newList[1].X - 1, newList[1].Y - 1].IsEmpty = false;
                    }
                }               
            }

            return newList;
        }

        private IList<Coords> CheckOnSideCoords(IList<Coords> listCoords)
        {
            if (_bottomValues.Contains(listCoords[0].X))
            {
                if (_map.MapBlocks[listCoords[0].X + 1, listCoords[0].Y + 1].IsEmpty)
                {
                    listCoords.Add(new Coords(listCoords[0].X + 1, listCoords[0].Y + 1));

                    _map.MapBlocks[listCoords[0].X + 1, listCoords[0].Y + 1].IsEmpty = false;
                }

                else if (_map.MapBlocks[listCoords[0].X - 1, listCoords[0].Y - 1].IsEmpty)
                {
                    listCoords.Add(new Coords(listCoords[0].X - 1, listCoords[0].Y - 1));

                    _map.MapBlocks[listCoords[0].X - 1, listCoords[0].Y - 1].IsEmpty = false;
                }

                else if (_map.MapBlocks[listCoords[0].X - 10, listCoords[0].Y - 10].IsEmpty)
                {
                    listCoords.Add(new Coords(listCoords[0].X - 10, listCoords[0].Y - 10));

                    _map.MapBlocks[listCoords[0].X - 10, listCoords[0].Y - 10].IsEmpty = false;
                }
            }

            if (_topValues.Contains(listCoords[0].X))
            {
                if (_map.MapBlocks[listCoords[0].X + 1, listCoords[0].Y + 1].IsEmpty)
                {
                    listCoords.Add(new Coords(listCoords[0].X + 1, listCoords[0].Y + 1));

                    _map.MapBlocks[listCoords[0].X + 1, listCoords[0].Y + 1].IsEmpty = false;
                }

                else if (_map.MapBlocks[listCoords[0].X - 1, listCoords[0].Y - 1].IsEmpty)
                {
                    listCoords.Add(new Coords(listCoords[0].X - 1, listCoords[0].Y - 1));

                    _map.MapBlocks[listCoords[0].X - 1, listCoords[0].Y - 1].IsEmpty = false;
                }

                else if (_map.MapBlocks[listCoords[0].X + 10, listCoords[0].Y + 10].IsEmpty)
                {
                    listCoords.Add(new Coords(listCoords[0].X + 10, listCoords[0].Y + 10));

                    _map.MapBlocks[listCoords[0].X + 10, listCoords[0].Y + 10].IsEmpty = false;
                }
            }

            if (_leftValues.Contains(listCoords[0].X))
            {
                if (_map.MapBlocks[listCoords[0].X + 1, listCoords[0].Y + 1].IsEmpty)
                {
                    listCoords.Add(new Coords(listCoords[0].X + 1, listCoords[0].Y + 1));

                    _map.MapBlocks[listCoords[0].X + 1, listCoords[0].Y + 1].IsEmpty = false;
                }

                else if (_map.MapBlocks[listCoords[0].X - 10, listCoords[0].Y - 10].IsEmpty)
                {
                    listCoords.Add(new Coords(listCoords[0].X - 10, listCoords[0].Y - 10));

                    _map.MapBlocks[listCoords[0].X - 10, listCoords[0].Y - 10].IsEmpty = false;
                }

                else if (_map.MapBlocks[listCoords[0].X + 10, listCoords[0].Y + 10].IsEmpty)
                {
                    listCoords.Add(new Coords(listCoords[0].X + 10, listCoords[0].Y + 10));

                    _map.MapBlocks[listCoords[0].X + 10, listCoords[0].Y + 10].IsEmpty = false;
                }
            }

            if (_rightValues.Contains(listCoords[0].X))
            {
                if (_map.MapBlocks[listCoords[0].X - 1, listCoords[0].Y - 1].IsEmpty)
                {
                    listCoords.Add(new Coords(listCoords[0].X - 1, listCoords[0].Y - 1));

                    _map.MapBlocks[listCoords[0].X - 1, listCoords[0].Y - 1].IsEmpty = false;
                }

                else if (_map.MapBlocks[listCoords[0].X - 10, listCoords[0].Y - 10].IsEmpty)
                {
                    listCoords.Add(new Coords(listCoords[0].X - 10, listCoords[0].Y - 10));

                    _map.MapBlocks[listCoords[0].X - 10, listCoords[0].Y - 10].IsEmpty = false;
                }

                else if (_map.MapBlocks[listCoords[0].X + 10, listCoords[0].Y + 10].IsEmpty)
                {
                    listCoords.Add(new Coords(listCoords[0].X + 10, listCoords[0].Y + 10));

                    _map.MapBlocks[listCoords[0].X + 10, listCoords[0].Y + 10].IsEmpty = false;
                }
            }

            return listCoords;
        }

        private IList<Coords> CheckOnExtremeValues(IList<Coords> listCoords)
        {
            switch (listCoords[1].X)
            {
                case 1 when listCoords[0].Y == 1:

                    if (_map.MapBlocks[listCoords[0].X + 1, listCoords[0].Y + 1].IsEmpty)
                    {
                        listCoords.Add(new Coords(listCoords[1].X + 1, listCoords[1].Y + 1));

                        _map.MapBlocks[listCoords[1].X + 1, listCoords[1].Y + 1].IsEmpty = false;
                    }

                    else if (_map.MapBlocks[listCoords[0].X + 10, listCoords[0].Y + 10].IsEmpty)
                    {
                        listCoords.Add(new Coords(listCoords[1].X + 10, listCoords[1].Y + 10));

                        _map.MapBlocks[listCoords[1].X + 10, listCoords[1].Y + 10].IsEmpty = false;
                    }

                    break;
                case 10 when listCoords[0].Y == 10:

                    if (_map.MapBlocks[listCoords[0].X - 1, listCoords[0].Y - 1].IsEmpty)
                    {
                        listCoords.Add(new Coords(listCoords[1].X - 1, listCoords[1].Y - 1));

                        _map.MapBlocks[listCoords[1].X - 1, listCoords[1].Y - 1].IsEmpty = false;
                    }

                    else if (_map.MapBlocks[listCoords[0].X + 10, listCoords[0].Y + 10].IsEmpty)
                    {
                        listCoords.Add(new Coords(listCoords[1].X + 10, listCoords[1].Y + 10));

                        _map.MapBlocks[listCoords[1].X + 10, listCoords[1].Y + 10].IsEmpty = false;
                    }

                    break;

                case 91 when listCoords[0].Y == 91:

                    if (_map.MapBlocks[listCoords[0].X - 10, listCoords[0].Y - 10].IsEmpty)
                    {
                        listCoords.Add(new Coords(listCoords[1].X - 10, listCoords[1].Y - 10));

                        _map.MapBlocks[listCoords[1].X - 10, listCoords[1].Y - 10].IsEmpty = false;
                    }

                    else if (_map.MapBlocks[listCoords[0].X + 1, listCoords[0].Y + 1].IsEmpty)
                    {
                        listCoords.Add(new Coords(listCoords[1].X + 1, listCoords[1].Y + 1));

                        _map.MapBlocks[listCoords[1].X + 1, listCoords[1].Y + 1].IsEmpty = false;
                    }

                    break;

                case 100 when listCoords[0].Y == 100:

                    if (_map.MapBlocks[listCoords[0].X - 1, listCoords[0].Y - 1].IsEmpty)
                    {
                        listCoords.Add(new Coords(listCoords[1].X - 1, listCoords[1].Y - 1));

                        _map.MapBlocks[listCoords[1].X - 1, listCoords[1].Y - 1].IsEmpty = false;
                    }

                    else if (_map.MapBlocks[listCoords[0].X - 10, listCoords[0].Y - 10].IsEmpty)
                    {
                        listCoords.Add(new Coords(listCoords[1].X - 10, listCoords[1].Y - 10));

                        _map.MapBlocks[listCoords[1].X - 10, listCoords[1].Y - 10].IsEmpty = false;
                    }

                    break;
            }

            return listCoords;
        }

        public IList<Coords> GenerateCoordForThreeHpShip()
        {
            throw new System.NotImplementedException();
        }

        public IList<Coords> GenerateCoordForFourHpShip()
        {
            throw new System.NotImplementedException();
        }
    }
}
