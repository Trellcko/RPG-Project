using Trell.Animation.Character;
using Trell.CombatSystem;
using Trell.Core.StateMachinePattern;
using Trell.Movement;
using Trell.Utils;
using UnityEngine;

namespace Trell.StateMachineRealization.Character
{
	public abstract class CharacterBehaviour : BaseBehaviour
	{
        [Header("Character part")]
        [Space]
        [Header("Behaviour Components")]
        [field: SerializeField] public Mover Mover;
        [field: SerializeField] public Attacking Attacking;
        [field: SerializeField] public Health Health;

        [Space]
        [Header("Animators")]
        [field: SerializeField] public MovementAnimator MovementAnimator;
        [field: SerializeField] public AttackingAnimator AttackingAnimator;
        [field: SerializeField] public DeathAnimator DeathAnimator;

        [Space]
        [Header("Checkers for range")]
        [SerializeField] protected CheckingForRange CheckingForRangeToStartAttack;
        public bool InRangeRangeToStartAttack => CheckingForRangeToStartAttack.InRange(Target.transform.position);

        public Health Target { get; protected set; }

        protected override void InitStateMachine() { }

        public void Update()
        {
            StateMachine.Update();
        }

        public void FixedUpdate()
        {
            StateMachine.FixedUpdate();
        }
    }
}