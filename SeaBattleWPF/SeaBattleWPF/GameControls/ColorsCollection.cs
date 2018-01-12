using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SeaBattleWPF.GameControls
{
    public class ColorsCollection : List<Brush>
    {
        public class BattleFieldColorsCollection : List<Brush>
        {
            public BattleFieldColorsCollection()
            { }
            public BattleFieldColorsCollection(IEnumerable<Brush> collection) : base(collection) { }
            public BattleFieldColorsCollection(int capacity) : base(capacity) { }
        }
    }
}
