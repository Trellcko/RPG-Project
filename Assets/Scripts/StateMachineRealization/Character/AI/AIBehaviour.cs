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

        private void Awake()
        {
            GetPlayer();
            InitStateMachine();
        }

        protected override void InitStateMachine()
        {
            StateMachine = new StateMachine();
            var states = new Dictionary<Type, BaseState>()
            {
                [typeof(AIPatrolState)] = new AIPatrolState(StateMachine, this),
                [typeof(AIChaseState)] = new AIChaseState(StateMachine, this),
                [typeof(AIAttackState)] = new AIAttackState(StateMachine, this),
                [typeof(DieState)] = new DieState(StateMachine, this)
            };
            StateMachine.InitStateMachine(states);

            StateMachine.SetState<AIPatrolState>();
        }

        private void GetPlayer()
        {
            var playerGO = GameObject.FindGameObjectWithTag(_playerTag);
            PlayerTransform = playerGO.transform;
            Target = playerGO.GetComponent<Health>();
        }
    }
}