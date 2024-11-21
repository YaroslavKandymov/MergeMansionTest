using UnityEngine;

namespace MergeMansion.Area
{
    public class FloorView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        public MeshRenderer MeshRenderer => _meshRenderer;
    }
}