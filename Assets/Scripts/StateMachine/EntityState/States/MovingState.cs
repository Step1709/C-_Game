namespace Scenes.EntityState2
{
    public class MovingState : IEntityState
    {
        public static MovingState Instance { get; } = new MovingState();
        public void Enter(PlayerStateMachine stateMachine)
        {
            stateMachine.pathController.enabled = false;
        }

        public void Exit(PlayerStateMachine stateMachine)
        {
            stateMachine.pathController.enabled = true;
        }

        public void Enter(EnemyStateMachine stateMachine)
        {
        }

        public void Exit(EnemyStateMachine stateMachine)
        {
        }
    }
}