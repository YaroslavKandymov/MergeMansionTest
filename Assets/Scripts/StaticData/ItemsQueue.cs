using System;
using System.Collections.Generic;
using MergeMansion.Items;
using UnityEngine;

namespace MergeMansion.StaticData
{
    [Serializable]
    public class ItemsQueue
    {
        [SerializeField] private List<ItemType> _types;

        public List<ItemType> Types => _types;
    }
}