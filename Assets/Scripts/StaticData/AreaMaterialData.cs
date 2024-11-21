using UnityEngine;

namespace MergeMansion.StaticData
{
    [CreateAssetMenu(fileName = "new AreaMaterialData", menuName = "StaticData/AreaMaterialData", order = 2)]
    public class AreaMaterialData : ScriptableObject
    {
        [SerializeField] private float _cellsCount;

        public float CellsCount => _cellsCount;
    }
}