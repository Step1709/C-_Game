namespace Scenes.EntityState2
{
    public class UsingAbilityState : IState<PlayerStateMachine>, IState<EnemyStateMachine>
    {
        public static UsingAbilityState Instance { get; }= new UsingAbilityState();
        
        public void Enter(EnemyStateMachine stateMachine)
        {
        }

        public void Exit(EnemyStateMachine stateMachine)
        {
        }

        public void Enter(PlayerStateMachine stateMachine)
        {
        }

        public void Exit(PlayerStateMachine stateMachine)
        {
        }
    }
}