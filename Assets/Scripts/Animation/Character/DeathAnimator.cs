using System;
using UnityEngine;

namespace Trell.Animation.Character
{
	[RequireComponent(typeof(Animator))]
	public class DeathAnimator : MonoBehaviour
	{
		private Animator _animator;

        private const string DieTrigger = "Die";

        public event Action Died;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Die()
        {
            _animator.SetTrigger(DieTrigger);
        }

        public void InvokeDiedEvent()
        {
            Died?.Invoke();
        }

    }
}