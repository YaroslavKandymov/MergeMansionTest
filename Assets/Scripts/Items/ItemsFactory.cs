using System;
using MergeMansion.StaticData;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace MergeMansion.Items
{
    public class ItemsFactory
    {
        private readonly DiContainer _diContainer;
        private readonly ItemsCollectionData _itemsCollectionData;
        private readonly Transform _parent;

        public ItemsFactory(DiContainer diContainer, ItemsCollectionData itemsCollectionData, Transform parent)
        {
            _diContainer = diContainer;
            _itemsCollectionData = itemsCollectionData;
            _parent = parent;
        }

        public ItemView CreateItem(ItemType type)
        {
            var item = _itemsCollectionData.GetItem(type);

            if (item == null)
                throw new ArgumentException("Wrong type");
            
            return _diContainer.InstantiatePrefabForComponent<ItemView>(item, _parent);
        }

        public void Destroy(GameObject gameObject)
        {
            Object.Destroy(gameObject);
        }
    }
}