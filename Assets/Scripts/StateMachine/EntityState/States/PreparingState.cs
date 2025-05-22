namespace Scenes.EntityState2
{
    public class PreparingState : IPlayerState
    {
        public static PreparingState Instance { get; } = new PreparingState();
        public void Enter(PlayerStateMachine stateMachine)
        {
            stateMachine.player?.ChangeAbility(null);
            stateMachine.TileGraph.enabled = true;
            stateMachine.baseHandler.enabled = true;
        }

        public void Exit(PlayerStateMachine stateMachine)
        {
            stateMachine.TileGraph.enabled = false;
            stateMachine.baseHandler.enabled = false;
        }
    }
}