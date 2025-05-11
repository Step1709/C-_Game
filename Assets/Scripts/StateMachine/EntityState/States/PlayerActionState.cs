namespace Scenes.EntityState2
{
    public class PlayerActionState : IEntityState
    {
        public  static PlayerActionState Instance { get; } = new PlayerActionState();
        public void Enter(PlayerStateMachine stateMachine)
        {
            stateMachine.playerAction.enabled = true;
        }

        public void Exit(PlayerStateMachine stateMachine)
        {
            stateMachine.playerAction.enabled = false;
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