using Cysharp.Threading.Tasks;
using MergeMansion.Interfaces;
using MergeMansion.UI.Views;

namespace MergeMansion.UI.Presenters
{
    public class GameWindowPresenter : WindowPresenter<GameWindowView>
    {
        private readonly IGameModel _gameModel;

        public GameWindowPresenter(MainWindow mainWindow, IGameModel gameModel) : base(mainWindow)
        {
            _gameModel = gameModel;
        }

        public override async UniTask Enable()
        {
            View.GenerateButton.onClick.AddListener(OnGenerateButtonClicked);

            await base.Enable();
        }

        public override async UniTask Disable()
        {
            View.GenerateButton.onClick.RemoveListener(OnGenerateButtonClicked);

            await base.Disable();
        }

        private void OnGenerateButtonClicked()
        {
            _gameModel.Generate();
        }
    }
}