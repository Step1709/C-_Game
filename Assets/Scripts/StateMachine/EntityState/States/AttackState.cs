namespace Scenes.EntityState2
{
    public class AttackState : IPlayerState, IEnemyState
    {
        public static AttackState Instance { get; } = new AttackState();
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
            stateMachine.EnemyAI.enabled = false;
        }

        public void Exit(EnemyStateMachine stateMachine)
        {
            stateMachine.EnemyAI.enabled = true;
        }
    }
}