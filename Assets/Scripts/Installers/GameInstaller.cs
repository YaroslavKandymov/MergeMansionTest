using MergeMansion.Area;
using MergeMansion.Interfaces;
using MergeMansion.Items;
using MergeMansion.Other;
using MergeMansion.Services;
using MergeMansion.UI;
using MergeMansion.UI.Models;
using MergeMansion.UI.Presenters;
using UnityEngine;
using Zenject;

namespace MergeMansion.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private MainWindow _mainWindow;
        [SerializeField] private Transform _itemsParent;
        
        public override void InstallBindings()
        {
            BindCamera();
            BindMainWindow();
            BindAreaFactory();
            BindItemsFactory();
            BindUserInput();
            BindAreaCreator();
            BindGridGenerator();
            BindInputRayCaster();
            BindItemsUnifier();
            BindItemTaker();
            BindAreaItemsFiller();
            BindGameModel();
            BindGameWindowPresenter();
            BindItemsService();
            BindGameEntryPoint();
        }

        private void BindCamera()
        {
            Container
                .BindInstance(_camera)
                .AsSingle();
        }

        private void BindMainWindow()
        {
            Container
                .BindInstance(_mainWindow)
                .AsSingle();
        }

        private void BindAreaFactory()
        {
            Container
                .Bind<AreaFactory>()
                .AsSingle();
        }

        private void BindItemsFactory()
        {
            Container
                .Bind<ItemsFactory>()
                .AsSingle()
                .WithArguments(_itemsParent);
        }
        
        private void BindUserInput()
        {
            Container
                .BindInterfacesAndSelfTo<UserInput>()
                .AsSingle();
        }

        private void BindAreaCreator()
        {
            Container
                .Bind<AreaCreator>()
                .AsSingle()
                .NonLazy();
        }

        private void BindGridGenerator()
        {
            Container
                .Bind<GridGenerator>()
                .AsSingle()
                .NonLazy();
        }

        private void BindInputRayCaster()
        {
            Container
                .Bind<InputRayCaster>()
                .AsSingle();
        }
        
        private void BindItemsUnifier()
        {
            Container
                .Bind<ItemsUnifier>()
                .AsSingle();
        }

        private void BindItemTaker()
        {
            Container
                .BindInterfacesAndSelfTo<ItemsMover>()
                .AsSingle()
                .NonLazy();
        }

        private void BindGameModel()
        {
            Container
                .Bind<IGameModel>()
                .To<GameModel>()
                .AsSingle();
        }

        private void BindGameWindowPresenter()
        {
            Container
                .BindInterfacesAndSelfTo<GameWindowPresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindAreaItemsFiller()
        {
            Container
                .Bind<AreaItemsFiller>()
                .AsSingle();
        }
        
        private void BindItemsService()
        {
            Container
                .BindInterfacesAndSelfTo<ItemsService>()
                .AsSingle()
                .NonLazy();
        }
        
        private void BindGameEntryPoint()
        {
            Container
                .BindInterfacesAndSelfTo<GameEntryPoint>()
                .AsSingle()
                .NonLazy();
        }
    }
}
