using Sirenix.OdinInspector;
using Sirenix.Serialization;
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
        [field: TabGroup("Checking for Range")]
        [SerializeField] private CheckingForRange _checkingForRangeToTriggerChasing;
        [field: TabGroup("Checking for Range")]
        [SerializeField] private CheckingForRange _chekingForRangeToCancelChasing;

        [TabGroup("Tags")]
        [TagField]
        [SerializeField] private string _playerTag;
        
        [field: BoxGroup("Patrol")]
        [field: SerializeField] public Transform[] PatrolPoints { get; private set; }

        [field: BoxGroup("Patrol")]
        [field: ValueDropdown(nameof(PatrolPoints))]
        [field: SerializeField] public Transform CurrentPatrolPoint { get; private set; }

        public Transform PlayerTransform { get; private set; }

        public bool IsPlayerFarAway => _chekingForRangeToCancelChasing.InRange(PlayerTransform.position) == false;

        public bool CanISeePlayer => _checkingForRangeToTriggerChasing.InRange(PlayerTransform.position);

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