using UnityEngine;

namespace Scenes
{
    public class PrepareState : IState
    {
        public static PrepareState Instance { get; } = new PrepareState();
        public void Enter()
        {
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var baseHandler = player.GetComponent<PlayerBaseHandler>();
                baseHandler.enabled = true;
            }
        }

        public void Exit()
        {
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var baseHandler = player.GetComponent<PlayerBaseHandler>();
                baseHandler.enabled = false;
            }
        }
    }
}