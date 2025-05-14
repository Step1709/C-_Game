namespace Scenes.EntityState2
{
    public class AttackState : IEntityState
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
            throw new System.NotImplementedException();
        }

        public void Exit(EnemyStateMachine stateMachine)
        {
            throw new System.NotImplementedException();
        }
    }
}