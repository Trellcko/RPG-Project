using System;
using System.Collections.Generic;
using Trell.CombatSystem;
using Trell.Core.StateMachinePattern;
using Trell.Utils;
using UnityEngine;

namespace Trell.StateMachineRealization.Character.AI
{
    public class AIBehaviour : CharacterBehaviour
    {
        [Header("AI Part")]
        [Space]
        [Header("Checkers For Range")]
        [SerializeField] private CheckingForRange _checkingForRangeToTriggerChasing;
        
        [Space]
        [Header("Tags")]
        [TagField]
        [SerializeField] private string _playerTag;

        public Transform PlayerTransform { get; private set; }

        public bool InRangeToTriggerChasing => _checkingForRangeToTriggerChasing.InRange(PlayerTransform.position);
        public bool InRangeRangeToStartAttack => CheckingForRangeToStartAttack.InRange(PlayerTransform.position);

        private StateMachine _stateMachine;

        private void Awake()
        {
            GetPlayer();
            InitStateMachine();
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }

        protected override void InitStateMachine()
        {
            _stateMachine = new StateMachine();
            var states = new Dictionary<Type, BaseState>()
            {
                [typeof(AIPatrolState)] = new AIPatrolState(_stateMachine, this),
                [typeof(AIChasingState)] = new AIChasingState(_stateMachine, this),
                [typeof(AIAttackState)] = new AIAttackState(_stateMachine, this),
                [typeof(DieState)] = new DieState(_stateMachine, this)
            };
            _stateMachine.InitStateMachine(states);

            _stateMachine.SetState<AIPatrolState>();
        }

        private void GetPlayer()
        {
            var playerGO = GameObject.FindGameObjectWithTag(_playerTag);
            PlayerTransform = playerGO.transform;
            Target = playerGO.GetComponent<Health>();
        }
    }
}