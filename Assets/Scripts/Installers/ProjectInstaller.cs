using MergeMansion.Interfaces;
using MergeMansion.Services;
using Zenject;

namespace MergeMansion.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneLoader();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<ISceneLoaderService>()
                .To<SceneLoaderService>()
                .AsSingle();
        }
    }
}