namespace Scenes
{
    public class StateMachine
    {
        public static StateMachine Instance { get; }= new StateMachine();
        
        private IState currentState = PrepareState.Instance;

        public void ChangeState(IState newState)
        {
            currentState.Exit();
            newState.Enter();
            currentState = newState;
        }
    }
}