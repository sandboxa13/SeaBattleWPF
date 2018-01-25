using SeaBattleWPF.Core.ViewModels;

namespace SeaBattleWPF.GameControls
{
    public partial class Field
    {
        #region Constructor

        public Field()
        {
            InitializeComponent();

            DataContext = new BattleFieldViewModel(10, 10);
        }

        #endregion   
    }
}
