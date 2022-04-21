using UnityEngine;
using Trell.Core.StateMachinePattern;
using System.Collections.Generic;
using System;
using Trell.Player;
using Trell.CombatSystem;
using Sirenix.OdinInspector;

namespace Trell.StateMachineRealization.Character.Player
{
    public class PlayerBehaviour : CharacterBehaviour
    {
        [field: TabGroup("Handlers")]
        [field: SerializeField] public PlayerClickHandler ClickHandler { get; private set; }

        public Vector3 PositionToMove { get; private set; }
        
        private void OnEnable()
        {
            TrySubscribeToTargetHealthDownToZeroEvent();
            ClickHandler.HittedEnemyChanged += ChangeTarget;
            ClickHandler.LastClickPositionChanged += ChangePositionToMove;
        }

        private void OnDisable()
        {
            TryUnSubscribeFromTargetHealthDownToZeroEvent();
            ClickHandler.HittedEnemyChanged -= ChangeTarget;
            ClickHandler.LastClickPositionChanged -= ChangePositionToMove;
        }

        private void Awake()
        {
            PositionToMove = transform.position;
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
            TryUnSubscribeFromTargetHealthDownToZeroEvent();
            Target = target;
            TrySubscribeToTargetHealthDownToZeroEvent();
        }

        private bool TrySubscribeToTargetHealthDownToZeroEvent()
        {
            if (Target != null)
            {
                Target.DownToZero += TargetHealthDownToZeroHandle;
                return true;
            }
            return false;
        }

        private bool TryUnSubscribeFromTargetHealthDownToZeroEvent()
        {
            if (Target != null)
            {
                Target.DownToZero -= TargetHealthDownToZeroHandle;
                return true;
            }
            return false;
        }

        private void TargetHealthDownToZeroHandle()
        {
            ChangePositionToMove(transform.position);
        }
        private void ChangePositionToMove(Vector3 position)
        {
            PositionToMove = position;
        }

    }
}