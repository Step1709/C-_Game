namespace Scenes.EntityState2
{
    public class PreparingState : IState<PlayerStateMachine>
    {
        public static PreparingState Instance { get; } = new PreparingState();
        public void Enter(PlayerStateMachine stateMachine)
        {
            stateMachine.player?.ChangeAbility(null);
            stateMachine.TileGraph.enabled = true;
        }

        public void Exit(PlayerStateMachine stateMachine)
        {
            stateMachine.TileGraph.enabled = false;
        }
    }
}