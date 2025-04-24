namespace Scenes.EntityState2
{
    public interface IEntityState
    {
        void Enter(PlayerStateMachine stateMachine);
        void Exit(PlayerStateMachine stateMachine);
        void Enter(EnemyStateMachine stateMachine);
        void Exit(EnemyStateMachine stateMachine);
    }
}