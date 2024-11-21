using Cysharp.Threading.Tasks;
using MergeMansion.Area;
using MergeMansion.Other;
using MergeMansion.UI.Presenters;
using Zenject;

namespace MergeMansion
{
    public class GameEntryPoint : IInitializable
    {
        private readonly AreaCreator _areaCreator;
        private readonly GridGenerator _gridGenerator;
        private readonly AreaItemsFiller _areaItemsFiller;
        private readonly GameWindowPresenter _gameWindowPresenter;

        public GameEntryPoint(AreaCreator areaCreator,
            GridGenerator gridGenerator, 
            AreaItemsFiller areaItemsFiller,
            GameWindowPresenter gameWindowPresenter)
        {
            _areaCreator = areaCreator;
            _gridGenerator = gridGenerator;
            _areaItemsFiller = areaItemsFiller;
            _gameWindowPresenter = gameWindowPresenter;
        }

        void IInitializable.Initialize()
        {
            Start().Forget();
        }

        private async UniTaskVoid Start()
        {
            await _areaCreator.Initialize();
            await _gridGenerator.Initialize();
            await _areaItemsFiller.Initialize();
            await _gameWindowPresenter.Enable();
        }
    }
}