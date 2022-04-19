namespace Trell.Core.StateMachinePattern
{
    public abstract class BaseState
    {
        private StateMachine _stateMachine;
        protected BaseState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public abstract void Enter();
        public virtual void Update() { }

        public virtual void FixedUpdate() { }
        public abstract void Exit();

        protected void GoToState<T>() where T : BaseState 
        {
            _stateMachine.SetState<T>();
        } 
    }
}