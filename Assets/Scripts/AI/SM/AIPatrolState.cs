using Trell.AI.FSM;
using UnityEngine;

namespace Trell.AI.FSM
{
    public class AIPatrolState : BaseState
    {
        public AIPatrolState(AIStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
        }

     
        public override void Exit()
        {
        }

        public override void Update()
        {
            Debug.Log("Я патрулирую, Лол.");
            if (StateMachine.InRangeToTriggerChasing)
            {
                StateMachine.SetState<AIChasingState>();
            }

        }
    }
}