using Scenes.EntityState2;

namespace Abilities
{
    public class EnemyMove : Move<EnemyStateMachine>
    {
        protected override IState<EnemyStateMachine> UsingAbility { get; } = UsingAbilityState.Instance;
        protected override IState<EnemyStateMachine> Active { get; } = ActiveState.Instance;
    }
}