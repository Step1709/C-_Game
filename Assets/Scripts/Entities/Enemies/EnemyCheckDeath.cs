using Scenes.EntityState2;

namespace Entities
{
    public class EnemyCheckDeath: CheckDeath<EnemyStateMachine>
    {
        protected override IState<EnemyStateMachine> deathState { get; } = DeathState.Instance;
    }
}