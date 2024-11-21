using MergeMansion.StaticData;
using UnityEngine;
using Zenject;

namespace MergeMansion.Installers
{
    [CreateAssetMenu(fileName = "new ConfigsInstaller", menuName = "StaticData/ConfigsInstaller", order = 0)]
    public class ConfigsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private AreaData _areaData;
        [SerializeField] private ItemsCollectionData _itemsCollectionData;
        [SerializeField] private ItemMoverData _itemMoverData;
        [SerializeField] private ItemsHierarchy _itemsHierarchy;
        
        public override void InstallBindings()
        {
            BindAreaData();
            BindItemsCollectionData();
            BindItemTakerData();
            BindItemsHierarchy();
        }

        private void BindAreaData()
        {
            Container.BindInstance(_areaData).AsSingle();
        }
        
        private void BindItemsCollectionData()
        {
            Container.BindInstance(_itemsCollectionData).AsSingle();
        }
        
        private void BindItemTakerData()
        {
            Container.BindInstance(_itemMoverData).AsSingle();
        }
        
        private void BindItemsHierarchy()
        {
            Container.BindInstance(_itemsHierarchy).AsSingle();
        }
    }
}