using Scenes.EntityState2;

namespace Entities
{
    public class PlayerCheckDeath: CheckDeath<PlayerStateMachine>
    {
        protected override IState<PlayerStateMachine> deathState { get; } = DeathState.Instance;
    }
}