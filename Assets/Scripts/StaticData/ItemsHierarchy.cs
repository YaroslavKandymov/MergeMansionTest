using System.Collections.Generic;
using MergeMansion.Items;
using UnityEngine;

namespace MergeMansion.StaticData
{
    [CreateAssetMenu(fileName = "new ItemsHierarchy", menuName = "StaticData/ItemsHierarchy", order = 5)]
    public class ItemsHierarchy : ScriptableObject
    {
        [SerializeField] private List<ItemsQueue> _collections;

        public ItemType GetNextItem(ItemType type)
        {
            foreach (var collection in _collections)
            {
                for (int i = 0; i < collection.Types.Count; i++)
                {
                    if (collection.Types[i] == type)
                    {
                        if (collection.Types.Count > i + 1)
                        {
                            return collection.Types[i + 1];
                        }
                    }
                }
            }

            return ItemType.None;
        }
    }
}