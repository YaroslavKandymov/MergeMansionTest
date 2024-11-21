using MergeMansion.Other;
using Zenject;

namespace MergeMansion.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameLoader();
        }

        private void BindGameLoader()
        {
            Container
                .BindInterfacesAndSelfTo<GameLoader>()
                .AsSingle()
                .NonLazy();
        }
    }
}