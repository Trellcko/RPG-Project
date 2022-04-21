using UnityEngine;

namespace Trell.Utils
{

    public class CheckingForRange : MonoBehaviour
    {
        [field: SerializeField] public int Range { get; private set; } = 2;

        public bool InRange(Vector3 target)
        {
            return Vector3.Distance(transform.position, target) < Range;
        }
    }
}