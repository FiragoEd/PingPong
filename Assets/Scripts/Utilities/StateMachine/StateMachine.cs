namespace Utilities.StateMachine
{
    public abstract class StateMachine
    {
        private IState _currentState;

        public IState CurrentState => _currentState;

        public void Initialize(IState state)
        {
            _currentState = state;
            state.Enter();
        }

        public virtual void SetState(IState state)
        {
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}