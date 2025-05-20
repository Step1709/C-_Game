using Fighting;
using Scenes.EntityState2;
using UnityEngine;

namespace Scenes
{
    public class PrepareState : IState
    {
        public static PrepareState Instance { get; } = new PrepareState();
        
        public void Enter()
        {
            var prepareManager = GameModel.Instance.GameModelObject.GetComponent<PrepareManager>();
            var changeChosen = GameModel.Instance.GameModelObject.GetComponent<ChangeChosen>();
            changeChosen.enabled = true;
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var stateMachine = player.GameObject.GetComponent<PlayerStateMachine>();
                stateMachine.ChangeState(PreparingState.Instance);
            }
            prepareManager.enabled = true;
        }

        public void Exit()
        {
            var prepareManager = GameModel.Instance.GameModelObject.GetComponent<PrepareManager>();
            prepareManager.enabled = false;
        }
    }
}