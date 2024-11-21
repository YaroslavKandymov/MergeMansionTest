using System.Linq;
using MergeMansion.Items;
using UnityEngine;

namespace MergeMansion.StaticData
{
    [CreateAssetMenu(fileName = "new ItemsCollectionData", menuName = "StaticData/ItemsCollectionData", order = 3)]
    public class ItemsCollectionData : ScriptableObject
    {
        [SerializeField] private ItemView[] _itemsView;

        public ItemView GetItem(ItemType type)
        {
            return _itemsView.FirstOrDefault(i => i.ItemType == type);
        }
    }
}