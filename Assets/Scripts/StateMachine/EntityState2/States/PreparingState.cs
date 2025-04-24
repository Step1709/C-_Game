namespace Scenes.EntityState2
{
    public class PreparingState : IEntityState
    {
        public void Enter(PlayerStateMachine stateMachine)
        {
            stateMachine.TileGraph.enabled = true;
            stateMachine.baseHandler.enabled = true;
        }

        public void Exit(PlayerStateMachine stateMachine)
        {
            stateMachine.TileGraph.enabled = false;
            stateMachine.baseHandler.enabled = false;
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