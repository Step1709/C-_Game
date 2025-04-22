using Fighting;
using UnityEngine;

namespace Scenes
{
    public class PrepareState : IState
    {
        public static PrepareState Instance { get; } = new PrepareState();

        public PrepareManager prepareManager = GameModel.Instance.GameModelObject.GetComponent<PrepareManager>();
        public void Enter()
        {
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var baseHandler = player.GetComponent<PlayerBaseHandler>();
                baseHandler.enabled = true;
            }
            prepareManager.enabled = true;
        }

        public void Exit()
        {
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var baseHandler = player.GetComponent<PlayerBaseHandler>();
                baseHandler.enabled = false;
            }
            prepareManager.enabled = false;
        }
    }
}