using Abilities;
using Entities;

namespace Scenes.EntityState2
{
    public class WaitingState : IEntityState
    {
        public static WaitingState Instance { get; } = new WaitingState();
        public void Enter(PlayerStateMachine stateMachine)
        {
            stateMachine.gameObject.GetComponent<EntityWrapper>().Entity.ChangeAbility(NoAbility.Instance);
        }

        public void Exit(PlayerStateMachine stateMachine)
        {
        }

        public void Enter(EnemyStateMachine stateMachine)
        {
        }

        public void Exit(EnemyStateMachine stateMachine)
        {
        }
    }
}