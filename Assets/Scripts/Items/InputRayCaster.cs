using UnityEngine;

namespace MergeMansion.Items
{
    public class InputRayCaster
    {
        private readonly Camera _camera;

        public InputRayCaster(Camera camera)
        {
            _camera = camera;
        }

        public bool CastRay(ref RaycastHit hit)
        {
            var screenMousePositionFar =
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.farClipPlane);
            
            var screenMousePositionNear =
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.nearClipPlane);

            var worldMousePositionFar = _camera.ScreenToWorldPoint(screenMousePositionFar);
            var worldMousePositionNear = _camera.ScreenToWorldPoint(screenMousePositionNear);

            if (Physics.Raycast(worldMousePositionNear, worldMousePositionFar - worldMousePositionNear, out var raycastHit))
            {
                hit = raycastHit;
                
                return true;
            }
            
            return false;
        }
    }
}