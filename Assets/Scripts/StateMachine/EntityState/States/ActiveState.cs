using Abilities;
using Entities;
using Scenes.Scene;
using UI;

namespace Scenes.EntityState2
{
    public class ActiveState : IPlayerState, IEnemyState
    {
        public static ActiveState Instance { get; } = new ActiveState();
        public void Enter(PlayerStateMachine stateMachine)
        { 
            CameraClass.Instance.ChosenEntity = stateMachine.gameObject;
            CameraClass.Instance.IsFree = false;
            stateMachine.Interface.player = stateMachine.player;
            stateMachine.Interface.UpdateAbilityImages();
            Screen.Instance.PlayerInterface.SetActive(true);
            stateMachine.fightController.enabled = true;
            stateMachine.player.AbilityIndex = 0;
            stateMachine.player.ChangeAbility(stateMachine.player.Abilities[0]);
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