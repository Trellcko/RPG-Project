using UnityEngine;

namespace Trell.Utils
{

    public class CheckingForRange : MonoBehaviour
    {
        [SerializeField] private int _range = 2;

        public bool InRange(Vector3 target)
        {
            return Vector3.Distance(transform.position, target) < _range;
        }
    }
}