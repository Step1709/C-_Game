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
            stateMachine.fightController.enabled = true;
            stateMachine.finishMove.enabled = true;
        }

        public void Exit(PlayerStateMachine stateMachine)
        {
            stateMachine.fightController.enabled = false;
            stateMachine.finishMove.enabled = false;
        }

        public void Enter(EnemyStateMachine stateMachine)
        {
            CameraClass.Instance.ChosenEntity = stateMachine.gameObject;
            stateMachine.EnemyAI.enabled = true;
        }

        public void Exit(EnemyStateMachine stateMachine)
        {
            stateMachine.EnemyAI.enabled = false;
        }
    }
}