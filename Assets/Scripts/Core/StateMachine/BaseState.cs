namespace Trell.Core.StateMachinePattern
{
    public abstract class BaseState
    {
        private StateMachine _stateMachine;
        protected BaseState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public virtual void Enter() { }
        public virtual void Update() { }

        public virtual void FixedUpdate() { }
        public virtual void Exit() { }

        protected void GoToState<T>() where T : BaseState 
        {
            _stateMachine.SetState<T>();
        } 
    }
}