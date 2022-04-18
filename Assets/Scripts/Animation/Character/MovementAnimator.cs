using UnityEngine;
using UnityEngine.AI;

namespace Trell.Animation.Character
{
    [RequireComponent(typeof(Animator))]
    public class MovementAnimator : MonoBehaviour
    {

        private Animator _animator;

        private const string FowardSpeed = "FowardSpeed";

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetSpeed(float fowradSpeed)
        {
            _animator.SetFloat(FowardSpeed, fowradSpeed);
        }
    }
}