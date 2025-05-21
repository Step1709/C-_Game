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
            UI.Screen.Instance.PlayerButtons.SetActive(true);
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
            UI.Screen.Instance.PlayerButtons.SetActive(false);
            var prepareManager = GameModel.Instance.GameModelObject.GetComponent<PrepareManager>();
            prepareManager.enabled = false;
        }
    }
}