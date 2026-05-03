using Scenes;
using Scenes.EntityState2;

namespace Abilities
{
    public class PlayerAttack : Attack<MainPlayer, PlayerStateMachine>
    {
        protected override IState<PlayerStateMachine> UsingAbility { get; } = UsingAbilityState.Instance;
        protected override IState<PlayerStateMachine> Active { get; } = ActiveState.Instance;
    }
}