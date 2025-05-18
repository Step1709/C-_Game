namespace Scenes.EntityState2
{
    public interface IEnemyState : IEntityState
    {
        void Enter(EnemyStateMachine stateMachine);
        void Exit(EnemyStateMachine stateMachine);
    }
}