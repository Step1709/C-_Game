using Scenes.EntityState2;
using Weapons;

namespace Abilities
{
    public class EnemyUsingBoost: UsingBoost<EnemyStateMachine>
    {
        protected override IState<EnemyStateMachine> UsingAbility { get; } = UsingAbilityState.Instance;
        protected override IState<EnemyStateMachine> Active { get; } = ActiveState.Instance;
    }
}