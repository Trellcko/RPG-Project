using Trell.Animation.Character;
using Trell.CombatSystem;
using Trell.Core.StateMachinePattern;
using Trell.Movement;
using Trell.Utils;
using UnityEngine;

namespace Trell
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

        public Health Target { get; protected set; }

        [SerializeField] protected CheckingForRange CheckingForRangeToStartAttack;

        protected override void InitStateMachine() { }
    }
}