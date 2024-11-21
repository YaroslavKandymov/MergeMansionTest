using MergeMansion.Enums;
using MergeMansion.Interfaces;
using Zenject;

namespace MergeMansion.Other
{
    public class GameLoader : IInitializable
    {
        private readonly ISceneLoaderService _sceneLoaderService;

        public GameLoader(ISceneLoaderService sceneLoaderService)
        {
            _sceneLoaderService = sceneLoaderService;
        }

        void IInitializable.Initialize()
        {
            _sceneLoaderService.GoToScene(CurrentScene.Game);
        }
    }
}