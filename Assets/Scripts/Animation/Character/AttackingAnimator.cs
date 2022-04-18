using System;
using UnityEngine;

namespace Trell.Animation.Character
{
    [RequireComponent(typeof(Animator))]
    public class AttackingAnimator : MonoBehaviour
    {
        public event Action Attacking;

        private Animator _animator;

        private const string IsAttacking = "IsAttacking";
        private const string StopAttackImmediatelyTrigger = "StopAttackImmediately";

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void StartAttack()
        {
            _animator.SetBool(IsAttacking, true);
            _animator.ResetTrigger(StopAttackImmediatelyTrigger);
        }

        public void StopAttackImmediately()
        {
            _animator.SetTrigger(StopAttackImmediatelyTrigger);
            StopAttack();
        }

        public void StopAttack()
        {
            _animator.SetBool(IsAttacking, false);
        }

        public void InvokeAttackEvent()
        {
            Attacking?.Invoke();
        }
    }
}