using UnityEngine;

namespace MergeMansion.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3Int ConvertToVector3Int(this Vector3 vector)
        {
            return new Vector3Int(Mathf.RoundToInt(vector.x), 0, Mathf.RoundToInt(vector.z));
        }
        
    }
}