using System;
using System.Collections.Generic;
using Trell.AI.States;
using Trell.Animation.Character;
using Trell.CombatSystem;
using Trell.Core.StateMachinePattern;
using Trell.Movement;
using Trell.Utils;
using UnityEngine;

namespace Trell.AI
{
    public class AIBehaviour : MonoBehaviour
    {
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
        [Header("Checkers For Range")]
        [SerializeField] private CheckingForRange _checkingForRangeToTriggerChasing;
        [SerializeField] private CheckingForRange _checkingForRangeToStartAttack;
        
        [Space]
        [Header("Tags")]
        [TagField]
        [SerializeField] private string _playerTag;

        public Health PlayerHealth { get; private set; }

        public Transform PlayerTransform { get; private set; }

        public bool InRangeToTriggerChasing => _checkingForRangeToTriggerChasing.InRange(PlayerTransform.position);

        public bool InRangeRangeToStartAttack => _checkingForRangeToStartAttack.InRange(PlayerTransform.position);

        private StateMachine _stateMachine;

        private void Awake()
        {
            GetPlayer();
            _stateMachine = new StateMachine();
            var states = new Dictionary<Type, BaseState>()
            {
                [typeof(AIPatrolState)] = new AIPatrolState(_stateMachine, this),
                [typeof(AIChasingState)] = new AIChasingState(_stateMachine, this),
                [typeof(AIAttackState)] = new AIAttackState(_stateMachine, this),
                [typeof(AIDieState)] = new AIDieState(_stateMachine, this)
            };
            _stateMachine.InitStateMachine(states);

            _stateMachine.SetState<AIPatrolState>();
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }

        private void GetPlayer()
        {
            var playerGO = GameObject.FindGameObjectWithTag(_playerTag);
            PlayerTransform = playerGO.transform;
            PlayerHealth = playerGO.GetComponent<Health>();
        }
    }
}