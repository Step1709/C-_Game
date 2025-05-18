using Abilities;
using Entities;
using Scenes.Scene;

namespace Scenes.EntityState2
{
    public class ActiveState : IEntityState
    {
        public static ActiveState Instance { get; } = new ActiveState();
        public void Enter(PlayerStateMachine stateMachine)
        { 
            CameraClass.Instance.ChosenEntity = stateMachine.gameObject;
            CameraClass.Instance.IsFree = false;
            stateMachine.fightController.enabled = true;
            stateMachine.player.ChangeAbility(NoAbility.Instance);
        }

        public void Exit(PlayerStateMachine stateMachine)
        {
            stateMachine.fightController.enabled = false;
        }

        public void Enter(EnemyStateMachine stateMachine)
        {
            CameraClass.Instance.ChosenEntity = stateMachine.gameObject;
            CameraClass.Instance.IsFree = false;
            stateMachine.EnemyAI.enabled = true;
        }

        public void Exit(EnemyStateMachine stateMachine)
        {
            stateMachine.EnemyAI.enabled = false;
        }
    }
}