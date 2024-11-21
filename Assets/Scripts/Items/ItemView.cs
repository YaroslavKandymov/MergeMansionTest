using MergeMansion.Interfaces;
using UnityEngine;

namespace MergeMansion.Items
{
    public class ItemView : MonoBehaviour, ITakeble
    {
        [SerializeField] private ItemType _itemType;

        public Transform Transform => transform;
        public ItemType ItemType => _itemType;
    }
}