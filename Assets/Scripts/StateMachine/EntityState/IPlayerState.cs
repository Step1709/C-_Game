namespace Scenes.EntityState2
{
    public interface IPlayerState : IEntityState
    {
        void Enter(PlayerStateMachine stateMachine);
        void Exit(PlayerStateMachine stateMachine);
    }
}