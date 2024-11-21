using MergeMansion.Area;
using MergeMansion.Interfaces;

namespace MergeMansion.UI.Models
{
    public class GameModel : IGameModel
    {
        private readonly AreaItemsFiller _areaItemsFiller;

        public GameModel(AreaItemsFiller areaItemsFiller)
        {
            _areaItemsFiller = areaItemsFiller;
        }

        public void Generate()
        {
            _areaItemsFiller.AddItem();
        }
    }
}