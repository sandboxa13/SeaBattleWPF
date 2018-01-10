using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleWPF
{
    public interface IBattleFieldCell
    {
        int Value { get; set; }
        int BorderValue { get; set; }
        int X { get; }
        int Y { get; }
    }
}
