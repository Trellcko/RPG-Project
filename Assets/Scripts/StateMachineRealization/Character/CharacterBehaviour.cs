using Sirenix.OdinInspector;
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
        [field: TabGroup("Behaviour Components")]
        [field: SerializeField] public Mover Mover { get; private set; }
        [field: TabGroup("Behaviour Components")]
        [field: SerializeField] public Attacking Attacking { get; private set; }
        [field: TabGroup("Behaviour Components")]
        [field: SerializeField] public Health Health { get; private set; }

        [field: TabGroup("Animators")]
        [field: SerializeField] public MovementAnimator MovementAnimator { get; private set; }
        [field: TabGroup("Animators")]
        [field: SerializeField] public AttackingAnimator AttackingAnimator { get; private set; }
        [field: TabGroup("Animators")]
        [field: SerializeField] public DeathAnimator DeathAnimator { get; private set; }

        [TabGroup("Checking for Range")]
        [SerializeField] private CheckingForRange _checkingForRangeToStartAttack;
        public bool EnoughCloseToAttack => _checkingForRangeToStartAttack.InRange(Target.transform.position);

        public Health Target { get; protected set; }

        protected override void InitStateMachine() { }
    }
}