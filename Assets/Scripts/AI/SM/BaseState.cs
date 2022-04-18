namespace Trell.AI.FSM
{
    public abstract class BaseState
    {
        protected AIStateMachine StateMachine;
        public BaseState(AIStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}