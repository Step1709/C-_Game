using Fighting;
using Scenes.EntityState2;
using UnityEngine;

namespace Scenes
{
    public class PrepareState : IState
    {
        public static PrepareState Instance { get; } = new PrepareState();

        private PrepareManager prepareManager = GameModel.Instance.GameModelObject.GetComponent<PrepareManager>();

        private ChangeChosen changeChosen = GameModel.Instance.GameModelObject.GetComponent<ChangeChosen>();
        public void Enter()
        {
            changeChosen.enabled = true;
            foreach (var player in GameModel.Instance.MainPlayers)
            {
                var stateMachine = player.GetComponent<PlayerStateMachine>();
                stateMachine.ChangeState(PreparingState.Instance);
            }
            prepareManager.enabled = true;
        }

        public void Exit()
        {
            prepareManager.enabled = false;
        }
    }
}