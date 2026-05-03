using Scenes;
using Scenes.EntityState2;

namespace Weapons
{
    public class PlayerUsingBoost: UsingBoost<PlayerStateMachine>
    {
        protected override IState<PlayerStateMachine> UsingAbility { get; } = UsingAbilityState.Instance;
        protected override IState<PlayerStateMachine> Active { get; } = ActiveState.Instance;
    }
}