using MergeMansion.Area;
using UnityEngine;

namespace MergeMansion.StaticData
{
    [CreateAssetMenu(fileName = "new AreaData", menuName = "StaticData/AreaData", order = 1)]
    public class AreaData : ScriptableObject
    {
        [SerializeField] private FloorView _floorView;
        [SerializeField] private AreaMaterialData _areaMaterialData;
        [SerializeField] private Vector2Int _size;
        [SerializeField] private int _cellSize;

        public Vector2Int Size => _size;
        public FloorView FloorView => _floorView;
        public AreaMaterialData AreaMaterialData => _areaMaterialData;
        public int CellSize => _cellSize;
    }
}