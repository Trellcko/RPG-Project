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

        [TabGroup("Data", "Attacking")]
        [SerializeField] private float _timeBetweenAttack = 2f;

        [TabGroup("Checking for Range")]
        [SerializeField] private CheckingForRange _checkingForRangeToStartAttack;

        public bool EnoughCloseToAttack => _checkingForRangeToStartAttack.InRange(Target.transform.position);

        [TabGroup("Data", "Attacking")]
        [ShowInInspector]
        public bool IsTimeToAttack => _timeToAttack <= 0;

        public Health Target { get; protected set; }

        private float _timeToAttack;

        private void Start()
        {
            ResetTimeBetweenAttack();
        }

        public void TickTimeToAttack()
        {
            _timeToAttack -= Time.deltaTime;
        }

        public void ResetTimeBetweenAttack()
        {
            _timeToAttack = _timeBetweenAttack;
        }

        protected override void InitStateMachine() { }
    }
}