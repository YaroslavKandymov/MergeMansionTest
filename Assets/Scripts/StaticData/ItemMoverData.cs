using DG.Tweening;
using UnityEngine;

namespace MergeMansion.StaticData
{
    [CreateAssetMenu(fileName = "new ItemTakerData", menuName = "StaticData/ItemTakerData", order = 4)]
    public class ItemMoverData : ScriptableObject
    {
        [SerializeField] private float _moveTime;
        [SerializeField] private float _height;
        [SerializeField] private float _horizontalOffset;
        [SerializeField] private Ease _ease;

        public float Height => _height;
        public float HorizontalOffset => _horizontalOffset;
        public float MoveTime => _moveTime;
        public Ease Ease => _ease;
    }
}