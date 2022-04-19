using UnityEngine;
using Trell.Core.StateMachinePattern;
using System.Collections.Generic;
using System;
using Trell.Player;
using Trell.CombatSystem;

namespace Trell.StateMachineRealization.Character.Player
{
	public class PlayerBehaviour : CharacterBehaviour
	{
        [Header("Player Part")]
        [Space]
        [field: SerializeField] public PlayerClickHandler ClickHandler;

        public Vector3 LastClickedPosition => ClickHandler.LastClickedPosition;
        
        private void OnEnable()
        {
            ClickHandler.HittedEnemyChanged += ChangeTarget;
        }

        private void OnDisable()
        {
            ClickHandler.HittedEnemyChanged -= ChangeTarget;
        }

        private void Awake()
        {
            InitStateMachine();
        }


        protected override void InitStateMachine()
        {
            StateMachine = new StateMachine();
            var states = new Dictionary<Type, BaseState>
            {
                [typeof(PlayerMoveState)] = new PlayerMoveState(StateMachine, this),
                [typeof(PlayerChaseState)] = new PlayerChaseState(StateMachine, this),
                [typeof(PlayerAttackState)] = new PlayerAttackState(StateMachine, this),
                [typeof(DieState)] = new DieState(StateMachine, this),

            };
            StateMachine.InitStateMachine(states);
            StateMachine.SetState<PlayerMoveState>();
        }

        private void ChangeTarget(Health target)
        {
            Target = target;
        }
    }
}