using Fighting;
using Scenes.EntityState;
using UnityEngine;

namespace Scenes
{
    public class PrepareState : IState
    {
        public static PrepareState Instance { get; } = new PrepareState();

        public PrepareManager prepareManager = GameModel.Instance.GameModelObject.GetComponent<PrepareManager>();
        public void Enter()
        {
            GameModel.Instance.GameModelObject.GetComponent<ChangeChosen>().enabled = true;
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                StateMachine.Instance.ChangeEntityState(player, PreparingState.Instance);
            }
            prepareManager.enabled = true;
        }

        public void Exit()
        {
            prepareManager.enabled = false;
        }
    }
}