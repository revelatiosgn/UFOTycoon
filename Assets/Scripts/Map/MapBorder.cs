using UnityEngine;

namespace UFOT.Map
{
    /// <summary>
    /// Configuration of map border
    /// </summary>
    public class MapBorder : MonoBehaviour
    {
        [SerializeField] float left, right, top, bottom;

        public float Left { get => left; }
        public float Right { get => right; }
        public float Top { get => top; }
        public float Bottom { get => bottom; }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector3(left, 1f, top), new Vector3(right, 1f, top));
            Gizmos.DrawLine(new Vector3(left, 1f, bottom), new Vector3(right, 1f, bottom));
            Gizmos.DrawLine(new Vector3(left, 1f, bottom), new Vector3(left, 1f, top));
            Gizmos.DrawLine(new Vector3(right, 1f, bottom), new Vector3(right, 1f, top));
        }
    }
}