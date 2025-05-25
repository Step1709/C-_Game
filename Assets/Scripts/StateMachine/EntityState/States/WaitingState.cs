using Abilities;
using Entities;
using UI;

namespace Scenes.EntityState2
{
    public class WaitingState : IPlayerState, IEnemyState
    {
        public static WaitingState Instance { get; } = new WaitingState();
        public void Enter(PlayerStateMachine stateMachine)
        {
            stateMachine.Interface.player = null;
            Screen.Instance.PlayerInterface.SetActive(false);
            stateMachine.player.ChangeAbility(null);
        }

        public void Exit(PlayerStateMachine stateMachine)
        {
        }

        public void Enter(EnemyStateMachine stateMachine)
        {
            stateMachine.enemy.ChangeAbility(null);
        }

        public void Exit(EnemyStateMachine stateMachine)
        {
        }
    }
}