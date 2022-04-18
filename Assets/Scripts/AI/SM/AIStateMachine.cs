using System;
using System.Collections.Generic;
using Trell.Animation.Character;
using Trell.CombatSystem;
using Trell.Movement;
using Trell.Utils;
using UnityEngine;

namespace Trell.AI.FSM
{
    public class AIStateMachine : MonoBehaviour
	{
        [Header("Behaviour Components")]
        [field: SerializeField] public Mover Mover;
        [field: SerializeField] public Attacking Attacking;

        [Space]
        [Header("Animators")]
        [field: SerializeField] public MovementAnimator MovementAnimator;
        [field: SerializeField] public AttackingAnimator AttackingAnimator;

        [Space]
        [Header("Checkers For Range")]
        [SerializeField] private CheckingForRange _checkingForRangeToTriggerChasing;

        [SerializeField] private CheckingForRange _checkingForRangeToStartAttack;

        [Space]
        [TagField]
        [SerializeField] private string _playerTag;

        public bool InRangeToTriggerChasing => _checkingForRangeToTriggerChasing.InRange(PlayerTransform.position);
        public bool InRangeToStartAttack => _checkingForRangeToStartAttack.InRange(PlayerTransform.position);

        public Transform PlayerTransform { get; private set; }
        public Health PlayerHealth { get; private set; }

        private Dictionary<Type, BaseState> _states;

		private BaseState _currentState;

        private void Awake()
        {
            _states = new Dictionary<Type, BaseState>()
            {
                [typeof(AIPatrolState)] = new AIPatrolState(this),
                [typeof(AIChasingState)] = new AIChasingState(this),
                [typeof(AIAttackState)] = new AIAttackState(this)
            };    
        }

        private void Start()
        {
            GetPlayer();
            SetState<AIPatrolState>();
        }

        private void Update()
        {
            _currentState.Update();
        }

        public void SetState<T>() where T : BaseState
        {
            _currentState?.Exit();
            BaseState state = _states[typeof(T)];
            _currentState = state;
            _currentState.Enter();
        }

        private void GetPlayer()
        {
            var playerGO = GameObject.FindGameObjectWithTag(_playerTag);
            PlayerTransform = playerGO.transform;
            PlayerHealth = GetComponent<Health>();
        }
    }
}